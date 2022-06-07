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
import {Vue, Component, Mixins, Prop} from "vue-property-decorator";
import {VacuumTruckFizContract} from "@/services/ContractService/Requests";
import FizContractPart from "@/components/Contracts/ContractPart/FizContractPart.vue";
import PlacePicker from "@/components/Contracts/ContractPart/PlacePicker.vue";
import ActionCardBar from "@/components/Contracts/ContractPart/ActionCardBar.vue";
import HttpServiceMixin from "@/mixins/HttpServiceMixin.vue";
import {namespace} from "vuex-class";
import ContractViewMixin from "@/mixins/ContractViewMixin.vue";
import {ServiceEnum} from "@/enums/Enums";

@Component({components: {ActionCardBar, PlacePicker, FizContractPart}})
export default class CreateVacuumTruckFizContract extends Mixins(ContractViewMixin) {
  @Prop({
    required: false, default: () => ({
      email: '',
      individualFullName: '',
      phoneNumber: '',
      placeName: '',
      serviceRequestTypeId: ServiceEnum.AsseniatorFiz
    })
  }) localData!: VacuumTruckFizContract;
}
</script>
<style scoped lang="scss">

</style>
