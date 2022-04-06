<template>
  <vs-navbar
      class="bg-transparent blur"
      padding-scroll
      fixed
      text-white
      square
      center-collapsed>
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
          @click="isLogInDialogOpened = !isLogInDialogOpened"
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

      <div v-if="isUserAuthenticated"
      >
        {{ fullName }}
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
      <login-window :is-dialog-opened.sync="isLogInDialogOpened"/>
      <vs-button color="#fff" border>Оставить заявку</vs-button>
      <register-confirm
          :is-active.sync="isRegisterDialogOpened"
      />
    </template>
  </vs-navbar>
</template>

<script lang="ts">
import {Vue, Component, Mixins, Ref} from 'vue-property-decorator'
import LoginWindow from "@/components/HomePage/loginWindow/LoginWindow.vue"
import HttpServiceMixin from "@/mixins/HttpServiceMixin.vue"
import {namespace} from "vuex-class";
import RegisterConfirm from "@/components/Confirms/RegisterConfirm.vue";

const User = namespace('CurrentUserStore');

@Component({
  components: {RegisterConfirm, LoginWindow}
})
export default class Navbar extends Mixins(HttpServiceMixin) {
  @User.Getter('IS_USER_AUTHENTICATED') isUserAuthenticated!: boolean;
  @User.Action('GET_CURRENT_USER_INFO') getCurrentUserInfo!: () => void;
  @User.State('fullName') fullName!: string;

  isRegisterDialogOpened: boolean = false;
  isLogInDialogOpened: boolean = false
  dialog: boolean = false;
  private menuItems: object[] = [
    {
      title: 'Услуги',
      to: '/'
    },
    {
      title: 'Документы',
      to: '/'
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

  openRegisterWindow() {
    this.isRegisterDialogOpened = true;
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
