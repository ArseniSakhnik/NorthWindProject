<script lang="ts">
import {Vue, Component} from 'vue-property-decorator'
import AccountService from "@/services/AccountService/AccountService"
import ServiceViewService from "@/services/ServiceViewService/ServiceViewService";
import PurchaseService from "@/services/PurchaseService/PurchaseService";

@Component
export default class HttpServiceMixin extends Vue {
  protected accountService: AccountService = new AccountService()
  protected serviceViewService: ServiceViewService = new ServiceViewService()
  protected purchaseService: PurchaseService = new PurchaseService()
}
</script>
<style scoped>

</style>
