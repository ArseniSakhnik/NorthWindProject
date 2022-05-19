<template>
  <v-container>
    <fiz-contract-part
        :local-data.sync="localData"
        :is-view="isView"
    />
    <place-picker
        :local-data.sync="localData"
        :is-view="isView"
    />
    <action-card-bar
        v-if="!noActionBar"
        @send="createVacuumTruckFizContract"
        @cancel="back"
    />
  </v-container>
</template>

<script lang="ts">
import {Vue, Component, Mixins, Prop} from "vue-property-decorator";
import {VacuumTruckFizContract} from "@/services/ContractService/Requests";
import FizContractPart from "@/components/Contracts/ContractPart/FizContractPart.vue";
import PlacePicker from "@/components/Contracts/ContractPart/PlacePicker.vue";
import ActionCardBar from "@/components/Contracts/ContractPart/ActionCardBar.vue";
import HttpServiceMixin from "@/mixins/HttpServiceMixin.vue";
import {namespace} from "vuex-class";

const Alert = namespace('AlertStore')

@Component({components: {ActionCardBar, PlacePicker, FizContractPart}})
export default class CreateVacuumTruckFizContract extends Mixins(HttpServiceMixin) {
  @Alert.Action('CALL_ALERT') callAlert!: (alertData: any) => void;
  @Prop({required: false, default: () => false}) isView!: boolean;
  @Prop({required: false, default: () => false}) noActionBar!: boolean;
  
  @Prop({
    required: false, default: () => ({
      email: '',
      individualFullName: '',
      phoneNumber: '',
      placeName: ''
    })
  }) localData!: VacuumTruckFizContract;

  async createVacuumTruckFizContract() {
    const alertData = {
      message: 'Контракт был отправлен',
      delay: 7000,
      isError: false
    };

    await this.contractService.CreateVacuumTruckFizContract(this.localData)
        .then(() => {
          this.callAlert(alertData)
          this.$router.push('/user-contracts')
        })
        .catch(error => {
          alertData.message = this.getErrorMessage(error);
          alertData.isError = true;
          this.callAlert(alertData);
        })
  }

  back() {
    this.$router.back();
  }
}
</script>
<style scoped lang="scss">

</style>
