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
    <k-g-o-contract-info
        :local-data.sync="localData"
        :is-view="isView"
    />
    <action-card-bar
        v-if="isAdminView"
        @send="confirmPurchase"
        @cancel="back"
        send-title="Согласовать"
        cancel-title="Назад"
        :is-admin-view="isAdminView"
        @exportContract="exportContract"
    />
    <action-card-bar
        v-else-if="!isRedactPage && isUserView"
        @send="createContract"
        @cancel="back"
    />
    <action-card-bar
        v-if="isRedactPage && isView && isUserView"
        send-title="Редактировать"
        cancel-title="Отмена"
        @send="toggleView(false)"
        @cancel="toggleView(true)"
    />
    <action-card-bar
        v-if="isRedactPage && !isView && isUserView"
        send-title="Сохранить"
        cancel-title="Назад"
        @send="updateContract"
        @cancel="back"
    />
  </v-container>
</template>

<script lang="ts">
import {Component, Mixins, Prop, Vue} from "vue-property-decorator";
import {KgoFizContract} from "@/services/ContractService/Requests";
import {ServiceEnum} from "@/enums/Enums";
import ContractViewMixin from "@/mixins/ContractViewMixin.vue";
import PlacePicker from "@/components/Contracts/ContractPart/PlacePicker.vue";
import KGOContractInfo from "@/components/Contracts/ContractPart/KGOContractInfo.vue";
import ContractInfo from "@/components/Contracts/ContractPart/ContractInfo.vue";
import ActionCardBar from "@/components/Contracts/ContractPart/ActionCardBar.vue";
import FizContractPart from "@/components/Contracts/ContractPart/FizContractPart.vue";

@Component({components: {PlacePicker, FizContractPart, KGOContractInfo, ContractInfo, ActionCardBar}})
export default class CreateKgoFizContract extends Mixins(ContractViewMixin) {
  @Prop({
    required: false,
    default: () => ({
      email: '',
      individualFullName: '',
      overload: '',
      phoneNumber: '',
      placeName: '',
      serviceRequestTypeId: ServiceEnum.KgoFiz,
      volume: ''
    })
  }) localData!: KgoFizContract;
}
</script>
<style scoped lang="scss">

</style>
