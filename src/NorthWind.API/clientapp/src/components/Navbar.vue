<template>
  <vs-navbar
      class="bg-transparent"
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
      >Войти
      </vs-button>
      <login-window :is-dialog-opened.sync="isLogInDialogOpened"/>
      <vs-button color="#fff" border>Оставить заявку</vs-button>
      <button @click="test">Тест</button>
    </template>
  </vs-navbar>
</template>

<script lang="ts">
import {Vue, Component, Mixins} from 'vue-property-decorator'
import LoginWindow from "@/components/HomePage/loginWindow/LoginWindow.vue"
import HttpServiceMixin from "@/mixins/HttpServiceMixin.vue"

@Component({
  components: {LoginWindow}
})
export default class Navbar extends Mixins(HttpServiceMixin) {
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

  private async test(): void {
    await this.accountService.GetCurrentUserInfo()
        .then(response => console.log(response))
  }
}
</script>
<style scoped lang="scss">
//.main-navbar {
//  width: 100%;
//  position: fixed;
//  display: flex;
//  justify-content: space-between;
//  padding: 0 1.92vw;
//  height: 100px;
//  align-items: center;
//  transition: 0.6s;
//
//  ul {
//    display: flex;
//    justify-content: center;
//
//    li {
//      list-style: none;
//      padding-left: 0.96vw;
//
//      .navbar-link {
//        text-decoration: none;
//        font-family: 'Raleway', sans-serif;
//        font-size: 18px;
//        font-weight: 400;
//        color: rgba(242, 246, 255, .75);
//      }
//
//      .active {
//        color: white;
//      }
//    }
//  }
//}
//
//.sticky {
//  background-color: rgba(255, 255, 255, .5);
//  -webkit-backdrop-filter: blur(1x);
//  backdrop-filter: blur(1x);
//  transition: 0.6s;
//}

</style>
