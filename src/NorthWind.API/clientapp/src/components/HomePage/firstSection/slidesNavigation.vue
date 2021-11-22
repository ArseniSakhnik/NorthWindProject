<template>
  <div>

  </div>
</template>

<script lang="ts">
import {Vue, Component} from 'vue-property-decorator'

@Component({})
export default class SlidesNavigation extends Vue {
  private menuItems: [] = [
    {
      title: 'Вывоз строительного мусора',
      to: '/'
    },
    {
      title: 'Откачка бытовых отходов',
      to: '/'
    },
    {
      title: 'Полив и очистка территории',
      to: '/'
    },
  ];

  get itemIcon() {
    return require(`../../assets/homePage/firstSection/${this.slideItems[this.currentSlide].image}`);
  }
}
</script>

<style scoped>

</style>
