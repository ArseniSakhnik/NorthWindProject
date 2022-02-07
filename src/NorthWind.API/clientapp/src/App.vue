<template>
  <component :is="$route.meta.layout + '-layout'">
  </component>
</template>

<script lang="ts">
import {Vue, Component} from 'vue-property-decorator'
import MainLayout from '@/layouts/MainLayout.vue'
import AdminLayout from '@/layouts/AdminLayout.vue'
import SystemLayout from "@/layouts/SystemLayout.vue"
import ActionLayout from "@/layouts/ActionLayout.vue"


@Component({components: {MainLayout, AdminLayout, SystemLayout, ActionLayout}})
export default class App extends Vue {
  created() {
  }
}
</script>
<style scoped>

</style>

