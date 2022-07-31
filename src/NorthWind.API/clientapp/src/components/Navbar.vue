<template>
  <div class="my-div">
    <vs-navbar
        center-collapsed
        class="bg-transparent blur"
        color="primary"
        fixed
        padding-scroll
        square
        text-white
    >
      <template v-if="isMobile" #left>
        <v-system-bar class="opacity"/>
        <v-app-bar-nav-icon
            @click.stop="drawer = !drawer"
        />
      </template>
      <template v-else #left>
        <logo class="mr-2" style="max-width: 50px; max-height: 50px;"/>
        <span
            @click="gotoMainPage"
        >
        Северный Ветер
      </span>
      </template>
      <vs-navbar-item v-for="({title, to},index) in menuItems"
                      :key="index"
                      @click="goTo(to)">
        {{ title }}
      </vs-navbar-item>
    </vs-navbar>
    <div v-if="drawer" class="navigation-drawer">
      <v-navigation-drawer
          v-model="drawer"
          absolute
          bottom
          temporary
      >
        <v-list
            class="item-lists"
            dense
            nav
        >
          <v-list-item-group
              active-class="deep-purple--text text--accent-4"
              class="navbar-items-list"
          >
            <v-list-item v-for="item in menuItems">
              <v-list-item-title @click="goTo(item.to)">{{ item.title }}</v-list-item-title>
            </v-list-item>
          </v-list-item-group>
        </v-list>
      </v-navigation-drawer>
    </div>
  </div>
</template>

<script lang="ts">
import {Component, Mixins} from 'vue-property-decorator';
import HttpServiceMixin from "@/mixins/HttpServiceMixin.vue"
import {namespace} from "vuex-class";
import BreakPointsMixin from "@/mixins/BreakPointsMixin.vue";
import Logo from "@/components/Logo/Logo.vue";
import TermsOfUserConfirm from "@/components/Confirms/TermsOfUserConfirm.vue";

const User = namespace('CurrentUserStore');

@Component({
  components: {TermsOfUserConfirm, Logo}
})
export default class Navbar extends Mixins(HttpServiceMixin, BreakPointsMixin) {

  drawer: boolean = false;
  group: any = null;
  emailToConfirm: string = '';
  isRegisterDialogOpened: boolean = false;
  isLogInDialogOpened: boolean = false;
  isResetPasswordEmailOpened: boolean = false;
  iAcceptTermsOfUserConfirmOpened: boolean = false;
  dialog: boolean = false;

  get menuItems(): any[] {
    return [
      {
        title: 'Услуги',
        to: '/'
      },
      {
        title: 'Документы',
        to: '/documents'
      },
      {
        title: 'Контакты',
        to: '/contacts'
      },
    ];
  }

  goTo(to: string) {
    if (this.$route.path === to) {
      scroll(0, 0);
    } else {
      this.$router.push(to)
    }
  }

  goToUserInfo() {
    this.$router.push('/user-purchases')
  }

  openRegisterWindow() {
    this.isRegisterDialogOpened = true;
  }

  openLoginWindow() {
    this.isLogInDialogOpened = true;
  }

  gotoMainPage() {
    this.$router.push('/')
  }

  closeLoginAndOpenRegisterForm() {
    this.isLogInDialogOpened = false;
    this.isRegisterDialogOpened = true;
  }

  closeLoginAndOpenResetPasswordEmail(email: string) {
    this.emailToConfirm = email;
    this.isLogInDialogOpened = false;
    this.isResetPasswordEmailOpened = true;
  }

  closeRegisterAndOpenTermsOfUser() {
    this.iAcceptTermsOfUserConfirmOpened = true;
    this.isRegisterDialogOpened = false;
  }
}
</script>
<style lang="scss" scoped>
.blur {
  backdrop-filter: blur(3px);
}

.opacity {
  opacity: 0;
}

.navigation-drawer {
  position: fixed;
  bottom: 0;
  height: 100vh;
  width: 100vw;
  z-index: 4;
}
</style>
