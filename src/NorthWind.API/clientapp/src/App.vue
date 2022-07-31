<template>
  <component :is="$route.meta.layout + '-layout'">
  </component>
</template>

<script lang="ts">
import {Component, Vue} from 'vue-property-decorator'
import MainLayout from '@/layouts/MainLayout.vue'
import SystemLayout from "@/layouts/SystemLayout.vue"
import ActionLayout from "@/layouts/ActionLayout.vue"


@Component({components: {MainLayout, SystemLayout, ActionLayout}})
export default class App extends Vue {
  isDataLoaded: boolean = false;
}
</script>
<style>
@import "https://fonts.googleapis.com/css?family=Roboto:100,300,400,500,700,900";
@import "https://cdn.jsdelivr.net/npm/@mdi/font@latest/css/materialdesignicons.min.css";
@import "https://fonts.googleapis.com/css?family=Material+Icons";
@import '~vuetify/dist/vuetify.css';
</style>

