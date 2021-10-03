<template>
  <component :is="layout + '-layout'" v-if="layout">
  </component>
</template>

<script lang="ts">
import MainLayout from "@/layouts/MainLayout.vue";
import {computed, defineComponent} from 'vue';
import {useRoute} from "vue-router";

export default defineComponent({
  name: 'App',
  setup() {
    const route = useRoute();
    return {
      layout: computed(() => route.meta.layout)
    }
  },
  components: {MainLayout}
})
</script>

<style>

#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
}
</style>
