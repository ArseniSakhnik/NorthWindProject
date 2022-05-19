<template>
  <v-container>
    <v-card>
      <v-card-title>
        <v-spacer></v-spacer>
        <contract-opener/>
      </v-card-title>
      <v-card>
        <contracts-table/>
      </v-card>
    </v-card>
  </v-container>
</template>

<script lang="ts">
import {Vue, Component} from "vue-property-decorator";
import ContractsTable from "@/components/Contracts/ContractsTable.vue";
import ContractOpener from "@/components/SystemComponents/ContractOpener.vue";

@Component({components: {ContractsTable, ContractOpener}})
export default class UserContracts extends Vue {
  
}
</script>
<style scoped lang="scss">

</style>
