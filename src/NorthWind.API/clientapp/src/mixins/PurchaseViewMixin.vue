<script lang="ts">
import {Vue, Component, Prop, Mixins, Ref, Watch} from "vue-property-decorator";
import {KGODto} from "@/services/PurchaseService/Requests";
import KillReactivityMixin from "@/mixins/KillReactivityMixin.vue";
import {ServiceTypeEnum} from "@/enums/Enums";
import HttpServiceMixin from "@/mixins/HttpServiceMixin.vue";

@Component
export default class PurchaseViewMixin extends Mixins(HttpServiceMixin) {
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
            alert('Успешно');
            this.setView(false);
          })
          .catch(error => this.getErrorMessage(error));
    }
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
}
</script>
<style scoped lang="scss">

</style>
