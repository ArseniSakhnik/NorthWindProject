<template>
  <v-container v-if="isDataLoaded">
    <create-vacuum-truck-yur-contract
        v-if="localData.serviceRequestTypeId === 1"
        :local-data="localData"
        :is-redact-page="true"
    />
    <create-vacuum-truck-fiz-contract
        v-else-if="localData.serviceRequestTypeId === 2"
        :local-data="localData"
        :is-redact-page="true"
    />
    <create-kgo-yur-contract
        v-else-if="localData.serviceRequestTypeId === 3"
        :local-data="localData"
        :is-redact-page="true"
    />
  </v-container>
</template>

<script lang="ts">
import {Vue, Component, Mixins} from "vue-property-decorator";
import {BaseContractDto} from "@/services/ContractService/Responses";
import HttpServiceMixin from "@/mixins/HttpServiceMixin.vue";
import CreateVacuumTruckFizContract from "@/views/Contracts/CreateVacuumTruckFizContract.vue";
import CreateVacuumTruckYurContract from '@/views/Contracts/CreateVacuumTruckYurContract.vue';
import CreateKgoYurContract from "@/views/Contracts/CreateKgoYurContract.vue";

@Component({
  components: {CreateKgoYurContract, CreateVacuumTruckFizContract, CreateVacuumTruckYurContract}
})
export default class ContractInfoPage extends Mixins(HttpServiceMixin) {
  isDataLoaded: boolean = false;
  purchaseId: number = 0;
  localData!: BaseContractDto;

  created() {
    this.purchaseId = Number(this.$route.params.id);
  }

  async mounted() {
    await this.contractService.GetContract(this.purchaseId).then(response => {
      this.localData = response.data
      this.isDataLoaded = true;
    });
  }

}
</script>
<style scoped lang="scss">

</style>
