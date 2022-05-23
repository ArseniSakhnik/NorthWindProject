<template>
  <v-dialog
      ref="dialogRef"
      @click:outside="toggleRegisterWindow(false)"
      scrollable
      persistent
  >
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
        <v-text-field
            label="Ваше имя"
            v-model="localData.name"
            dense
            outlined
        />
        <v-text-field
            v-model="localData.phoneNumber"
            v-mask="'(###) ###-##-##'"
            dense
            label="Номер телефона"
            outlined
            prefix="+7"
        />
        <v-text-field
            v-model="localData.comment"
            label="Сообщение или дополнительная информация"
            outlined
            dense
        />
        <orange-button
            title="Отправить"
            @action="requestCall"
        />
      </v-col>
    </v-row>
  </v-dialog>
</template>

<script lang="ts">
import {Vue, Component, Mixins} from "vue-property-decorator";
import OrangeButton from "@/components/Buttons/OrangeButton.vue";
import DialogWindowMixin from "@/mixins/DialogWindowMixin.vue";
import {RequestCall} from "@/services/RequestCallService/Request";
import HttpServiceMixin from "@/mixins/HttpServiceMixin.vue";
import AlertMixin from "@/mixins/AlertMixin.vue";


@Component({components: {OrangeButton}})
export default class ConfirmRequestCall extends Mixins(DialogWindowMixin, HttpServiceMixin, AlertMixin) {
  localData: RequestCall = {
    comment: '',
    name: '',
    phoneNumber: ''
  }

  async requestCall() {
    await this.requestCallService.CreateRequest(this.localData)
        .then(() => {
          this.callAlert({
            message: 'Обратный звонок был отправлен',
            delay: 7000,
            isError: false
          });
        })
        .catch(error => {
          this.callAlert({
            message: this.getErrorMessage(error),
            delay: 7000,
            isError: true
          })
        })
  }
}
</script>
<style scoped lang="scss">

</style>