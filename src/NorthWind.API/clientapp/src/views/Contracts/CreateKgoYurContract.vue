<template>
  <v-container>
    <contract-info
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
    <yur-contract-part
        :local-data.sync="localData"
        :is-view="isView"
    />
    <action-card-bar
        v-if="isAdminView"
        @send="confirmPurchase"
        :send-title="localData.isConfirmed ? 'Отменить согласование' : 'Согласовать'"
        cancel-title="Назад"
        @cancel="back"
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
import {KgoYurContract} from "@/services/ContractService/Requests";
import YurContractPart from "@/components/Contracts/ContractPart/YurContractPart.vue";
import KGOContractInfo from "@/components/Contracts/ContractPart/KGOContractInfo.vue";
import ContractInfo from "@/components/Contracts/ContractPart/ContractInfo.vue";
import PlacePicker from "@/components/Contracts/ContractPart/PlacePicker.vue";
import ActionCardBar from "@/components/Contracts/ContractPart/ActionCardBar.vue";
import HttpServiceMixin from "@/mixins/HttpServiceMixin.vue";
import {namespace} from "vuex-class";
import ContractViewMixin from "@/mixins/ContractViewMixin.vue";
import {ServiceEnum} from "@/enums/Enums";

@Component({components: {PlacePicker, YurContractPart, KGOContractInfo, ContractInfo, ActionCardBar}})
export default class CreateKgoYurContract extends Mixins(ContractViewMixin) {
  @Prop({
    required: false,
    default: () => ({
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
      yurAddress: '', //
      serviceRequestTypeId: ServiceEnum.KGOYur
    })
  }) localData!: KgoYurContract;
}
</script>
<style scoped lang="scss">

</style>
