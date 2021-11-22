<template>
  <div class="service">
    <h1 class="text-white">
      {{ title }}
    </h1>
    <div class="buttons">
      <vs-button color="#fff" flat>Заказать услугу</vs-button>
      <vs-button color="#fff" border>Подробнее</vs-button>
    </div>
  </div>
</template>

<script lang="ts">
import {Vue, Component, Prop} from 'vue-property-decorator'

@Component({})
export default class SlideContent extends Vue {
  @Prop({type: String, required: true}) title!: string;
}
</script>

<style scoped lang="scss">
.service {
  padding: 7%;
  height: 100%;
  display: flex;
  flex-direction: column;
  justify-content: center;
  align-items: flex-end;

  h1{
    width: 50%;
  }

  .buttons{
    width: 50%;
    display: flex;
  }
}
</style>
