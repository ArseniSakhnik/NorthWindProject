<template>
  <v-card>
    <v-data-table
        :headers="headers"
        :items="carsInfoModes"
        hide-default-footer
        class="table"
    />
  </v-card>
</template>

<script lang="ts">
import {Vue, Component, Prop} from "vue-property-decorator";
import {CarInfoModel} from "@/services/CarsService/Responses";

@Component
export default class CarTable extends Vue {
  @Prop({required: true})
  carsInfoModes!: CarInfoModel[];

  headers: any = [
    {
      text: 'Показатель',
      value: 'indicator',
    },
    {
      text: 'Параметр',
      value: 'parameter'
    },
  ]
}
</script>
<style scoped lang="scss">
</style>
