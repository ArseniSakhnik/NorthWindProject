<template>
  <v-dialog
      ref="dialogRef"
      @click:outside="toggleRegisterWindow(false)"
      scrollable
      persistent
  >
    <v-card>
      <v-card-title>
        <h2>{{ serviceTitle }}</h2>
      </v-card-title>
      <v-card-text>
        <v-stepper
            v-model="currentStep"
            vertical
            outlined
        >
          <v-stepper-step
              :complete="currentStep > 1"
              :step="1"
              color="orange darken-3"
          >
            Заполнение персональных данных
          </v-stepper-step>
          <v-stepper-content :step="1">
            <personal-information-info
                ref="personalInformationInfo"
                :email.sync="localData.email"
                :middleName.sync="localData.middleName"
                :name.sync="localData.name"
                :phoneNumber.sync="localData.phoneNumber"
                :surname.sync="localData.surname"
            />
          </v-stepper-content>


          <v-stepper-step
              :complete="currentStep > 2"
              :step="2"
              color="orange darken-3"
          >
            Данные по анкете
          </v-stepper-step>
          <v-stepper-content :step="2" ref="serviceBlock">
            <assenizator-purchase
                v-if="serviceType === 1"
                :waste-type.sync="localData.wasteType"
                :pit-volume.sync="localData.pitVolume"
                :distance-from-driveway.sync="localData.distanceFromDriveway"
            />
            <k-g-o-purchase
                v-else-if="serviceType === 2"
                :planned-waste-volume="localData.plannedWasteVolume"
            />
          </v-stepper-content>


          <v-stepper-step
              :complete="currentStep > 3"
              :step="3"
              color="orange darken-3"
          >
            Выбор места и расчет приблизительной стоимости
          </v-stepper-step>
          <v-stepper-content :step="3" ref="priceBlock">
            <calculate-assenizator
                v-if="serviceType === 1"
                :distance-from-driveway="localData.distanceFromDriveway"
                :place.sync="localData.place"
                :comment.sync="localData.comment"
            />
            <calculate-k-g-o
                v-else-if="serviceType === 2"
                :place.sync="localData.place"
                :planned-waste-volume="localData.plannedWasteVolume"
                :comment.sync="localData.comment"
            />
          </v-stepper-content>
        </v-stepper>
      </v-card-text>
      <v-card-actions>
        <v-btn @click="currentStep--" :disabled="currentStep === 1">
          Назад
        </v-btn>
        <v-btn
            color="orange darken-3"
            @click="nextStep"
            style="color: white"
        >
          {{ nextButtonTitle }}
        </v-btn>
      </v-card-actions>
    </v-card>
  </v-dialog>
</template>

<script lang="ts">
import {Component, Mixins, Prop, Ref, Watch} from "vue-property-decorator";
import DialogWindowMixin from "@/mixins/DialogWindowMixin.vue";
import AssenizatorPurchase from "@/components/Purchase/AssenizatorPurchase.vue";
import PersonalInformationInfo from "@/components/FieldSections/PersonalInformationInfo.vue";
import {AssenizatorPurchaseDto, BasePurchaseDto, KDMDto, KGODto} from "@/services/PurchaseService/Requests";
import {ServiceTypeEnum, WasteType} from "@/enums/Enums";
import CalculateAssenizator from "@/components/Calculate/CalculateAssenizator.vue";
import ValidationMixin from "@/mixins/ValidationMixin.vue";
import KGOPurchase from "@/components/Purchase/KGOPurchase.vue";
import CalculateKGO from "@/components/Calculate/CalculateKGO.vue";
import StringField from "@/components/Fields/StringField.vue";
import HttpServiceMixin from "@/mixins/HttpServiceMixin.vue";
import {namespace} from "vuex-class";

const Alert = namespace('AlertStore');

@Component({
  components: {
    StringField,
    CalculateKGO,
    CalculateAssenizator,
    AssenizatorPurchase,
    PersonalInformationInfo,
    KGOPurchase
  }
})
export default class PurchaseDialog extends Mixins(DialogWindowMixin, ValidationMixin, HttpServiceMixin) {
  @Ref('personalInformationInfo') personalInformationInfoRef!: any;
  @Ref('serviceBlock') serviceBlock!: any;
  @Ref('priceBlock') priceBlock!: any;
  @Prop() serviceType!: ServiceTypeEnum;
  @Alert.Action('CALL_ALERT') callAlert!: (data: { message: string, delay: number }) => void;

  currentStep: number = 1;
  errorMessage: string = '';

  localData: BasePurchaseDto | AssenizatorPurchaseDto | KGODto | KDMDto = {
    email: "",
    middleName: "",
    name: "",
    phoneNumber: "",
    place: "",
    surname: "",
    comment: "",
  }

  async nextStep() {
    const hasErrors = this.hasErrors;

    if (!hasErrors && this.currentStep === 3) {
      await this.sendPurchase();
      return;
    }

    if (!hasErrors) {
      this.currentStep++;
    }
  }

  async sendPurchase() {
    await this.purchaseService.createPurchase(this.serviceType, this.localData)
        .then(response => {
          const alertData = {
            message: response.data,
            delay: 7000
          };
          this.callAlert(alertData)
          this.toggleRegisterWindow(false)
        })
        .catch(error => {
          this.errorMessage = this.getErrorMessage(error);
          window.alert(this.errorMessage);
        });
  }

  get hasErrors() {
    switch (this.currentStep) {
      case 1:
        return this.personalInformationInfoRef.validateComponent();
      case 2:
        return this.serviceBlock.$children[0].validateComponent ? this.serviceBlock.$children[0].validateComponent() : false;
      case 3:
        return this.priceBlock.$children[0].validateComponent ? this.priceBlock.$children[0]?.validateComponent() : false;
    }
  }

  get serviceTitle() {
    switch (this.serviceType) {
      case 1:
        return 'Заявка на откачку жидких бытовых отходов';
      case 2:
        return 'Заявка на вывоз строительного и крупногабаритного мусора';
      case 3:
        return 'В разработке'
    }
  }

  get nextButtonTitle() {
    return this.currentStep === 3 ? 'Отправить' : 'Далее';
  }

  @Watch('serviceType')
  serviceTypeChangeHandler(value: ServiceTypeEnum) {
    switch (value) {
      case ServiceTypeEnum.Assenizator:
        this.localData = {
          ...this.localData,
          wasteType: WasteType.cessPool,
          pitVolume: 0,
          distanceFromDriveway: 0
        };
        break;
      case ServiceTypeEnum.KGO:
        this.localData = {
          ...this.localData,
          plannedWasteVolume: 0,
          distanceFromDriveway: 0
        };
        break;
      case ServiceTypeEnum.WaterCleaning:
        this.localData = {
          ...this.localData,
          //todo доделать
        }
    }
  }

}
</script>
<style scoped lang="scss">
h2 {
  font-family: "Raleway", "serif";
  font-style: normal;
  font-weight: 800;
  font-size: 1em;
}

span {
  background-color: #ff782e !important;
  border-color: #ff782e !important;
}


</style>
