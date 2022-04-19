<template>
  <hooper :itemsToShow="numberOfSlides" :infiniteScroll="isComputer" class="slider-section">
    <slide v-for="index in 4" class="slider">
      <div
          class="block"
          :style="`background-image: url(${getImage(index)})`"
      >
        <div class="bottom-card">
          <h5 class="text-white">БУНКЕРОВОЗЫ</h5>
          <div class="price-block">₽ 2 000/час</div>
          <ul>
            <li>
              <h5>Мощность двигателя</h5>
              <p>240 ед.</p>
            </li>
            <li>
              <h5>Вместимость кузова</h5>
              <p>8 м³</p>
            </li>
            <li>
              <h5>Мощность двигателя</h5>
              <p>МАЗ-5337</p>
            </li>
          </ul>
        </div>
      </div>
    </slide>
  </hooper>
</template>

<script lang="ts">
import {Component, Ref, Mixins} from "vue-property-decorator";
//@ts-ignore
import {Hooper, Slide} from 'hooper/dist/hooper.js'
import 'hooper/dist/hooper.css';
import BreakPointsMixin from "@/mixins/BreakPointsMixin.vue";

@Component({components: {Hooper, Slide}})
export default class SliderAuto extends Mixins(BreakPointsMixin) {
  @Ref('sliderContainer') sliderContainer!: HTMLElement;
  @Ref('slider') slider!: HTMLElement;
  clicked: boolean = false;
  xAxis: number = 0;
  x: number = 0;

  getImage(index: number) {
    return require(`../assets/cars/car${index}.png`)
  }

  get numberOfSlides() {
    return this.isComputer ? 3 : 1;
  }

  mounted() {

    this.sliderContainer.addEventListener('mouseup', () => {
      this.sliderContainer.style.cursor = 'grab';
    })

    this.sliderContainer.addEventListener('mousedown', e => {

      this.clicked = true;
      this.xAxis = e.offsetX - this.slider.offsetLeft;

      this.sliderContainer.style.cursor = 'grabbing';
    })

    window.addEventListener('mouseup', () => {
      this.clicked = false;
    })

    this.sliderContainer.addEventListener('mousemove', e => {

      if (!this.clicked) return;

      e.preventDefault();

      this.x = e.offsetX;
      this.slider.style.left = `${this.x - this.xAxis}px`;

      this.checkSize()
    })
  }

  checkSize() {
    let sliderContainerOut = this.sliderContainer.getBoundingClientRect();
    let sliderIn = this.slider.getBoundingClientRect();

    if (parseInt(this.slider.style.left) > 0) {
      this.slider.style.left = `0px`;
    } else if (sliderIn.right < sliderContainerOut.right) {
      this.slider.style.left = `-${sliderIn.width - sliderContainerOut.width}px`
    }
  }

}
</script>
<style scoped lang="scss">
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
