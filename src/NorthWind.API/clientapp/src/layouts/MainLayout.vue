<template>
  <v-app>
    <div class="alert-section" v-if="isActive">
      <success-alert
          :message="alertMessage"
      />
    </div>
    <navbar/>
    <router-view/>
    <footer-section/>
  </v-app>
</template>

<script lang="ts">
import {Vue, Component} from 'vue-property-decorator'
import Navbar from '@/components/Navbar.vue'
import FooterSection from "@/components/Footer.vue";
import SuccessAlert from "@/components/Alerts/SuccessAlert.vue";
import {namespace} from "vuex-class";

const Alert = namespace('AlertStore')

@Component({components: {Navbar, FooterSection, SuccessAlert}})
export default class MainLayout extends Vue {
  @Alert.Action('CALL_ALERT') callAlert!: () => void;
  @Alert.State('isActive') isActive!: boolean;
  @Alert.State('alertMessage') alertMessage!: string;

  updated() {
    console.log(this.isActive)
  }
}
</script>
<style scoped>
.alert-section {
  position: absolute;
  top: 80vh;
  z-index: 2;
}
</style>
