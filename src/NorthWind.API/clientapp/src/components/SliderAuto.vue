<template>
  <hooper
      :infiniteScroll="isComputer"
      :itemsToShow="numberOfSlides"
      class="slider-section"
      @beforeSlide="disableClick"
  >
    <slide
        v-for="car in cars"
        class="slider"
    >
      <div
          :style="`background-image: url(${getImage(car.index)})`"
          class="block"
          @click="goToCar(car.index)"
      >
        <div class="bottom-card">
          <h5 class="text-white">{{ car.title }}</h5>
          <ul>
            <li>
              <h5>Мощность двигателя</h5>
              <p>{{ car.enginePower }}</p>
            </li>
            <li>
              <h5>Вместимость кузова</h5>
              <p>{{ car.capacity }}</p>
            </li>
            <li>
              <h5>{{ 'Базовое \n шосси' }}</h5>
              <p>{{ car.basicHighway }}</p>
            </li>
          </ul>
        </div>
      </div>
    </slide>
  </hooper>
</template>

<script lang="ts">
import {Component, Mixins, Ref} from "vue-property-decorator";
//@ts-ignore
import {Hooper, Slide} from 'hooper/dist/hooper.js'
import 'hooper/dist/hooper.css';
import BreakPointsMixin from "@/mixins/BreakPointsMixin.vue";

@Component({components: {Hooper, Slide}})
export default class SliderAuto extends Mixins(BreakPointsMixin) {
  @Ref('sliderContainer') sliderContainer!: HTMLElement;
  @Ref('slider') slider!: HTMLElement;
  canClick: boolean = false;
  clicked: boolean = false;
  xAxis: number = 0;
  x: number = 0;

  cars: { title: string, index: number, price: string, enginePower: string, capacity: string, basicHighway: string }[] = [
    {
      title: 'КОМБИНИРОВАННЫЕ ДОРОЖНЫЕ МАШИНЫ',
      index: 1,
      price: '₽ 5 000/час',
      enginePower: '245 ед.',
      capacity: '-',
      basicHighway: 'КАМАЗ-65115'
    },
    {
      title: 'БУНКЕРОВОЗЫ',
      index: 2,
      price: '₽ 3 400/час',
      enginePower: '240 ед.',
      capacity: '8 м³',
      basicHighway: 'МАЗ-5337'
    },
    {
      title: 'МУЛЬТИЛИФТ',
      index: 3,
      price: '₽ 2 200/час',
      enginePower: '250 ед.',
      capacity: '27 м³',
      basicHighway: 'Мерседес-Бенц 1625'
    },
    {
      title: 'АССЕНИЗАТОР',
      index: 4,
      price: '₽ 2 000/час',
      enginePower: '227 ед.',
      capacity: '10 м³',
      basicHighway: 'МАЗ-КО 523'
    }
  ]

  goToCar(index: number) {
    if (!this.canClick) return;

    this.$router.push(`/about-car/${index}`)
  }

  disableClick() {
    console.log(0)
    this.canClick = false;
    setTimeout(() => this.canClick = true, 500);
  }

  get numberOfSlides() {
    return this.isComputer ? 3 : 1;
  }

  getImage(index: number) {
    return require(`../assets/cars/car${index}.png`)
  }

}
</script>
<style lang="scss" scoped>
.slider-section {
  width: 100%;
  height: 100%;
}

.block {
  height: 438px;
  width: 360px;

  font-family: Raleway, sans-serif;
  font-weight: bold;

  position: relative;
  cursor: pointer;

  .bottom-card {
    position: absolute;
    bottom: 0;

    .text-white {
      font-size: 20px; //24px
      padding: 0;
      margin-left: 10px;
    }

    .price-block {
      background-color: #FF782E;
      padding-right: 10px;
      padding-left: 10px;
      font-size: 20px;
      color: white;
      width: 40%;
      margin-left: 10px;
      font-family: Raleway, sans-serif;
      font-weight: bold;
    }

    ul {
      display: flex;
      padding-left: 10px;

      li {
        font-size: 15px;
        font-family: Montserrat, sans-serif;
        font-weight: bold;

        h5 {
          color: #F2F6FF;
        }

        p {
          color: #F2F6FF;
        }
      }
    }


  }
}

</style>
