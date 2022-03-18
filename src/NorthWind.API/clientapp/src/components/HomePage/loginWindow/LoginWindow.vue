<template>
  <div>
    <vs-dialog
        v-model="isDialogOpenedSync"
        ref="dialogWindow"
        @close="close"
    >
      <template #header>
        <h4 class="not-margin">
          <b>Здравствуйте!</b>
        </h4>
      </template>
      <div class="con-form">
        <vs-input v-model="email" placeholder="Email"/>
        <vs-input type="password" v-model="password" placeholder="Пароль"/>
        <div class="flex">
          <vs-checkbox v-model="rememberMe">Запомнить меня?</vs-checkbox>
          <a href="#">Забыли пароль?</a>
        </div>
      </div>

      <template #footer>
        <div class="footer-dialog">
          <vs-button block @click="authenticate">
            Вход
          </vs-button>

          <p v-if="errorMsg.length" class="error-message">{{ errorMsg }}</p>

          <div class="new">
            Нет аккаунта?
            <router-link to="/">Зарегистрируйтесь!</router-link>
          </div>
        </div>
      </template>
    </vs-dialog>
  </div>
</template>

<script lang="ts">
import {Vue, Component, PropSync, Mixins} from 'vue-property-decorator'
import HttpServiceMixin from "@/mixins/HttpServiceMixin.vue"
import {namespace} from "vuex-class";

const User = namespace('CurrentUserStore');

@Component
export default class LoginWindow extends Mixins(HttpServiceMixin) {
  @PropSync('isDialogOpened', {type: Boolean, required: true}) isDialogOpenedSync!: boolean
  @User.Action('GET_CURRENT_USER_INFO') getCurrentUserInfo!: () => void;


  private email: string = ''
  private password: string = ''
  private rememberMe: boolean = false
  private errorMsg: string = '';

  private async authenticate() {
    await this.accountService.Login({
      email: this.email,
      password: this.password,
      rememberMe: this.rememberMe
    }).then(async () => {
      await this.getCurrentUserInfo();
      this.close();
    }).catch(response => {
      this.errorMsg = response.message;
    })
  }

  private close(): void {
    this.isDialogOpenedSync = false
  }
}
</script>
<style lang="scss">
.not-margin {
  margin: 0px;
  font-weight: normal;
  padding: 10px;
}

.con-form {
  width: 100%;

  .flex {
    display: flex;
    align-items: center;
    justify-content: space-between;

    a {
      font-size: .8rem;
      opacity: .7;

      &:hover {
        opacity: 1;
      }
    }
  }

  .vs-checkbox-label {
    font-size: .8rem;
  }

  .vs-input-content {
    margin: 10px 0px;
    width: calc(100%);

    .vs-input {
      width: 100%;
    }
  }
}

.footer-dialog {
  display: flex;
  align-items: center;
  justify-content: center;
  flex-direction: column;
  width: calc(100%);

  .new {
    margin: 0px;
    margin-top: 20px;
    padding: 0;
    font-size: .7rem;

    .a {
      margin-left: 6px;

      &:hover {
        text-decoration: underline;
      }
    }
  }

  .vs-button {
    margin: 0;
  }
}

.vs-input-content:first-child {
  width: 100%;
}

.error-message {
  padding-top: 15px;
  color: red;
}

</style>
