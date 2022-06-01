<template>
  <div class="my-div">
    <vs-navbar
        class="bg-transparent blur"
        padding-scroll
        text-white
        fixed
        square
        center-collapsed
        color="primary"
    >
      <template v-if="isMobile" #left>
        <v-system-bar class="opacity"/>
        <v-app-bar-nav-icon
            @click.stop="drawer = !drawer"
        />
      </template>
      <template v-else #left>
        <logo style="max-width: 50px; max-height: 50px;" class="mr-2"/>
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
      <template #right>
        <vs-button
            color="#fff"
            flat
            @click="openLoginWindow"
            v-if="!isUserAuthenticated"
        >
          Войти
        </vs-button>
        <vs-button
            color="#fff"
            flat
            @click="openRegisterWindow"
            v-if="!isUserAuthenticated"
        >
          Регистрация
        </vs-button>
        <div>
          <vs-button
              v-if="isUserAuthenticated"
              color="#fff"
              flat
              @click="goToUserInfo"
          >
            Личный кабинет
          </vs-button>
        </div>
        <div v-if="isUserAuthenticated">
          <vs-button
              color="#fff"
              flat
              @click="logout"
          >
            Выйти
          </vs-button>
        </div>
        <login-confirm
            :is-active.sync="isLogInDialogOpened"
            @closeLoginAndOpenRegisterForm="closeLoginAndOpenRegisterForm"
            @closeLoginAndOpenResetPasswordEmail="closeLoginAndOpenResetPasswordEmail"
        />
        <register-confirm
            :is-active.sync="isRegisterDialogOpened"
            @closeRegisterAndOpenTermsOfUser="closeRegisterAndOpenTermsOfUser"
        />
        <reset-password-confirm
            :is-active.sync="isResetPasswordEmailOpened"
            :initial-email="emailToConfirm"
        />
        <terms-of-user-confirm
            :is-active.sync="iAcceptTermsOfUserConfirmOpened"
        />
      </template>
    </vs-navbar>
    <div class="navigation-drawer" v-if="drawer">
      <v-navigation-drawer
          v-model="drawer"
          bottom
          temporary
          absolute
      >
        <v-list
            nav
            dense
            class="item-lists"
        >
          <v-list-item-group
              v-model="group"
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
import RegisterConfirm from "@/components/Confirms/RegisterConfirm.vue";
import BreakPointsMixin from "@/mixins/BreakPointsMixin.vue";
import LoginConfirm from "@/components/Confirms/LoginConfirm.vue";
import Logo from "@/components/Logo/Logo.vue";
import ResetPasswordConfirm from "@/components/Confirms/ResetPasswordConfirm.vue";
import TermsOfUserConfirm from "@/components/Confirms/TermsOfUserConfirm.vue";

const User = namespace('CurrentUserStore');

@Component({
  components: {TermsOfUserConfirm, ResetPasswordConfirm, RegisterConfirm, LoginConfirm, Logo}
})
export default class Navbar extends Mixins(HttpServiceMixin, BreakPointsMixin) {
  @User.Getter('IS_USER_AUTHENTICATED') isUserAuthenticated!: boolean;
  @User.Action('GET_CURRENT_USER_INFO') getCurrentUserInfo!: () => void;
  @User.State('fullName') fullName!: string;
  @User.Getter('IS_USER_ADMIN') isUserAdmin!: boolean;

  drawer: boolean = false;
  group: any = null;
  emailToConfirm: string = '';

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

  isRegisterDialogOpened: boolean = false;
  isLogInDialogOpened: boolean = false;
  isResetPasswordEmailOpened: boolean = false;
  iAcceptTermsOfUserConfirmOpened: boolean = false;
  dialog: boolean = false;

  get menuItems(): any[] {
    const items = [
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
    ]

    if (this.isUserAdmin) {
      items.push({
        title: 'Панель администрирования',
        to: '/admin-purchases'
      })
    }

    return items;
  }

  openRegisterWindow() {
    this.isRegisterDialogOpened = true;
  }

  openLoginWindow() {
    this.isLogInDialogOpened = true;
  }

  async logout() {
    await this.accountService.Logout()
        .then(async () => {
          await this.getCurrentUserInfo()
        });
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
<style scoped lang="scss">
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
