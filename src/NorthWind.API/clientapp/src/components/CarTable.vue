<template>
  <v-card>
    <v-data-table
        :headers="headers"
        :items="carsInfoModes"
        class="table"
        hide-default-footer
    />
  </v-card>
</template>

<script lang="ts">
import {Component, Prop, Vue} from "vue-property-decorator";
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
<style lang="scss" scoped>
</style>
