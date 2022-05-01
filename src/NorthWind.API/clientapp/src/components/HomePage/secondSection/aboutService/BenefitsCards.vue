<template>
  <v-item-group class="flex">
    <v-item v-for="(benefit,index) in benefits"
            :key="index">
      <v-card>
        <v-icon>
          {{ benefit.icon }}
        </v-icon>
        <v-card-title>
          {{ benefit.title }}
        </v-card-title>
        <v-card-text>
          {{ benefit.description }}
        </v-card-text>
      </v-card>
    </v-item>
  </v-item-group>
</template>

<script lang="ts">
import {Component, Vue} from 'vue-property-decorator'

type Benefits = { title: string; description: string, icon: string }

@Component
export default class BenefitsCards extends Vue {
  private benefits: Benefits[] = [
    {
      title: 'Удобное время',
      description: 'Учитывая сложность транспортной инфраструктуры, сотрудники нашей компании оказывают услуги в удобное для Заказчика время как в дневное, так и в ночное.',
      icon: '$time'
    },
    {
      title: 'Качество исполнения',
      description: 'Основным принципом, которым руководствуется все, без исключения, сотрудники нашей компании, является качество исполнения поставленных задач.',
      icon: '$reward'
    },
    {
      title: 'Индивидуальный подход',
      description: 'При долгосрочном сотрудничестве, ООО «Северный Ветер», гарантирует индивидуальный подход к Заказчику.',
      icon: '$customer'
    },
  ];
}
</script>

<style scoped>

</style>
