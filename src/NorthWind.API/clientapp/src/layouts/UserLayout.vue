<template>
  <v-app v-if="isDataLoaded">
    <div v-if="isActive" class="alert-section">
      <success-alert
          :message="alertMessage"
      />
    </div>
    <navbar/>
<!--    <router-view/>-->
    <div class="user-section">
      <div class="background-image">
      </div>
      <v-row>
        <v-col
            cols="12"
            sm="2"
            style="padding-bottom: 0"
        >
          <user-sidebar
              :current-view.sync="currentView"
          />
        </v-col>
        <v-col
            cols="12"
            sm="10"
        >
          <router-view/>
        </v-col>
      </v-row>
    </div>
    <footer-section/>
  </v-app>
</template>

<script lang="ts">
import {Component, Vue} from 'vue-property-decorator'
import Navbar from '@/components/Navbar.vue'
import FooterSection from "@/components/Footer.vue";
import SuccessAlert from "@/components/Alerts/SuccessAlert.vue";
import {namespace} from "vuex-class";
import UserSidebar from "@/components/UserSidebar.vue";

const Alert = namespace('AlertStore')
const User = namespace('CurrentUserStore')

@Component({components: {Navbar, FooterSection, SuccessAlert, UserSidebar}})
export default class MainLayout extends Vue {
  @Alert.Action('CALL_ALERT') callAlert!: () => void;
  @Alert.State('isActive') isActive!: boolean;
  @Alert.State('alertMessage') alertMessage!: string;
  @User.Action('GET_CURRENT_USER_INFO') getCurrentUserInfo!: () => Promise<void>;
  isDataLoaded: boolean = false;
  currentView: number = 0;


  async created() {
    await this.getCurrentUserInfo()
        .then(() => this.isDataLoaded = true);
  }
}
</script>
<style scoped>
.alert-section {
  position: absolute;
  top: 80vh;
  z-index: 2;
}


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

.background-image {
  background-image: url('../assets/backgrounds/phons.png');
  height: 20vh;
}

.user-section {
  min-height: 100vh;
  background-color: #f2f6ff;
}
</style>
