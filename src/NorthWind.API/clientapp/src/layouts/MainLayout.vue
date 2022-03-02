<template>
  <v-app>
    <navbar/>
    <router-view/>
    <footer-section/>
  </v-app>
</template>

<script lang="ts">
import {Vue, Component} from 'vue-property-decorator'
import Navbar from '@/components/Navbar.vue'
import FooterSection from "@/components/Footer.vue";

@Component({components: {Navbar, FooterSection}})
export default class MainLayout extends Vue {

}
</script>
<style scoped>

</style>
