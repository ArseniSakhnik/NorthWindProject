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
          >
            Выбор места и расчет приблизительной стоимости
          </v-stepper-step>
          <v-stepper-content :step="3" ref="priceBlock">
            <calculate-assenizator
                v-if="serviceType === 1"
                :distance-from-driveway="localData.distanceFromDriveway"
                :place.sync="localData.place"
            />
            <calculate-k-g-o
                v-else-if="serviceType === 2"
                :place.sync="localData.place"
                :planned-waste-volume="localData.plannedWasteVolume"
            />
          </v-stepper-content>
        </v-stepper>
      </v-card-text>
      <v-card-actions>
        <v-btn @click="currentStep--" :disabled="currentStep === 1">
          Назад
        </v-btn>
        <v-btn
            color="primary"
            @click="nextStep"
        >
          Далее
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


@Component({
  components: {
    CalculateKGO,
    CalculateAssenizator,
    AssenizatorPurchase,
    PersonalInformationInfo,
    KGOPurchase
  }
})
export default class PurchaseDialog extends Mixins(DialogWindowMixin, ValidationMixin) {
  @Ref('personalInformationInfo') personalInformationInfoRef!: any;
  @Ref('serviceBlock') serviceBlock!: any;
  @Ref('priceBlock') priceBlock!: any;
  @Prop() serviceType!: ServiceTypeEnum;

  currentStep: number = 1;

  localData: BasePurchaseDto | AssenizatorPurchaseDto | KGODto | KDMDto = {
    email: "",
    middleName: "",
    name: "",
    phoneNumber: "",
    place: "",
    surname: "",
    comment: "",
  }

  nextStep() {
    const hasErrors = this.hasErrors;
    if (!hasErrors) {
      this.currentStep++;
    }
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
  
  @Watch('serviceType')
  serviceTypeChangeHandler(value: ServiceTypeEnum) {
    console.log(value)
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
</style>
