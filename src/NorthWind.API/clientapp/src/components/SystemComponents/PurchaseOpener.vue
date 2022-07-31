<template>
  <div>
    <confirm-request-call
        :is-active.sync="isRequestDialogActive"
    />
    
    <purchase-dialog
        :key="updateToken"
        :is-active.sync="isDialogActive"
        :service-type="serviceType"
        @openRequestCall="openRequestCall"
    />
  </div>
</template>

<script lang="ts">
import {Component, Prop, Ref, Vue, Watch} from "vue-property-decorator";
import OrangeButton from "@/components/Buttons/OrangeButton.vue";
import {ServiceTypeEnum} from "@/enums/Enums";
import PurchaseDialog from "@/components/PurchaseDialog.vue";
import ConfirmRequestCall from "@/components/Confirms/ConfirmRequestCall.vue";


@Component({components: {OrangeButton, PurchaseDialog, ConfirmRequestCall}})
export default class PurchaseOpener extends Vue {
  @Ref('dialogRef') dialogRef!: any;
  @Prop() serviceType!: ServiceTypeEnum;
  updateToken: number = 1;
  
  isDialogActive: boolean = false;
  isRequestDialogActive: boolean = false;
  
  openRequestCall() {
    this.isDialogActive = false;
    this.isRequestDialogActive = true;
  }

  openPurchase() {
    this.isDialogActive = true;
  }
  
  @Watch('isDialogActive')
  @Watch('serviceType')
  isDialogActiveChangeHandler() {
    if (!this.isDialogActive) {
      this.updateToken++;
    }
  }
}
</script>
<style lang="scss" scoped>
.dialog-buttons {
  display: flex;
  justify-content: space-between;
}

.rectangle-button {
  display: flex;
  flex-direction: column;
  justify-content: center;
  align-items: center;
  border-radius: 7px;
  width: 40%;
  height: 40vh;
  border: 1px solid gray;
  cursor: pointer;

  span {
    font-size: 2em;
  }

}
</style>
