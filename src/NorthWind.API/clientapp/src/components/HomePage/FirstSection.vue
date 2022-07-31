<template>
  <div>
    <section
        v-if="isDataLoad"
        :style="`background-image: url(${slideImage})`"
        class="service-list flex-container-slides"
    >
      <div class="arrow-container">
        <div class="arrow left" @click="previousSlide"/>
      </div>
      <div>
        <v-row>
          <v-col v-if="isComputer"/>
          <v-col>
            <h1 class="text-white slide-text">{{ slideItems[currentSlide].title }}</h1>
            <orange-button
                style="margin-right: 1em"
                title="Заказать услугу"
                @action="openRequestCall"
            />
            <transparent-button
                @action="aboutService"
            />
          </v-col>
        </v-row>
      </div>
      <div class="arrow-container">
        <div class="arrow right" @click="nextSlide"/>
      </div>
    </section>
    <v-skeleton-loader
        v-else
        class="mx-auto"
        height="100vh"
        type="card"
    />
  </div>
</template>

<script lang="ts">
import {Component, Mixins, Prop, Ref} from 'vue-property-decorator'
import SlideContent from "@/components/HomePage/firstSection/SlideContent.vue";
import BreakPointsMixin from "@/mixins/BreakPointsMixin.vue";
import OrangeButton from "@/components/Buttons/OrangeButton.vue";
import TransparentButton from "@/components/Buttons/TransparentButton.vue";
import HttpServiceMixin from "@/mixins/HttpServiceMixin.vue";
import {ServiceTypeEnum} from "@/enums/Enums";


type Slide = { id: ServiceTypeEnum, title: string; image: string }
@Component({
  components: {SlideContent, OrangeButton, TransparentButton}
})
export default class FirstSection extends Mixins(BreakPointsMixin, HttpServiceMixin) {
  @Prop({type: Boolean}) isSecondSectionOpened!: boolean;
  @Ref('first-section') private firstSection!: HTMLElement;

  isDataLoad: boolean = false;
  private currentSlide: number = 0;
  private slideItems: Slide[] = [
    {
      id: ServiceTypeEnum.Assenizator,
      title: '',
      image: ''
    },
  ];

  get slideImage() {
    return this.slideItems[this.currentSlide].image;
  }

  get slidesLength() {
    return this.slideItems.length
  }

  async created() {
    const {data: serviceView} = await this.serviceViewService.GetServiceViews();
    
    this.slideItems = serviceView.map(item => ({
      id: item.id,
      image: `/ServiceImage/${item.mainImageName}`,
      title: item.title,
    }))

    this.isDataLoad = true;
  }

  goToContract(link: string) {
    this.$router.push(link);
  }

  private nextSlide() {
    if (this.currentSlide >= this.slidesLength - 1) {
      this.currentSlide = 0
    } else {
      this.currentSlide++
    }
  }

  private previousSlide() {
    if (this.currentSlide <= 0) {
      this.currentSlide = this.slidesLength - 1
    } else {
      this.currentSlide--
    }
  }

  private aboutService() {
    this.$emit('toSecondSection');
  }

  private openRequestCall() {
    console.log('kal')
  }
}
</script>
<style lang="scss" scoped>
.service-list {
  position: relative;
  background-blend-mode: multiply;
  background-position: center bottom;
  background-color: rgba(#1b3648, 0.35);
  background-size: cover;
  background-repeat: no-repeat;
  width: 100vw;
  height: 100vh;
}

.flex-container-slides {
  display: flex;
  justify-content: space-between;
  align-items: center;
  align-content: center;
}

.arrow-container {
  width: 2.4em;
}

.arrow {
  width: 1.2em !important;
  height: 1.2em !important;
  border-top: 2px solid #F2F6FF;
  border-right: 2px solid #F2F6FF;
  cursor: pointer;
}

.right {
  margin-right: 32px;
  transform: rotate(45deg);
  -webkit-transform: rotate(45deg);
}

.left {
  margin-left: 1em;
  transform: rotate(-135deg);
  -webkit-transform: rotate(-135deg);
}


.slide-text {
  font-size: 1em;
}

@media screen and (max-width: 667px) {
  .slide-text {
    font-size: 0.7em;
  }
}

.second-section-opened {
  background: linear-gradient(180deg, rgba(0, 51, 102, 0) 23.94%, #003366 100%);
}
</style>
