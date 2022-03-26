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
              :phone-number-or-fax="localData.phoneNumberOrFax"
          />
          <individual-entrepreneur-info
              :individual-entrepreneur-short-name.sync="localData.fullNameClient"
              :i-n-n.sync="localData.iNN"
              :k-p-p.sync="localData.kPP"
              :legalAddress.sync="localData.legalAddress"
              :o-g-r-n.sync="localData.oGRN"
              :client-company.sync="localData.clientCompany"
              :o-k-p-o="localData.oKPO"
          />
          <kgo-purchase-info
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
import {Vue, Component} from "vue-property-decorator";
import {PurchaseToKGOYurIndividualDto} from "@/services/PurchaseService/Requests";
import PersonalInformationInfo from "@/components/FieldSections/PersonalInformationInfo.vue";
import IndividualEntrepreneurInfo from "@/components/FieldSections/IndividualEntrepreneurInfo.vue";
import YandexMap from "@/components/YMaps/YandexMap.vue";
import KgoPurchaseInfo from "@/components/FieldSections/KgoPurchaseInfo.vue";


@Component({components: {PersonalInformationInfo, IndividualEntrepreneurInfo, KgoPurchaseInfo, YandexMap}})
export default class CreateKgoPurchase extends Vue {
  localData: PurchaseToKGOYurIndividualDto = {
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
<style scoped lang="scss">

</style>
