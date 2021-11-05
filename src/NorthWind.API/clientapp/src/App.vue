<template>
  <component :is="getLayout + '-layout'" v-if="getLayout">
  </component>
</template>

<script lang="ts">
import {Vue, Component} from 'vue-property-decorator'
import MainLayout from '@/layouts/MainLayout.vue'

@Component({components: {MainLayout}})
export default class App extends Vue {


  private get getLayout() {
    //@ts-ignore
    return this.$route.meta.layout;
  }

}
</script>
