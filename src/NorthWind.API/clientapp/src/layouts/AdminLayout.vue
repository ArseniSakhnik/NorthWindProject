<template>
  <v-app v-if="isDataLoaded">
    <success-alert/>
    <navbar/>
    <div class="user-section">
      <div class="background-image">
        <h2 v-if="hasName">{{ name }}</h2>
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

const User = namespace('CurrentUserStore')

@Component({components: {Navbar, FooterSection, SuccessAlert, AdminSidebar}})
export default class AdminLayout extends Vue {

  @User.Action('GET_CURRENT_USER_INFO') getCurrentUserInfo!: () => Promise<void>;
  isDataLoaded: boolean = false;
  currentView: number = 0;

  async created() {
    await this.getCurrentUserInfo()
        .then(() => this.isDataLoaded = true);
  }

  get name(): any {
    return this.$route.meta?.name
  }

  get hasName(): boolean {
    return this.$route.meta?.name?.length > 0;
  }
}
</script>
<style scoped lang="scss">
.background-image {
  background-image: url('../assets/backgrounds/qweqwe 2.png');
  height: 20vh;

  position: relative;
  background-blend-mode: multiply;
  background-position: center bottom;
  background-size: cover;
  background-repeat: no-repeat;
  width: 100%;

  h2 {
    position: absolute;
    bottom: 20%;
    margin-left: 10vw;
    color: #FFFFFF;

    font-size: 2em;
    font-family: Raleway, sans-serif;
    font-weight: bold;
  }
}

.user-section {
  min-height: 100vh;
  background-color: #f2f6ff;
}
</style>
