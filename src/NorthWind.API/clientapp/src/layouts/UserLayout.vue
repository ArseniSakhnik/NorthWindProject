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
import {Component, Vue, Watch} from 'vue-property-decorator'
import Navbar from '@/components/Navbar.vue'
import FooterSection from "@/components/Footer.vue";
import SuccessAlert from "@/components/Alerts/SuccessAlert.vue";
import {namespace} from "vuex-class";
import UserSidebar from "@/components/UserSidebar.vue";

const User = namespace('CurrentUserStore')

@Component({components: {Navbar, FooterSection, SuccessAlert, UserSidebar}})
export default class MainLayout extends Vue {
  @User.Action('GET_CURRENT_USER_INFO') getCurrentUserInfo!: () => Promise<void>;

  isDataLoaded: boolean = false;
  currentView: number = 0;

  get name(): any {
    return this.$route.meta?.name
  }
  
  get hasName(): boolean {
    return this.$route.meta?.name?.length > 0;
  }

  async created() {
    //@ts-ignore
    await this.getCurrentUserInfo()
        .then(() => this.isDataLoaded = true);
  }
}
</script>
<style scoped lang="scss">
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

  @media screen and (max-width: 600px) {
    h2 {
      font-size: 1em;
    }
  }

  @media screen and (min-width: 601px) and (max-width: 960px) {
    h2 {
      font-size: 1em;
    }
  }

}

.user-section {
  min-height: 100vh;
  background-color: #f2f6ff;
}
</style>
