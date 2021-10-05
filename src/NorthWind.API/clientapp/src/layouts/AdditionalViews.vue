<template>
  <navbar/>
  <router-view/>
  <footer/>
</template>
<script lang="ts">
import {defineComponent} from 'vue'
import Navbar from '@/components/Navbar.vue'

export default defineComponent({
  name: 'AdditionalLayout',
  components: {Navbar}
})
</script>
<style scoped>

</style>