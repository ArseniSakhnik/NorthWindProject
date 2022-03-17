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
          <span class="text-h5">Регистрация</span>
        </v-card-title>
        <v-card-text>
          <v-container>
            <v-row>
              <v-col
                  cols="12"
                  sm="6"
                  md="4"
              >
                <v-text-field
                    label="Фамилия"
                    v-model="localData.surname"
                    required
                />
              </v-col>
              <v-col
                  cols="12"
                  sm="6"
                  md="4"
              >
                <v-text-field
                    label="Имя"
                    v-model="localData.name"
                />
              </v-col>
              <v-col
                  cols="12"
                  sm="6"
                  md="4"
              >
                <v-text-field
                    label="Отчество"
                    v-model="localData.middleName"
                />
              </v-col>
              <v-col cols="12">
                <v-text-field
                    label="Email"
                    required
                />
              </v-col>
              <v-col cols="12">
                <v-text-field
                    label="Номер телефона"
                    :value="localData.phoneNumber"
                    v-mask="'#(###)-###-##-##'"
                    @input="phoneNumberInputHandler"
                />
              </v-col>
              <v-col cols="12">
                <v-text-field
                    label="Пароль"
                    type="password"
                    v-model="localData.password"
                    required
                />
              </v-col>
              <v-col>
                <div v-if="errorMessage.length" class="error-message">{{ errorMessage }}</div>
              </v-col>
              <v-col cols="12">
                <v-checkbox
                    label="Запоменить меня"
                />
              </v-col>
            </v-row>
          </v-container>
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
              @click="register"
          >
            Отправить
          </v-btn>
        </v-card-actions>
      </v-card>
    </v-dialog>
  </div>
</template>

<script lang="ts">


import {Vue, Component, Ref, PropSync, Watch, Mixins} from "vue-property-decorator";
import {RegisterModel} from "@/services/AccountService/RequestsAccountService";
import HttpServiceMixin from "@/mixins/HttpServiceMixin.vue";

@Component
export default class RegisterConfirm extends Mixins(HttpServiceMixin) {
  @PropSync('isActive') isConfirmActive!: boolean;
  @Ref('dialogRef') dialogRef!: any;

  localData: RegisterModel = {
    email: '',
    middleName: '',
    name: '',
    password: '',
    phoneNumber: '',
    surname: '',
  }

  errorMessage: string = '';

  phoneNumberInputHandler(value: string) {
    this.localData.phoneNumber = value;
  }

  async register() {
    // await this.accountService.Register(this.localData)
    //     .then(() => this.toggleRegisterWindow(false))
    //     .catch((errorMessage => this.errorMessage = errorMessage));
  }

  toggleRegisterWindow(isOpen: boolean) {
    this.isConfirmActive = isOpen;
  }

  @Watch('isConfirmActive')
  isConfirmActiveChangeHandler(value: boolean) {
    this.dialogRef.isActive = value;
  }
}
</script>
<style scoped lang="scss">
.error-message {
  color: red;
}
</style>
