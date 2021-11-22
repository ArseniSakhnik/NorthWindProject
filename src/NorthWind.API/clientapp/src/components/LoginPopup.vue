<template>
  <div class="center">
    <vs-dialog v-model="active">
      <template #header>
        <h4 class="not-margin">
          Войти
        </h4>
      </template>
      <div class="con-form">
        <vs-input v-model="email" placeholder="Email">
          <template #icon>
            <v-icon>email</v-icon>
          </template>
        </vs-input>
        <vs-input type="password" v-model="password" placeholder="Password">
          <template #icon>
            <v-icon>password</v-icon>
          </template>
        </vs-input>
        <div class="flex">
          <vs-checkbox v-model="remember">Запомнить меня</vs-checkbox>
          <a href="#">Забыли пароль?</a>
        </div>
      </div>

      <template #footer>
        <div class="footer-dialog">
          <vs-button block>
            Войти
          </vs-button>

          <div class="new">
            Впервые здесь? <a href="#">Создать аккаунт</a>
          </div>
        </div>
      </template>
    </vs-dialog>
  </div>
</template>

<script>
export default {
  name: "LoginPopup"
}
</script>

<style scoped>

</style>
