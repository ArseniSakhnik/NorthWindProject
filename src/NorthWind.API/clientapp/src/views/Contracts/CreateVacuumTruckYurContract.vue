<template>
  <v-container>
    <contract-info
        :local-data.sync="localData"
    />
    <yur-contract-part
        :local-data.sync="localData"
    />
    <place-picker
        :local-data.sync="localData"
    />
  </v-container>
</template>

<script lang="ts">
import {Vue, Component} from "vue-property-decorator";
import {VacuumTruckYurContract} from "@/services/ContractService/Requests";
import YurContractPart from "@/components/Contracts/ContractPart/YurContractPart.vue";
import ContractInfo from "@/components/Contracts/ContractPart/ContractInfo.vue";
import PlacePicker from "@/components/Contracts/ContractPart/PlacePicker.vue";

@Component({components: {PlacePicker, ContractInfo, YurContractPart}})
export default class CreateVacuumTruckContract extends Vue {
  localData: VacuumTruckYurContract = {
    customerShortName: '',
    email: '',//
    iEShortName: '',
    iNN: '', //
    kPP: '',//
    oGRN: '',//
    oKPO: '',//
    operatesOnBasis: '',
    phoneNumber: '',//
    placeName: '',
    yurAddress: ''//
  }
}
</script>
<style scoped lang="scss">

</style>
