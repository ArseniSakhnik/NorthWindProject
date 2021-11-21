<template>
  <div>
    <h1>

    </h1>
  </div>
</template>

<script lang="ts">
import {Vue, Component} from 'vue-property-decorator'

@Component({})
export default class SlideContent extends Vue {
  private slideItems: [] = [
    {
      title: 'Вывоз строительного и крупногабаритного мусора',
      to: '/'
    },
    {
      title: 'Откачка жидких бытовых отходов',
      to: '/'
    },
    {
      title: 'Полив и очистка территории',
      to: '/'
    },
  ];
}
</script>

<style scoped>

</style>
