﻿<template>
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
          <span class="text-h5">Регистрация</span>
        </v-card-title>
        <v-card-text>
          <v-container>
            <v-row>
              <v-col
                  cols="12"
                  md="4"
                  sm="6"
              >
                <v-text-field
                    v-model="localData.surname"
                    label="Фамилия"
                    required
                />
              </v-col>
              <v-col
                  cols="12"
                  md="4"
                  sm="6"
              >
                <v-text-field
                    v-model="localData.name"
                    label="Имя"
                />
              </v-col>
              <v-col
                  cols="12"
                  md="4"
                  sm="6"
              >
                <v-text-field
                    v-model="localData.middleName"
                    label="Отчество"
                />
              </v-col>
              <v-col cols="12">
                <v-text-field
                    v-model="localData.email"
                    label="Email"
                    required
                />
              </v-col>
              <v-col cols="12">
                <v-text-field
                    v-mask="'(###)-###-##-##'"
                    :value="localData.phoneNumber"
                    label="Номер телефона"
                    @input="phoneNumberInputHandler"
                    prefix="+7"
                />
              </v-col>
              <v-col>
                <div v-if="errorMessage.length" class="error-message">{{ errorMessage }}</div>
              </v-col>
              <v-row>
                <v-checkbox
                    v-model="iAcceptTermsOfUser"
                >
                  <template v-slot:label>
                    <span
                        @click="closeRegisterAndOpenTermsOfUser"
                    >
                      Я ознакомился с соглашением о персональных данных
                    </span>
                  </template>
                </v-checkbox>
              </v-row>
            </v-row>
          </v-container>
        </v-card-text>
        <v-card-actions>
          <v-spacer></v-spacer>
          <v-btn
              color="orange darken-3"
              text
              @click="toggleRegisterWindow(false)"
          >
            Закрыть
          </v-btn>
          <v-btn
              color="orange darken-3"
              text
              @click="register"
              :disabled="!iAcceptTermsOfUser"
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
import {RegisterModel} from "@/services/AccountService/RequestsAccountService";
import HttpServiceMixin from "@/mixins/HttpServiceMixin.vue";
import {namespace} from "vuex-class";
import DialogWindowMixin from "@/mixins/DialogWindowMixin.vue";

const Alert = namespace('AlertStore');

@Component
export default class RegisterConfirm extends Mixins(HttpServiceMixin, DialogWindowMixin) {
  @Alert.Action('CALL_ALERT') callAlert!: (data: { message: string, delay: number }) => void;

  iAcceptTermsOfUser: boolean = false;

  localData: RegisterModel = {
    email: '',
    middleName: '',
    name: '',
    phoneNumber: '',
    surname: '',
  }

  errorMessage: string = '';

  phoneNumberInputHandler(value: string) {
    this.localData.phoneNumber = value;
  }

  async register() {
    const alertData = {
      message: 'Для завершения регистрации необходимо подтвердить адрес электронной почты',
      delay: 7000
    };

    await this.accountService.Register(this.localData)
        .then(() => {
          this.callAlert(alertData)
          this.toggleRegisterWindow(false)
        })
        .catch(error => {
          this.errorMessage = this.getErrorMessage(error);
        })
  }

  closeRegisterAndOpenTermsOfUser() {
    this.$emit('closeRegisterAndOpenTermsOfUser')
  }
}
</script>
<style lang="scss" scoped>
.error-message {
  color: red;
}
</style>
