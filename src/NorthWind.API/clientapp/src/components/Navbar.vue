<template>
  <vs-navbar
      class="bg-transparent blur"
      padding-scroll
      fixed
      text-white
      square
      center-collapsed
      color="primary"
  >
    <template #left>
      <img
          src="../assets/small_logo.png"
          @click="gotoMainPage"
          alt="Logo"
      />
      <span
          @click="gotoMainPage"
      >
        Северный Ветер
      </span>
    </template>
    <vs-navbar-item v-for="({title, to},index) in menuItems"
                    :key="index"
                    :to="to">
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
      />
      <register-confirm
          :is-active.sync="isRegisterDialogOpened"
      />
    </template>
  </vs-navbar>
</template>

<script lang="ts">
import {Vue, Component, Mixins, Ref} from 'vue-property-decorator'
import HttpServiceMixin from "@/mixins/HttpServiceMixin.vue"
import {namespace} from "vuex-class";
import RegisterConfirm from "@/components/Confirms/RegisterConfirm.vue";
import BreakPointsMixin from "@/mixins/BreakPointsMixin.vue";
import LoginConfirm from "@/components/Confirms/LoginConfirm.vue";

const User = namespace('CurrentUserStore');

@Component({
  components: {RegisterConfirm, LoginConfirm}
})
export default class Navbar extends Mixins(HttpServiceMixin, BreakPointsMixin) {
  @User.Getter('IS_USER_AUTHENTICATED') isUserAuthenticated!: boolean;
  @User.Action('GET_CURRENT_USER_INFO') getCurrentUserInfo!: () => void;
  @User.State('fullName') fullName!: string;
  @User.Getter('IS_USER_ADMIN') isUserAdmin!: boolean;

  goToUserInfo() {
    this.$router.push('/user-info')
  }

  isRegisterDialogOpened: boolean = false;
  isLogInDialogOpened: boolean = false
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
        title: 'Вакансии',
        to: '/'
      },
      {
        title: 'Контакты',
        to: '/'
      },
    ]

    if (this.isUserAdmin) {
      items.push({
        title: 'Панель администрирования',
        to: '/admin'
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
}
</script>
<style scoped lang="scss">
.blur {
  backdrop-filter: blur(3px);
}
</style>
