<template>
  <div>
    <h1>
      {{ title }}
    </h1>
    <vs-button color="#fff" flat>Заказать услугу</vs-button>
    <vs-button color="#fff" border>Подробнее</vs-button>
  </div>
</template>

<script lang="ts">
import {Vue, Component, Prop} from 'vue-property-decorator'

@Component({})
export default class SlideContent extends Vue {
  @Prop({type: String, required: true}) title!: string;
}
</script>

<style scoped>

</style>
