<template>
  <v-row class="questionnaire">
    <v-col
        class="contact-section"
        cols="12"
        md="5"
    >
      <h5 class="text-white">Контакты</h5>
      <ul>
        <li>ул. Буденного д.32, литера "Ф",
          г. Симферополь
        </li>
        <li>+7 (978) 024-30-06
          +7 (978) 024-30-07
        </li>
        <li>northwind82@bk.ru</li>
      </ul>
    </v-col>
    <v-col
        class="call-request"
        cols="12"
        md="7"
    >
      <h5>ЗАКАЗАТЬ ЗВОНОК</h5>
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
      <orange-button
          title="Отправить"
          @action="requestCall"
      />
    </v-col>
  </v-row>
</template>

<script lang="ts">
import {Component, Mixins, Vue} from "vue-property-decorator";
import OrangeButton from "@/components/Buttons/OrangeButton.vue";
import {RequestCall} from "@/services/RequestCallService/Request";
import HttpServiceMixin from "@/mixins/HttpServiceMixin.vue";
import AlertMixin from "@/mixins/AlertMixin.vue";
import ValidationMixin from "@/mixins/ValidationMixin.vue";
import StringField from "@/components/Fields/StringField.vue";
import {namespace} from "vuex-class";

const User = namespace('CurrentUserStore');

@Component({
  components: {OrangeButton, StringField}
})
export default class ContactUsSection extends Mixins(HttpServiceMixin, AlertMixin, ValidationMixin) {
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
          this.localData.name = '';
          this.localData.phoneNumber = '';
          this.localData.comment = '';
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
<style lang="scss" scoped>
.questionnaire {
  background: linear-gradient(0deg, #002C58, #002C58);
  box-shadow: -12px 15px 79px rgba(57, 78, 112, 0.06);

  .contact-section {
    height: 100%;
    width: 100%;
    padding: 0.5em 1em 1em;

    h5 {
      font-family: Raleway, sans-serif;
      font-style: normal;
      font-weight: bold;
      font-size: 0.5em;
      letter-spacing: 0.1em;
      padding-bottom: 0.4em;
    }

    ul {
      li {
        font-family: Montserrat, sans-serif;
        font-style: normal;
        font-weight: normal;
        font-size: 0.3em;
        color: rgba(255, 255, 255, 0.76);
        letter-spacing: 0.035em;
      }
    }
  }

  .call-request {
    background: linear-gradient(0deg, #FFFFFF, #FFFFFF);
    height: 100%;
    width: 100%;
    padding: 0.5em 4em 1em 1em;

    h5 {
      font-family: Raleway, sans-serif;
      font-style: normal;
      font-weight: bold;
      font-size: 0.5em;
      letter-spacing: 0.1em;
      padding-bottom: 0.4em;

      color: #000000;
    }
  }
}


</style>
