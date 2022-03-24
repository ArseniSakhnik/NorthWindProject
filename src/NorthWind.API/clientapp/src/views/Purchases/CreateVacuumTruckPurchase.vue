<template>
  <div>
    <v-container fluid style="padding: 0">
      <v-container fluid class="purchase-section">
        <v-row>
          <v-col
              cols="12"
              md="6"
          >
            <h1 class="text-center">Заявка на вакуум трак</h1>
            <personal-information-info
                :email.sync="localData.email"
                :phoneNumber.sync="localData.phoneNumber"
                :name.sync="localData.name"
                :surname.sync="localData.surname"
                :middleName.sync="localData.middleName"
            />
            <!--            <full-name-fields-->
            <!--                :name.sync="localData.name"-->
            <!--                :surname.sync="localData.surname"-->
            <!--                :middle-name.sync="localData.middleName"-->
            <!--                :phone-number.sync="localData.phoneNumber"-->
            <!--                :email.sync="localData.email"-->
            <!--            />-->
            <!--            <passport-fields-->
            <!--                :passport-serial-number.sync="localData.passportSerialNumber"-->
            <!--                :passport-number.sync="localData.passportNumber"-->
            <!--                :passport-issued.sync="localData.passportIssued"-->
            <!--                :passport-issue-date.sync="localData.passportIssueDate"-->
            <!--                :passport-division-number.sync="localData.passportDivisionNumber"-->
            <!--                :registration-address.sync="localData.registrationAddress"-->
            <!--            />-->
            <!--            <price-fields-->
            <!--                :distance="localData.distance"-->
            <!--                :price="priceNumber"-->
            <!--            />-->
          </v-col>
          <v-col
              cols="12"
              md="6"
          >
            <!--            <div class="yandex-map">-->
            <!--              <yandex-map-->
            <!--                  :calculate-function="calculate"-->
            <!--                  :distance.sync="localData.distance"-->
            <!--                  :price-number.sync="priceNumber"-->
            <!--              />-->
            <!--            </div>-->
          </v-col>
        </v-row>
      </v-container>
    </v-container>
  </div>
</template>

<script lang="ts">
import {Vue, Component, Watch} from 'vue-property-decorator'
import {PurchaseToVacuumTruckIndividualDto} from "@/services/PurchaseService/Requests"
import YandexMap from "@/components/YMaps/YandexMap.vue"
import PriceFields from "@/components/PriceFields/PriceFields.vue";
import PersonalInformationInfo from "@/components/FieldSections/PersonalInformationInfo.vue";

@Component({components: {PriceFields, YandexMap, PersonalInformationInfo}})
export default class CreateVacuumTruckPurchase extends Vue {

  private priceNumber: number = 0;

  localData: PurchaseToVacuumTruckIndividualDto = {
    contractValidDate: "",
    divisionCode: "",
    email: "",
    middleName: "",
    name: "",
    passportId: "",
    passportIssueDate: "",
    passportIssued: "",
    passportSerialNumber: "",
    phoneNumber: "",
    price: "",
    registrationAddress: "",
    surname: "",
    territoryAddress: ""
  }

  calculate(routeLength: number): number {
    return 2500 + 50 * routeLength + 500;
  }
}
</script>
<style scoped lang="scss">

.purchase-section {
  padding-top: 4vh;
}

.input-field {
  width: 20vw;
}

.yandex-map {
  height: 100%;
  width: 100%;
}
</style>
