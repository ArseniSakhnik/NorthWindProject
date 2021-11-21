<template>
  <section
      :style="`background-image: url(${slideImage})`"
      class="service-list">
    <div style="padding: 400px">
      <v-btn @click="previousSlide">Назад</v-btn>
      <v-btn @click="nextSlide">Вперед</v-btn>
    </div>
  </section>
</template>

<script lang="ts">
import {Vue, Component, Ref} from 'vue-property-decorator'

@Component
export default class FirstSection extends Vue {
  private currentSlide: number = 0;
  @Ref('first-section') private firstSection!: HTMLElement;
  private slideItems: [] = [
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

  get slidesLength(){
    return this.slideItems.length
  }

  private nextSlide(){
    if(this.currentSlide >= this.slidesLength - 1){
      this.currentSlide = 0
    }
    else{
      this.currentSlide++
    }
  }
  private previousSlide(){
    if(this.currentSlide <= 0){
      this.currentSlide = this.slidesLength - 1
    }
    else{
      this.currentSlide--
    }
  }

}
</script>
<style scoped lang="scss">
.service-list {
  background-position: center top;
  background-blend-mode: overlay;
  background-color: rgba(27, 54, 72, 0.5);
  background-size: cover;
  width: 100vw;
  height: 100vh;
}
</style>
