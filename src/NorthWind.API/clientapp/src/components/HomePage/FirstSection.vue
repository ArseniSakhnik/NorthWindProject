<template>
  <section
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
              title="Заказать услугу"
              style="margin-right: 1em"
              @action="goToPurchase(slideItems[currentSlide].to)"
          />
          <transparent-button/>
        </v-col>
      </v-row>
    </div>
    <div class="arrow-container">
      <div class="arrow right" @click="nextSlide"/>
    </div>
  </section>
</template>

<script lang="ts">
import {Vue, Component, Ref, Mixins, Prop} from 'vue-property-decorator'
import SlideContent from "@/components/HomePage/firstSection/SlideContent.vue";
import SlidesNavigation from "@/components/HomePage/firstSection/SlidesNavigation.vue";
import BreakPointsMixin from "@/mixins/BreakPointsMixin.vue";
import OrangeButton from "@/components/Buttons/OrangeButton.vue";
import TransparentButton from "@/components/Buttons/TransparentButton.vue";


type Slide = { title: string; to: string; image: string }
@Component({
  components: {SlidesNavigation, SlideContent, OrangeButton, TransparentButton}
})
export default class FirstSection extends Mixins(BreakPointsMixin) {
  private currentSlide: number = 0;
  @Ref('first-section') private firstSection!: HTMLElement;

  @Prop({type: Boolean}) isSecondSectionOpened!: boolean;

  private slideItems: Slide[] = [
    {
      title: 'Вывоз строительного и крупногабаритного мусора',
      to: '/',
      image: 'services1.png'
    },
    {
      title: 'Откачка жидких бытовых отходов',
      to: '/create-vacuum-truck-purchase',
      image: 'services2.png'
    },
    {
      title: 'Полив и очистка территории',
      to: '/',
      image: 'services3.png'
    },
  ];

  get slideImage() {
    return require(`../../assets/homePage/firstSection/${this.slideItems[this.currentSlide].image}`);
  }

  get slidesLength() {
    return this.slideItems.length
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

  goToPurchase(link: string) {
    console.log(1)
    this.$router.push(link);
  }
}
</script>
<style scoped lang="scss">
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
