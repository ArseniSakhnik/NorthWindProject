<template>
  <div class="slider-section">
    <div class="auto-section">
      <div ref="sliderContainer" class="slider-container">
        <div ref="slider" class="slider">
          <div v-for="index in 4">
            <div
                class="block" 
                :style="`background-image: url(${getImage(index)})`"
            >
              <h5>БУНКЕРОВОЗЫ</h5>
              <p>₽ 2 000/час</p>
              <ul>
                <li>
                  <h5>Мощность двигателя</h5>
                  <p>240 ед.</p>
                </li>
                <li>
                  <h5>Мощность двигателя</h5>
                  <p>240 ед.</p>
                </li>
                <li>
                  <h5>Мощность двигателя</h5>
                  <p>240 ед.</p>
                </li>
              </ul>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script lang="ts">
import {Vue, Component, Ref} from "vue-property-decorator";

@Component
export default class SliderAuto extends Vue {
  @Ref('sliderContainer') sliderContainer!: HTMLElement;
  @Ref('slider') slider!: HTMLElement;
  clicked: boolean = false;
  xAxis: number = 0;
  x: number = 0;
  
  getImage(index: number) {
    return require(`../assets/cars/car${index}.png`)
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

.block {
  height: 438px;
  width: 360px;
  background-color: black;
  
  display: flex;
  
}

.slider-container {
  position: absolute;
  top: 50%;
  left: 50%;
  transform: translate(-50%, -50%);
  width: 80%;
  height: 500px;
  overflow: hidden;
  cursor: grab;
}

.slider {
  position: absolute;
  top: 0;
  left: 0;
  width: auto;
  height: 100%;
  display: grid;
  grid-template-columns: repeat(10, 1fr); /*we have 10 imgs so repeat 10 times 1 fr*/
  column-gap: 2rem;
  pointer-events: none;
}

.slider-item {
  width: 300px;
  height: 100%;
}

.slider-item img {
  width: 100%;
  height: 100%;
  object-fit: cover;
  user-select: none;
}
</style>
