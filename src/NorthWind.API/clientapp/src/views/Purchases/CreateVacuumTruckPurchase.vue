<template>
  <div>
    <div class="background-image">

    </div>
    <section class="purchase-section">
      <h1 class="text-center">Заявка на вакуум трак</h1>
      <full-name-fields
      />
      <passport-fields
          :passport-serial-number.sync="localData.passportSerialNumber"
          :passport-number.sync="localData.passportNumber"
          :passport-issued.sync="localData.passportIssued"
          :passport-issue-date.sync="localData.passportIssueDate"
          :passport-division-number.sync="localData.passportDivisionNumber"
      />
    </section>
  </div>
</template>

<script lang="ts">
import {Vue, Component} from 'vue-property-decorator'
import {PurchaseToVacuumTruckIndividualDto} from "@/services/PurchaseService/Requests"
import YandexMap from "@/components/YMaps/YMaps.vue"
import FullNameFields from "@/components/Fields/FullNameFields.vue";
import PassportFields from "@/components/Fields/PassportFields.vue";


@Component({components: {PassportFields, FullNameFields, YMaps: YandexMap}})
export default class CreateVacuumTruckPurchase extends Vue {

  private name: string = ''
  private surname: string = ''
  private patronymic: string = ''

  private localData: PurchaseToVacuumTruckIndividualDto = {
    email: '',
    fullName: this.fullName,
    passportIssued: '',
    passportIssueDate: '',
    passportNumber: '',
    passportSerialNumber: '',
    passportDivisionNumber: '',
    phoneNumber: '',
    priceNumber: 0,
    registrationAddress: '',
    territoryAddress: ''
  }

  private get fullName(): string {
    return `${this.name} + ${this.surname} + ${this.patronymic};`
  }

}
</script>
<style scoped lang="scss">
.background-image {
  background-image: url('../../assets/purchases/vacuumTruck/insignts-1-1192699.jpg');
  position: relative;
  background-blend-mode: multiply;
  background-position: center bottom;
  background-color: rgba(#1b3648, 0.35);
  background-size: cover;
  background-repeat: no-repeat;
  width: 100%;
  height: 15vh;
}

.purchase-section {
  padding: 2vw 7vw;
}

.input-field {
  width: 20vw;
}
</style>
