﻿<script lang="ts">
import {Vue, Component, Prop, Mixins, Ref, Watch} from "vue-property-decorator";
import {KGODto} from "@/services/PurchaseService/Requests";
import KillReactivityMixin from "@/mixins/KillReactivityMixin.vue";
import {ServiceTypeEnum} from "@/enums/Enums";
import HttpServiceMixin from "@/mixins/HttpServiceMixin.vue";
import AlertMixin from "@/mixins/AlertMixin.vue";
import {PurchaseDto} from "@/services/PurchaseService/Response";

@Component
export default class PurchaseViewMixin extends Mixins(HttpServiceMixin, AlertMixin) {
  @Prop() localData!: any;
  @Ref('personalInformationInfo') personalInformation!: any;
  @Ref('purchase') purchaseInfo!: any;
  @Ref('calculate') calculateInfo!: any;

  localDataInit!: any;
  isView: boolean = true;

  created() {
    this.localDataInit = this.localData;
  }

  setView(isView: boolean) {
    this.isView = isView;
  }

  back() {
    this.$router.back();
  }

  setOldData() {
    this.localDataInit = this.localData;
  }

  cancelRedact() {
    this.setOldData();
    this.setView(true);
  }

  async save(serviceTypeId: ServiceTypeEnum) {
    if (!this.hasErrors()) {
      await this.purchaseService.UpdatePurchase(serviceTypeId, this.localDataInit)
          .then(() => {
            this.callAlert({
              message: 'Заявка была успешно отредактирована',
              delay: 7000,
              isError: false
            })
            this.setView(true);
          })
          .catch(error => this.callAlert({
            message: this.getErrorMessage(error),
            delay: 7000,
            isError: false
          }));
    }
  }

  async confirmPurchase(item: PurchaseDto) {
    await this.purchaseService.ConfirmPurchase(item.id, !item.isConfirmed)
        .then(() => {
          this.callAlert({
            message: 'Успешно',
            isError: false,
            delay: 7000
          })
          this.localData.isConfirmed = !this.localData.isConfirmed; 
        })
        .catch(error => this.callAlert({
          message: this.getErrorMessage(error),
          delay: 7000,
          isError: false
        }));
  }

  hasErrors(): boolean {
    const personalInfoValidate = this.personalInformation.validateComponent
        ? this.personalInformation.validateComponent()
        : false;

    const purchaseInfoValidate = this.purchaseInfo.validateComponent
        ? this.purchaseInfo.validateComponent()
        : false;

    const calculateInfoValidate = this.calculateInfo.validateComponent
        ? this.calculateInfo.validateComponent()
        : false;

    return personalInfoValidate || purchaseInfoValidate || calculateInfoValidate;
  }

  get confirmTitle() {
    return this.localData.isConfirmed ? 'Отменить согласование' : 'Согласовать';
  }
}
</script>
<style scoped lang="scss">

</style>
