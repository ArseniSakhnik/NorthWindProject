<template>
  <div>
    <v-container fluid style="padding: 0">
      <v-row>
        <v-col
            cols="12"
            md="6"
        >
          <h1 class="text-center">Заявка на вывоз строительного и крупногабаритного мусора</h1>
          <personal-information-info
              :email.sync="localData.email"
              :phoneNumber.sync="localData.phoneNumber"
              :name.sync="localData.name"
              :surname.sync="localData.surname"
              :middleName.sync="localData.middleName"
          />
          <individual-entrepreneur-info
              :individual-entrepreneur-short-name.sync="localData.individualEntrepreneurShortName"
              :i-n-n.sync="localData.iNN"
              :k-p-p.sync="localData.kPP"
              :legalAddress.sync="localData.legalAddress"
              :o-g-r-n.sync="localData.oGRN"
          />
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
  </div>
</template>

<script lang="ts">
import {Vue, Component} from "vue-property-decorator";
import {PurchaseToVacuumTruckYurIndividualDto} from "@/services/PurchaseService/Requests";
import PersonalInformationInfo from "@/components/FieldSections/PersonalInformationInfo.vue";
import VacuumTruckPurchaseInfo from "@/components/FieldSections/VacuumTruckPurchaseInfo.vue";
import IndividualEntrepreneurInfo from "@/components/FieldSections/IndividualEntrepreneurInfo.vue";
import YandexMap from "@/components/YMaps/YandexMap.vue";


@Component({components: {PersonalInformationInfo, VacuumTruckPurchaseInfo, IndividualEntrepreneurInfo, YandexMap}})
export default class CreateVacuumTruckYurPurchase extends Vue {
  localData: PurchaseToVacuumTruckYurIndividualDto = {
    act: 0,
    iNN: "",
    individualEntrepreneurShortName: "",
    kPP: "",
    legalAddress: "",
    oGRN: "",
    phoneNumber: "",//
    surname: "",//
    name: "",//
    email: "",//
    middleName: "",//
    territoryAddress: "",//
    price: 0,//
    contractValidDate: "",//
  }

  calculate(routeLength: number) {
    return routeLength;
  }
}
</script>
<style scoped lang="scss">
.yandex-map {
  height: 100%;
  width: 100%;
}
</style>
