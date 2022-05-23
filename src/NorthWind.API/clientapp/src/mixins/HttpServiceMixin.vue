<script lang="ts">
import {Component, Vue} from 'vue-property-decorator'
import AccountService from "@/services/AccountService/AccountService"
import ServiceViewService from "@/services/ServiceViewService/ServiceViewService";
import ContractService from "@/services/ContractService/ContractService";
import {CarsService} from "@/services/CarsService/CarsService";
import PurchaseService from "@/services/PurchaseService/PurchaseService";
import RequestCallService from "@/services/RequestCallService/RequestCallService";

@Component
export default class HttpServiceMixin extends Vue {
  protected carsService: CarsService = new CarsService()
  protected accountService: AccountService = new AccountService()
  protected serviceViewService: ServiceViewService = new ServiceViewService()
  protected contractService: ContractService = new ContractService()
  protected purchaseService: PurchaseService = new PurchaseService()
  protected requestCallService: RequestCallService = new RequestCallService()

  getErrorMessage(error: any): string {
    return error.response.data.errorMessage;
  }
}
</script>
<style scoped>

</style>
