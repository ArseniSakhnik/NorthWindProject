<template>
  <div>
    <v-container fluid style="padding: 0">
      <v-container fluid class="purchase-section">
        <v-row>
          <v-col
              cols="12"
              md="6"
          >
            <h1 class="text-center">Заявка на откачку жидких бытовых отходов</h1>
            <personal-information-info
                ref="personalInformationInfo"
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
    <action-bar
        :is-disabled="isSendButtonDisabled"
        @send="sendPurchase"
    />
  </div>
</template>

<script lang="ts">
import {Vue, Component, Watch, Mixins, Ref} from 'vue-property-decorator'
import {PurchaseToVacuumTruckFizIndividualDto} from "@/services/PurchaseService/Requests"
import YandexMap from "@/components/YMaps/YandexMap.vue"
import PriceFields from "@/components/PriceFields/PriceFields.vue";
import PersonalInformationInfo from "@/components/FieldSections/PersonalInformationInfo.vue";
import PassportInformation from "@/components/FieldSections/PassportInformation.vue";
import VacuumTruckPurchaseInfo from "@/components/FieldSections/VacuumTruckPurchaseInfo.vue";
import ActionBar from "@/components/ActionBars/ActionBar.vue";
import HttpServiceMixin from "@/mixins/HttpServiceMixin.vue";
import {namespace} from "vuex-class";

const Alert = namespace('AlertStore')

@Component({
  components: {
    VacuumTruckPurchaseInfo,
    PassportInformation,
    PriceFields,
    YandexMap,
    PersonalInformationInfo,
    ActionBar
  }
})
export default class CreateVacuumTruckFizPurchase extends Mixins(HttpServiceMixin) {
  @Ref('personalInformationInfo') personalInformationInfo!: any;
  @Alert.Action('CALL_ALERT') callAlert!: (data: { message: string, delay: number }) => void; 
  
  isSendButtonDisabled: boolean = false;

  localData: PurchaseToVacuumTruckFizIndividualDto = {
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

  async sendPurchase() {
    this.isSendButtonDisabled = true;
    const hasErrors = this.validate();
    // if (!hasErrors) {
    //  
    // }

    if (hasErrors) return;

    await this.purchaseService.SendVacuumTruckFizPurchase(this.localData)
        .then(() => {
          this.$router.push('/');
          this.callAlert({
            message: 'Ваша заявка была отправлена',
            delay: 20000
          });
        })
        .finally(() => this.isSendButtonDisabled = false);

    // console.log(hasErrors);
    // if (hasErrors) {
    //   await this.purchaseService.SendVacuumTruckFizPurchase(this.localData)
    //       .then(() => {
    //         console.log('todo')
    //       })
    //       .finally(() => this.isSendButtonDisabled = false);
    // }
  }

  validate(): boolean {
    return this.personalInformationInfo.validateComponent();
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
