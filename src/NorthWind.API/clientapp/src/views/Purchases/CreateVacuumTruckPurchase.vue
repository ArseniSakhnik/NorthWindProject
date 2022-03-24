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
            <v-expansion-panels>
              <v-expansion-panel>
                <v-expansion-panel-header>Я ознакомился с персональными данными (ссылка)</v-expansion-panel-header>
                <v-expansion-panel-content>
                  <passport-information
                      :passport-id.sync="localData.passportId"
                      :passport-serial-number.sync="localData.passportSerialNumber"
                      :passport-issued.sync="localData.passportIssued"
                      :passport-issue-date.sync="localData.passportIssueDate"
                  />
                </v-expansion-panel-content>
              </v-expansion-panel>
            </v-expansion-panels>
            
            
          </v-col>
          <v-col
              cols="12"
              md="6"
          >
            <div class="yandex-map">
              <yandex-map
                  :calculate-function="calculate"
                  :distance.sync="localData.distance"
                  :price-number.sync="priceNumber"
              />
            </div>
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
import PassportInformation from "@/components/FieldSections/PassportInformation.vue";

@Component({components: {PassportInformation, PriceFields, YandexMap, PersonalInformationInfo}})
export default class CreateVacuumTruckPurchase extends Vue {

  private priceNumber: number = 0;

  localData: PurchaseToVacuumTruckIndividualDto = {
    email: "", //
    middleName: "", //
    name: "", //
    phoneNumber: "", //
    surname: "", //

    passportId: "", //
    passportIssueDate: "", //
    passportIssued: "", // 
    passportSerialNumber: "", //

    registrationAddress: "",
    territoryAddress: "",
    contractValidDate: "",
    divisionCode: "",
    price: "",

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
