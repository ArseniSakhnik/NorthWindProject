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
                      :division-code.sync="localData.divisionCode"
                      :registration-address.sync="localData.registrationAddress"
                  />
                </v-expansion-panel-content>
              </v-expansion-panel>
            </v-expansion-panels>
            
            <vacuum-truck-purchase-info
              :territory-address="localData.territoryAddress"
              :contract-valid-date="localData.contractValidDate"
              :price="localData.price"
            />
          </v-col>
          <v-col
              cols="12"
              md="6"
          >
            <div class="yandex-map">
              <yandex-map
                  :calculate-function="calculate"
                  :price-number.sync="localData.price"
                  :territory-address.sync="localData.territoryAddress"
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
import VacuumTruckPurchaseInfo from "@/components/FieldSections/VacuumTruckPurchaseInfo.vue";

@Component({components: {VacuumTruckPurchaseInfo, PassportInformation, PriceFields, YandexMap, PersonalInformationInfo}})
export default class CreateVacuumTruckFizPurchase extends Vue {
  
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
    divisionCode: "", //
    registrationAddress: "",//
    
    territoryAddress: "",//
    contractValidDate: "", //
    
    price: 0, //
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
