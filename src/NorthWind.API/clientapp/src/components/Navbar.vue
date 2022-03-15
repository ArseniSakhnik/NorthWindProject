<template>
  <vs-navbar
      class="bg-transparent blur"
      padding-scroll
      fixed
      text-white
      square
      center-collapsed>
    <template #left>
      <v-img src="../assets/small_logo.png"/>
      <span>
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
      <div v-else>
        {{ fullName }}
      </div>
      <login-window :is-dialog-opened.sync="isLogInDialogOpened"/>
      <vs-button color="#fff" border>Оставить заявку</vs-button>
    </template>
  </vs-navbar>
</template>

<script lang="ts">
import {Vue, Component, Mixins} from 'vue-property-decorator'
import LoginWindow from "@/components/HomePage/loginWindow/LoginWindow.vue"
import HttpServiceMixin from "@/mixins/HttpServiceMixin.vue"
import {namespace} from "vuex-class";

const User = namespace('CurrentUserStore');

@Component({
  components: {LoginWindow}
})
export default class Navbar extends Mixins(HttpServiceMixin) {
  @User.Getter('IS_USER_AUTHENTICATED') isUserAuthenticated!: boolean;
  @User.State('fullName') fullName!: string;

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
  private isLogInDialogOpened: boolean = false
}
</script>
<style scoped lang="scss">
.blur {
  backdrop-filter: blur(3px);
}
</style>
