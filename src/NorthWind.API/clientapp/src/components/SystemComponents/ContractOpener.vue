<template>
  <div>
    <v-btn
        class="orange darken-3"
        style="color: white"
        @click="isChooseContractDialogOpened = true"
    >
      Создать договор
    </v-btn>
    <choose-contract-confirm
        :selected-service.sync="selectedService"
        :is-active.sync="isChooseContractDialogOpened"
    />
    <choose-client-type-confirm
        :selected-client.sync="selectedClient"
        :is-active.sync="isChooseClientDialogOpened"
    />
  </div>
</template>

<script lang="ts">
import {Component, Vue, Watch,} from "vue-property-decorator";
import ChooseContractConfirm from "@/components/SystemComponents/ChooseContractConfirm.vue";
import {ClientEnum, ServiceTypeEnum} from "@/enums/Enums";
import ChooseClientTypeConfirm from "@/components/SystemComponents/ChooseClientTypeConfirm.vue";

@Component({components: {ChooseContractConfirm, ChooseClientTypeConfirm}})
export default class ContractOpener extends Vue {
  selectedService: ServiceTypeEnum | null = null;
  selectedClient: ClientEnum | null = null;
  isChooseContractDialogOpened: boolean = false;
  isChooseClientDialogOpened: boolean = false;

  goToCreateContract() {
    
  }

  @Watch('selectedService')
  selectedServiceChangeHandler() {
    this.isChooseContractDialogOpened = false;
    this.isChooseClientDialogOpened = true;
  }

  @Watch('selectedClient')
  selectedClientChangeHandler() {
    this.isChooseClientDialogOpened = false;
    this.goToCreateContract();
  }
}
</script>
<style scoped lang="scss">

</style>
