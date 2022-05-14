<template>
  <v-dialog
      ref="dialogRef"
      persistent
      @click:outside="toggleRegisterWindow(false)"
      scrollable
  >
    <v-card>
      <v-card-title>
        <v-tabs
            background-color="orange lighten-1 accent-4"
            fixed-tabs
            dark
            v-model="currentTab"
        >
          <v-tab>Анкета</v-tab>
          <v-tab>Расчет стоимости</v-tab>
        </v-tabs>
      </v-card-title>
      <v-card-text>
        <personal-information-info
            ref="personalInformationInfo"
            :email.sync="localData.email"
            :middleName.sync="localData.middleName"
            :name.sync="localData.name"
            :phoneNumber.sync="localData.phoneNumber"
            :surname.sync="localData.surname"
        />
        <assenizator-purchase
            ref="assenizatorPurchase"
            :waste-type.sync="localData.wasteType"
            :pit-volume.sync="localData.pitVolume"
            :distance-from-driveway.sync="localData.distanceFromDriveway"
        />
      </v-card-text>
    </v-card>
  </v-dialog>
</template>

<script lang="ts">
import {Component, Mixins, Prop} from "vue-property-decorator";
import DialogWindowMixin from "@/mixins/DialogWindowMixin.vue";
import AssenizatorPurchase from "@/components/Purchase/AssenizatorPurchase.vue";
import PersonalInformationInfo from "@/components/FieldSections/PersonalInformationInfo.vue";
import {AssenizatorPurchaseDto, BasePurchaseDto, KDMDto, KGODto} from "@/services/PurchaseService/Requests";
import {ServiceTypeEnum, WasteType} from "@/enums/Enums";


@Component({components: {AssenizatorPurchase, PersonalInformationInfo}})
export default class PurchaseDialog extends Mixins(DialogWindowMixin) {
  @Prop() serviceType!: ServiceTypeEnum;

  currentTab: number = 0;

  localData: BasePurchaseDto | AssenizatorPurchaseDto | KGODto | KDMDto = {
    email: "",
    middleName: "",
    name: "",
    phoneNumber: "",
    place: "",
    surname: "",
    comment: "",
  }

  created() {
    switch (this.serviceType) {
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

</style>
