<script lang="ts">
import {Vue, Component, PropSync, Ref, Watch} from 'vue-property-decorator'
import AccountService from "@/services/AccountService/AccountService"
import ServiceViewService from "@/services/ServiceViewService/ServiceViewService";
import PurchaseService from "@/services/PurchaseService/PurchaseService";
import {CarsService} from "@/services/CarsService/CarsService";

@Component
export default class DialogWindowMixin extends Vue {
  @PropSync('isActive') isConfirmActive!: boolean;
  @Ref('dialogRef') dialogRef!: any;

  toggleRegisterWindow(isOpen: boolean) {
    this.isConfirmActive = isOpen;
  }

  public close(): void {
    this.isConfirmActive = false
  }
  
  @Watch('isConfirmActive')
  isConfirmActiveChangeHandler(value: boolean) {
    this.dialogRef.isActive = value;
  }
}
</script>
<style scoped>

</style>