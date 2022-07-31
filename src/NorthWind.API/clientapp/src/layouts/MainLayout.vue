<template>
  <v-app>
    <success-alert/>
    <navbar/>
    <router-view/>
    <footer-section/>
  </v-app>
</template>

<script lang="ts">
import {Component, Vue} from 'vue-property-decorator'
import Navbar from '@/components/Navbar.vue'
import FooterSection from "@/components/Footer.vue";
import SuccessAlert from "@/components/Alerts/SuccessAlert.vue";
import {namespace} from "vuex-class";

@Component({components: {Navbar, FooterSection, SuccessAlert}})
export default class MainLayout extends Vue {
  
}
</script>
<style scoped>
@media screen and (max-width: 600px) {
  .text-block-setting {
    font-size: 26px
  }
}

@media screen and (min-width: 601px) and (max-width: 960px) {
  .text-block-setting {
    font-size: 34px;
  }
}

@media screen and (min-width: 961px) and (max-width: 1264px) {
  .text-block-setting {
    font-size: 40px;
  }
}

@media screen and (min-width: 1080px) {
  .text-block-setting {
    font-size: 48px;
  }
}
</style>
