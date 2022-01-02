<template>
  <component :is="$route.meta.layout + '-layout'">
  </component>
</template>

<script lang="ts">
import {Vue, Component} from 'vue-property-decorator'
import MainLayout from '@/layouts/MainLayout.vue'
import AdminLayout from '@/layouts/AdminLayout.vue'

@Component({components: {MainLayout, AdminLayout}})
export default class App extends Vue {
  created() {
    //@ts-ignore
    console.log(this.$route.meta.layout)
  }
}
</script>
<style scoped>

</style>

