<template>
  <v-dialog
      ref="dialogRef"
      @click:outside="toggleRegisterWindow(false)"
      scrollable
      persistent
      width="500"
  >
    <v-card>
      <v-card-title>
        <h2>Обратный звонок</h2>
      </v-card-title>
      <v-card-text>
        <string-field
            ref="1"
            v-model="localData.name"
            label="Имя*"
            :rules="[isStringNotEmpty]"
        />
        <string-field
            ref="2"
            v-model="localData.phoneNumber"
            mask="(###)-###-##-##"
            prefix="+7"
            label="Номер телефона*"
            :rules="[isStringNotEmpty]"
        />
        <v-textarea
            v-model="localData.comment"
            label="Комментарий"
            counter
            single-line
            outlined
        />
      </v-card-text>
      <v-card-actions>
        <v-spacer></v-spacer>
        <v-btn @click="toggleRegisterWindow(false)">
          Назад
        </v-btn>
        <v-btn
            color="orange darken-3"
            @click="requestCall"
            style="color: white"
        >
          Отправить
        </v-btn>
      </v-card-actions>
    </v-card>
  </v-dialog>
</template>

<script lang="ts">
import {Vue, Component, Mixins} from "vue-property-decorator";
import OrangeButton from "@/components/Buttons/OrangeButton.vue";
import DialogWindowMixin from "@/mixins/DialogWindowMixin.vue";
import {RequestCall} from "@/services/RequestCallService/Request";
import HttpServiceMixin from "@/mixins/HttpServiceMixin.vue";
import AlertMixin from "@/mixins/AlertMixin.vue";
import ValidationMixin from "@/mixins/ValidationMixin.vue";
import StringField from "@/components/Fields/StringField.vue";
import {namespace} from "vuex-class";

const User = namespace('CurrentUserStore');

@Component({components: {OrangeButton, StringField}})
export default class ConfirmRequestCall extends Mixins(DialogWindowMixin, HttpServiceMixin, AlertMixin, ValidationMixin) {
  @User.State('fullName') fullName!: string;
  @User.State('phoneNumber') phoneNumber!: string;
  
  localData: RequestCall = {
    name: '',
    phoneNumber: '',
    comment: '',
  }
  
  mounted() {
    this.localData.name = this.fullName;
    this.localData.phoneNumber = this.phoneNumber;
  }

  async requestCall() {
    const hasErrors = this.hasErrors();

    if (hasErrors) return;

    await this.requestCallService.CreateRequest(this.localData)
        .then(() => {
          this.callAlert({
            message: 'Обратный звонок был отправлен',
            delay: 7000,
            isError: false
          });
          this.toggleRegisterWindow(false)
        })
        .catch(error => {
          this.callAlert({
            message: this.getErrorMessage(error),
            delay: 7000,
            isError: true
          })
        })
  }

  hasErrors() {
    return this.validateComponent();
  }
}
</script>
<style scoped lang="scss">
.questionnaire {
  background: linear-gradient(0deg, #002C58, #002C58);
  box-shadow: -12px 15px 79px rgba(57, 78, 112, 0.06);

  .contact-section {
    height: 100%;
    width: 100%;
    padding: 1em 1.5em 1.5em;

    h5 {
      font-family: Raleway, sans-serif;
      font-style: normal;
      font-weight: bold;
      font-size: 1em;
      letter-spacing: 0.2em;
      padding-bottom: 0.5em;
    }

    ul {
      li {
        font-family: Montserrat, sans-serif;
        font-style: normal;
        font-weight: normal;
        font-size: 1em;
        color: rgba(255, 255, 255, 0.76);
        letter-spacing: 0.035em;
      }
    }
  }

  .call-request {
    background: linear-gradient(0deg, #FFFFFF, #FFFFFF);
    height: 100%;
    width: 100%;
    padding: 1.5em 5em 2em 2em;

    h5 {
      font-family: Raleway, sans-serif;
      font-style: normal;
      font-weight: bold;
      font-size: 1em;
      letter-spacing: 0.5em;
      padding-bottom: 0.9em;

      color: #000000;
    }
  }
}
</style>