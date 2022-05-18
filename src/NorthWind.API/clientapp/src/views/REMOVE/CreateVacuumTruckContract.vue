<template>
  <div>
    <v-container fluid style="padding: 0">
      <v-container class="contract-section" fluid>
        <v-row>
          <v-col
              cols="12"
              md="6"
          >
            <h1 class="text-center">Заявка на откачку жидких бытовых отходов</h1>
            <personal-information-info
                ref="personalInformationInfo"
                :email.sync="localData.email"
                :middleName.sync="localData.middleName"
                :name.sync="localData.name"
                :phoneNumber.sync="localData.phoneNumber"
                :surname.sync="localData.surname"

            />
            <v-expansion-panels>
              <v-expansion-panel>
                <v-expansion-panel-header>Я ознакомился с персональными данными (ссылка)</v-expansion-panel-header>
                <v-expansion-panel-content>
                  <passport-information
                      :division-code.sync="localData.divisionCode"
                      :passport-id.sync="localData.passportId"
                      :passport-issue-date.sync="localData.passportIssueDate"
                      :passport-issued.sync="localData.passportIssued"
                      :passport-serial-number.sync="localData.passportSerialNumber"
                      :registration-address.sync="localData.registrationAddress"
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
    </v-container>
    <action-bar
        :is-disabled="isSendButtonDisabled"
        @send="sendContract"
    />
  </div>
</template>

<script lang="ts">
import {Component, Mixins, Ref} from 'vue-property-decorator'
import {VacuumTruckFizIndividualContractDto} from "@/services/ContractService/Requests"
import YandexMap from "@/components/YMaps/YandexMap.vue"
import PriceFields from "@/components/PriceFields/PriceFields.vue";
import PersonalInformationInfo from "@/components/FieldSections/PersonalInformationInfo.vue";
import PassportInformation from "@/components/FieldSections/PassportInformation.vue";
import VacuumTruckContractInfo from "@/components/FieldSections/VacuumTruckContractInfo.vue";
import ActionBar from "@/components/ActionBars/ActionBar.vue";
import HttpServiceMixin from "@/mixins/HttpServiceMixin.vue";
import {namespace} from "vuex-class";

const Alert = namespace('AlertStore')

@Component({
  components: {
    VacuumTruckContractInfo,
    PassportInformation,
    PriceFields,
    YandexMap,
    PersonalInformationInfo,
    ActionBar
  }
})
export default class CreateVacuumTruckFizContract extends Mixins(HttpServiceMixin) {
  @Ref('personalInformationInfo') personalInformationInfo!: any;
  @Alert.Action('CALL_ALERT') callAlert!: (data: { message: string, delay: number }) => void;

  isSendButtonDisabled: boolean = false;

  localData: VacuumTruckFizIndividualContractDto = {
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
    price: 0, //
  }

  async sendContract() {
    const hasErrors = this.validate();

    if (hasErrors) return;

    this.isSendButtonDisabled = true;

    await this.contractService.SendVacuumTruckFizContract(this.localData)
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
    return this.personalInformationInfo.validateComponent();
  }

  calculate(routeLength: number): number {
    return 2500 + 50 * routeLength + 500;
  }
}
</script>
<style lang="scss" scoped>

.contract-section {
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
