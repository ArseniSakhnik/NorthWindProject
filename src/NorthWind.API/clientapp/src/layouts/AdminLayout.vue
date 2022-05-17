<template>
  <v-app v-if="isDataLoaded">
    <div v-if="isActive" class="alert-section">
      <success-alert
          :message="alertMessage"
      />
    </div>
    <navbar/>
    <div class="user-section">
      <div class="background-image">
      </div>
      <v-row>
        <v-col
            cols="12"
            sm="2"
            style="padding-bottom: 0"
        >
          <admin-sidebar
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
import NavbarAdmin from "@/components/Admin/NavbarAdmin.vue";
import Navbar from "@/components/Navbar.vue";
import FooterSection from "@/components/Footer.vue";
import SuccessAlert from "@/components/Alerts/SuccessAlert.vue";
import UserSidebar from "@/components/UserSidebar.vue";
import {namespace} from "vuex-class";
import AdminSidebar from "@/components/Admin/AdminSidebar.vue";

const Alert = namespace('AlertStore')
const User = namespace('CurrentUserStore')

@Component({components: {Navbar, FooterSection, SuccessAlert, AdminSidebar}})
export default class AdminLayout extends Vue {
  @Alert.Action('CALL_ALERT') callAlert!: () => void;
  @User.Action('GET_CURRENT_USER_INFO') getCurrentUserInfo!: () => Promise<void>;
  @Alert.State('isActive') isActive!: boolean;
  @Alert.State('alertMessage') alertMessage!: string;
  isDataLoaded: boolean = false;
  currentView: number = 0;

  async created() {
    await this.getCurrentUserInfo()
        .then(() => this.isDataLoaded = true);
  }
}
</script>
<style scoped>
.background-image {
  background-image: url('../assets/backgrounds/phons.png');
  height: 20vh;
}

.user-section {
  min-height: 100vh;
  background-color: #f2f6ff;
}
</style>
