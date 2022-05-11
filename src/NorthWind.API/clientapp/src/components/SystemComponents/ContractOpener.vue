<template>
  <div>
    <orange-button
        style="margin-right: 1em"
        title="Заказать услугу"
        @action="openPurchase"
    />
    <purchase-dialog
        :is-active.sync="isDialogActive"
        :is-user-authenticated="isUserAuthenticated"
    />
  </div>
</template>

<script lang="ts">
import {Component, Prop, PropSync, Ref, Vue, Watch} from "vue-property-decorator";
import OrangeButton from "@/components/Buttons/OrangeButton.vue";
import {ServiceTypeEnum} from "@/enums/Enums";
import {namespace} from "vuex-class";
import PurchaseDialog from "@/components/PurchaseDialog.vue";

const User = namespace('CurrentUserStore')

@Component({components: {OrangeButton, PurchaseDialog}})
export default class ContractOpener extends Vue {
  @Ref('dialogRef') dialogRef!: any;
  @Prop() serviceType!: ServiceTypeEnum;
  @User.State('userId') userId!: number;

  get isUserAuthenticated(): boolean {
    return this.userId !== 0;
  }

  isDialogActive: boolean = false;

  openPurchase() {
    this.isDialogActive = true;
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
