<template>
  <section
      :style="`background-image: url(${slideImage})`"
      class="service-list  flex-container-slides"
  >
    <div class="arrow left">

    </div>
    <div>
      
    </div>
    <div class="arrow right">

    </div>
  </section>
</template>

<!--<section-->
<!--    :style="`background-image: url(${slideImage})`"-->
<!--    class="service-list relative">-->
<!--<div class="slider-control-back">-->
<!--  <v-btn @click="previousSlide">Назад</v-btn>-->
<!--</div>-->
<!--<slides-navigation :current-item.sync="currentSlide"/>-->
<!--<slide-content :title="slideItems[currentSlide].title"/>-->
<!--<div class="slider-control-next">-->
<!--  <v-btn @click="nextSlide">Вперед</v-btn>-->
<!--</div>-->
<!--</section>-->

<script lang="ts">
import {Vue, Component, Ref} from 'vue-property-decorator'
import SlideContent from "@/components/HomePage/firstSection/SlideContent.vue";
import SlidesNavigation from "@/components/HomePage/firstSection/SlidesNavigation.vue";

type Slide = { title: string; to: string; image: string }
@Component({
  components: {SlidesNavigation, SlideContent}
})
export default class FirstSection extends Vue {
  private currentSlide: number = 0;
  @Ref('first-section') private firstSection!: HTMLElement;
  private slideItems: Slide[] = [
    {
      title: 'Вывоз строительного и крупногабаритного мусора',
      to: '/',
      image: 'services1.png'
    },
    {
      title: 'Откачка жидких бытовых отходов',
      to: '/',
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

.arrow {
  width: 60px;
  height: 60px;
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
  margin-left: 12px;
  transform: rotate(-135deg);
  -webkit-transform: rotate(-135deg);
}

@media screen and (max-width: 600px) {
  .arrow {
    width: 30px;
    height: 30px;
  }
}

//.service-list {
//  position: relative;
//  background-blend-mode: multiply;
//  background-position: center bottom;
//  background-color: rgba(#1b3648, 0.35);
//  background-size: cover;
//  background-repeat: no-repeat;
//  width: 100%;
//  height: 100vh;
//}
//
//.slider-control-back, .slider-control-next {
//  position: absolute;
//  height: 100vh;
//  display: flex;
//  justify-content: center;
//  align-items: center;
//  top: 0;
//}
//
//.slider-control-next {
//  right: 0;
//}
//
//.slider-control-back {
//  left: 0;
//}
</style>
