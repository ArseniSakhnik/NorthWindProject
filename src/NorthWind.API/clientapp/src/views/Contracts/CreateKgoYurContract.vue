<template>
  <v-container>
    <contract-info
        :local-data.sync="localData"
    />
    <place-picker
        :local-data.sync="localData"
    />
    <k-g-o-contract-info
        :local-data.sync="localData"
    />
    <yur-contract-part
        :local-data.sync="localData"
    />
    <action-bar
        @send="createKgoYurContract"
        @cancel="back"
    />
  </v-container>
</template>

<script lang="ts">
import {Vue, Component, Mixins} from "vue-property-decorator";
import {KgoYurContract} from "@/services/ContractService/Requests";
import YurContractPart from "@/components/Contracts/ContractPart/YurContractPart.vue";
import KGOContractInfo from "@/components/Contracts/ContractPart/KGOContractInfo.vue";
import ContractInfo from "@/components/Contracts/ContractPart/ContractInfo.vue";
import PlacePicker from "@/components/Contracts/ContractPart/PlacePicker.vue";
import ActionBar from "@/components/Contracts/ContractPart/ActionBar.vue";
import HttpServiceMixin from "@/mixins/HttpServiceMixin.vue";
import {namespace} from "vuex-class";

const Alert = namespace('AlertStore')

@Component({components: {PlacePicker, YurContractPart, KGOContractInfo, ContractInfo, ActionBar}})
export default class CreateKgoYurContract extends Mixins(HttpServiceMixin) {
  @Alert.Action('CALL_ALERT') callAlert!: (alertData: any) => void;

  localData: KgoYurContract = {
    customerShortName: '', //
    email: '', //
    iEShortName: '', //
    iNN: '', //
    kPP: '', //
    oGRN: '', //
    oKPO: '', //
    operatesOnBasis: '', //
    overload: '', //
    phoneNumber: '', //
    placeName: '',
    volume: '', //
    yurAddress: '' //
  }

  async createKgoYurContract() {
    const alertData = {
      message: 'Контракт был отправлен',
      delay: 7000,
      isError: false
    };

    await this.contractService.CreateKGOYurContract(this.localData)
        .then(() => {
          this.callAlert(alertData)
          this.$router.push('/user-contracts')
        })
        .catch(error => {
          const errorAlert = this.getErrorMessage(error);
          alertData.message = errorAlert;
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
