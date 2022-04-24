<template>
  <div class="text-center" v-show="false">
    <v-dialog
        width="500"
        ref="dialogRef"
        persistent
        @click:outside="toggleRegisterWindow(false)"
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
                name="input-10-1"
                label="Пароль"
                counter
                @click:append="showPassword = !showPassword"
            />
          </v-row>
          <v-row>
            <div v-if="errorMsg.length" class="error-message">{{ errorMsg }}</div>
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

  email: string = 'sakhnikarseni@mail.ru'
  password: string = 'парольДаЯ'
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


}
</script>
<style scoped lang="scss">
.error-message {
  color: red;
}
</style>
