<template>
  <div v-show="false" class="text-center">
    <v-dialog
        ref="dialogRef"
        persistent
        width="500"
        @click:outside="toggleRegisterWindow(false)"
        scrollable
    >
      <v-card>
        <v-card-title>
          <span class="text-h5">Вход в аккаунт</span>
        </v-card-title>
        <v-card-text>
          <v-row>
            <v-text-field
                v-model="email"
                label="Email"
            />
          </v-row>
          <v-row>
            <v-text-field
                v-model="password"
                :append-icon="showPassword ? 'mdi-eye' : 'mdi-eye-off'"
                :rules="[rules.required, rules.min]"
                :type="showPassword ? 'text' : 'password'"
                counter
                label="Пароль"
                name="input-10-1"
                @click:append="showPassword = !showPassword"
            />
          </v-row>
          <v-row>
            <div v-if="errorMsg.length" class="error-message">{{ errorMsg }}</div>
          </v-row>
          <v-row>
            <span class="registration-text" @click="closeLoginAndOpenRegisterForm">Регистрация</span>
          </v-row>
        </v-card-text>
        <v-card-actions>
          <v-spacer></v-spacer>
          <v-btn
              color="blue darken-1"
              text
              @click="toggleRegisterWindow(false)"
          >
            Закрыть
          </v-btn>
          <v-btn
              color="blue darken-1"
              text
              @click="authenticate"
          >
            Отправить
          </v-btn>
        </v-card-actions>
      </v-card>
    </v-dialog>
  </div>
</template>

<script lang="ts">
import {Component, Mixins} from "vue-property-decorator";
import DialogWindowMixin from "@/mixins/DialogWindowMixin.vue";
import {namespace} from "vuex-class";
import HttpServiceMixin from "@/mixins/HttpServiceMixin.vue";

const User = namespace('CurrentUserStore');

@Component
export default class LoginConfirm extends Mixins(HttpServiceMixin, DialogWindowMixin) {
  @User.Action('GET_CURRENT_USER_INFO') getCurrentUserInfo!: () => void;

  email: string = ''
  password: string = ''
  errorMsg: string = ''
  showPassword: boolean = false;

  rules = {
    required: (value: any) => !!value || 'Обязательно для заполнения',
    min: (v: string) => v.length >= 8 || 'Min 8 characters',
    emailMatch: () => (`The email and password you entered don't match`),
  }


  private async authenticate() {
    await this.accountService.Login({
      email: this.email,
      password: this.password,
    }).then(async () => {
      await this.getCurrentUserInfo();
      this.close();
    }).catch(exception => {
      this.errorMsg = this.getErrorMessage(exception);
    })
  }

  closeLoginAndOpenRegisterForm() {
    this.$emit('closeLoginAndOpenRegisterForm');
  }
}
</script>
<style lang="scss" scoped>
.error-message {
  color: red;
}

.registration-text {
  color: #0040ff;
  cursor: pointer;
}
</style>
