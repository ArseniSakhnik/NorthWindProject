<template>
  <img alt="Vue logo" src="./assets/logo.png">
  <router-link to="/#/AdminPanel">Админская панель</router-link>
  <component :is="layout + '-layout'" v-if="layout">
  </component>
</template>

<script>
import MainLayout from "@/layouts/MainLayout";
import {useRoute} from 'vue-router'
import {computed} from "vue";

export default {
  name: 'App',
  setup() {
    const route = useRoute();
    return {
      layout: computed(() => route.meta.layout)
    }
  },
  components: {MainLayout}
}
</script>

<style>
</style>
