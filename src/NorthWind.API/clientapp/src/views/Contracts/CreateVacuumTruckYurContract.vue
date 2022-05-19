<template>
  <v-container>
    <contract-info
        :local-data.sync="localData"
        :is-view="isView"
    />
    <yur-contract-part
        :local-data.sync="localData"
        :is-view="isView"
    />
    <place-picker
        :local-data.sync="localData"
        :is-view="isView"
    />
    <action-card-bar
        v-if="!noActionBar"
        @send="createVacuumTruckYurContract"
        @cancel="back"
    />
  </v-container>
</template>

<script lang="ts">
import {Vue, Component, Mixins, Prop} from "vue-property-decorator";
import {VacuumTruckYurContract} from "@/services/ContractService/Requests";
import YurContractPart from "@/components/Contracts/ContractPart/YurContractPart.vue";
import ContractInfo from "@/components/Contracts/ContractPart/ContractInfo.vue";
import PlacePicker from "@/components/Contracts/ContractPart/PlacePicker.vue";
import ActionCardBar from "@/components/Contracts/ContractPart/ActionCardBar.vue";
import HttpServiceMixin from "@/mixins/HttpServiceMixin.vue";
import {namespace} from "vuex-class";

const Alert = namespace('AlertStore')

@Component({components: {PlacePicker, ContractInfo, YurContractPart, ActionCardBar}})
export default class CreateVacuumTruckContract extends Mixins(HttpServiceMixin) {
  @Alert.Action('CALL_ALERT') callAlert!: (alertData: any) => void;
  @Prop({required: false, default: () => false}) isView!: boolean;
  @Prop({required: false, default: () => false}) noActionBar!: boolean;

  @Prop({
    required: false, default: () => ({
      customerShortName: '',
      email: '',//
      iEShortName: '', //
      iNN: '', //
      kPP: '',//
      oGRN: '',//
      oKPO: '',//
      operatesOnBasis: '',
      phoneNumber: '',//
      placeName: '',
      yurAddress: ''//
    })
  }) localData!: VacuumTruckYurContract;

  async createVacuumTruckYurContract() {
    const alertData = {
      message: 'Контракт был отправлен',
      delay: 7000,
      isError: false
    };

    await this.contractService.CreateVacuumTruckYurContract(this.localData)
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
