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
              :middleName.sync="localData.middleName"
              :name.sync="localData.name"
              :phone-number-or-fax="localData.phoneNumberOrFax"
              :phoneNumber.sync="localData.phoneNumber"
              :surname.sync="localData.surname"
          />
          <individual-entrepreneur-info
              :client-company.sync="localData.clientCompany"
              :i-n-n.sync="localData.iNN"
              :individual-entrepreneur-short-name.sync="localData.fullNameClient"
              :k-p-p.sync="localData.kPP"
              :legalAddress.sync="localData.legalAddress"
              :o-g-r-n.sync="localData.oGRN"
              :o-k-p-o="localData.oKPO"
          />
          <kgo-contract-info
              :act-on-the-basis.sync="localData.actOnTheBasis"
              :coast-price.sync="localData.coastPrice"
              :contract-valid-date.sync="localData.contractValidDate"
              :end-date.sync="localData.endDate"
              :end-time.sync="localData.endDate"
              :start-date.sync="localData.startDate"
              :start-time.sync="localData.startTime"
              :vehicles-number.sync="localData.vehiclesNumber"
              :volume.sync="localData.volume"
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
import {Component, Vue} from "vue-property-decorator";
import {KGOYurContractDto} from "@/services/ContractService/Requests";
import PersonalInformationInfo from "@/components/FieldSections/PersonalInformationInfo.vue";
import IndividualEntrepreneurInfo from "@/components/FieldSections/IndividualEntrepreneurInfo.vue";
import YandexMap from "@/components/YMaps/YandexMap.vue";
import KgoContractInfo from "@/components/FieldSections/KgoContractInfo.vue";


@Component({components: {PersonalInformationInfo, IndividualEntrepreneurInfo, KgoContractInfo, YandexMap}})
export default class CreateKgoContract extends Vue {
  localData: KGOYurContractDto = {
    actOnTheBasis: 0,
    coastPrice: "",
    contractValidDate: "",
    endDate: "",
    endTime: "",
    startDate: "",
    startTime: "",
    vehiclesNumber: 0,
    volume: "",

    phoneNumberOrFax: "",//
    clientCompany: "",//
    oKPO: "",//
    customerContactPersonAndJobTitle: "",//
    fullNameClient: "",//
    price: 0,//
    territoryAddress: "",//
    legalAddress: "", //
    machineReload: "",
    middleName: "", //
    name: "", //
    oGRN: "", //
    surname: "", //
    phoneNumber: "", //
    iNN: "", //
    kPP: "", //
    email: "", //

  }

  calculate(routeLength: number) {
    return routeLength;
  }
}
</script>
<style lang="scss" scoped>

</style>
