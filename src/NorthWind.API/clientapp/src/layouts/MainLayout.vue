<template>
  <div class="site-background">
    <navbar/>
    <router-view/>
    <Footer/>
  </div>
</template>

<script lang="ts">
import Navbar from '@/components/Navbar.vue'
import Footer from '@/components/Footer.vue'
import {defineComponent} from "vue";

export default defineComponent({
  name: "MainLayout",
  components: {Navbar, Footer}
})
</script>

<style scoped>

</style>