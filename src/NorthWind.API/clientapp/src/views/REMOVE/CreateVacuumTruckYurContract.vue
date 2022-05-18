<template>
  <div>
    <v-container fluid style="padding: 0">
      <v-row>
        <v-col
            cols="12"
            md="6"
        >
          <h1 class="text-center">Заявка на откачку жидких бытовых отходов</h1>
          <personal-information-info
              ref="personalInformationInfoRef"
              :email.sync="localData.email"
              :middleName.sync="localData.middleName"
              :name.sync="localData.name"
              :phoneNumber.sync="localData.phoneNumber"
              :surname.sync="localData.surname"
          />
          <v-expansion-panels>
            <v-expansion-panel>
              <v-expansion-panel-header>
                Я ознакомился с персональными данными (ссылка)
              </v-expansion-panel-header>
              <v-expansion-panel-content>
                <individual-entrepreneur-info
                    :i-n-n.sync="localData.iNN"
                    :individual-entrepreneur-short-name.sync="localData.clientShortName"
                    :k-p-p.sync="localData.kPP"
                    :legalAddress.sync="localData.legalAddress"
                    :o-g-r-n.sync="localData.oGRN"
                />
              </v-expansion-panel-content>
            </v-expansion-panel>
          </v-expansion-panels>
          <vacuum-truck-contract-info
              :price="localData.price"
              :territory-address="localData.territoryAddress"
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
    <action-bar
        :is-disabled="isSendButtonDisabled"
        @send="sendContract"
    />
  </div>
</template>

<script lang="ts">
import {Component, Mixins, Ref} from "vue-property-decorator";
import {VacuumTruckYurContractDto} from "@/services/ContractService/Requests";
import PersonalInformationInfo from "@/components/FieldSections/PersonalInformationInfo.vue";
import VacuumTruckContractInfo from "@/components/FieldSections/VacuumTruckContractInfo.vue";
import IndividualEntrepreneurInfo from "@/components/FieldSections/IndividualEntrepreneurInfo.vue";
import YandexMap from "@/components/YMaps/YandexMap.vue";
import ActionBar from "@/components/ActionBars/ActionBar.vue";
import HttpServiceMixin from "@/mixins/HttpServiceMixin.vue";
import {namespace} from "vuex-class";

const Alert = namespace('AlertStore')


@Component({
  components: {
    PersonalInformationInfo,
    VacuumTruckContractInfo,
    IndividualEntrepreneurInfo,
    YandexMap,
    ActionBar
  }
})
export default class CreateVacuumTruckYurContract extends Mixins(HttpServiceMixin) {
  @Ref('personalInformationInfoRef') personalInformationInfoRef!: any;
  @Alert.Action('CALL_ALERT') callAlert!: (data: { message: string, delay: number }) => void;
  isSendButtonDisabled: boolean = false;

  localData: VacuumTruckYurContractDto = {
    actsOnBasis: "",
    clientShortName: "",
    email: "",
    iNN: "",
    kPP: "",
    legalAddress: "",
    middleName: "",
    name: "",
    oGRN: "",
    personalNameEntrepreneur: "",
    phoneNumber: "",
    price: 0,
    priceString: "",
    surname: "",
    territoryAddress: ""
  }

  async sendContract() {
    const hasErrors = this.validate();

    if (hasErrors) return;

    this.isSendButtonDisabled = true;

    await this.contractService.SendVacuumTruckYurContract(this.localData)
        .then(() => {
          this.$router.push('/');
          this.callAlert({
            message: 'Ваша заявка была отправлена',
            delay: 20000
          });
        })
        .finally(() => this.isSendButtonDisabled = false);

  }

  validate(): boolean {
    return this.personalInformationInfoRef.validateComponent();
  }


  calculate(routeLength: number) {
    return routeLength;
  }
}
</script>
<style lang="scss" scoped>
.yandex-map {
  height: 100%;
  width: 100%;
}
</style>
