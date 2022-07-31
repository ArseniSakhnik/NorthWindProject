<template>
  <component :is="$route.meta.layout + '-layout'">
  </component>
</template>

<script lang="ts">
import {Component, Vue} from 'vue-property-decorator'
import MainLayout from '@/layouts/MainLayout.vue'
import AdminLayout from '@/layouts/AdminLayout.vue'
import SystemLayout from "@/layouts/SystemLayout.vue"
import ActionLayout from "@/layouts/ActionLayout.vue"
import {namespace} from "vuex-class";
import UserLayout from "@/layouts/UserLayout.vue";


@Component({components: {MainLayout, AdminLayout, SystemLayout, ActionLayout, UserLayout}})
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

