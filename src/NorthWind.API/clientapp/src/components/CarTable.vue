<template>
  <v-card>
    <v-data-table
        :headers="headers"
        :items="desserts1"
        hide-default-footer
        class="table"
    />
  </v-card>
</template>

<script lang="ts">
import {Vue, Component} from "vue-property-decorator";

@Component
export default class CarTable extends Vue {
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

  desserts1: any = [
    {
      indicator: 'Базовое шасси',
      parameter: 'Мерседес-Бенц 1625'
    },
    {
      indicator: 'Мощность двигателя',
      parameter: '250'
    },
    {
      indicator: 'Вмесимость кузова полезная, м3',
      parameter: '27'
    },
    {
      indicator: 'Масса загружаемых отходов, кг',
      parameter: '12000'
    },
    {
      indicator: 'Полная масса, кг',
      parameter: '24000'
    },
    {
      indicator: 'Масса спецоборудования, кг',
      parameter: '12000'
    },
    {
      indicator: 'Длина, мм',
      parameter: '8000'
    },
    {
      indicator: 'Ширина, мм',
      parameter: '2500'
    },
    {
      indicator: 'Высота, мм',
      parameter: '3100'
    }
  ]
  desserts2: any = [
    {
      indicator: 'Базовое шасси',
      parameter: 'МАЗ-КО 523'
    },
    {
      indicator: 'Мощность двигателя',
      parameter: '227'
    },
    {
      indicator: 'Вмесимость цистерны, м3',
      parameter: '10'
    },
    {
      indicator: 'Полная масса, кг',
      parameter: '18000'
    },
    {
      indicator: 'Масса спецоборудования, кг',
      parameter: '10000'
    },
    {
      indicator: 'Длина, мм',
      parameter: '6310'
    },
    {
      indicator: 'Ширина, мм',
      parameter: '2500'
    },
    {
      indicator: 'Высота, мм',
      parameter: '2970'
    },
    {
      indicator: 'Стоимость услуги, р.',
      parameter: 'от 2500'
    }
  ]

  dessertsCars: any = [
    this.desserts1,
    this.desserts2
  ]
}
</script>
<style scoped lang="scss">
</style>
