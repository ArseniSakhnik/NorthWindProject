<script lang="ts">
import {Vue, Component} from 'vue-property-decorator'
import AccountService from "@/services/AccountService/AccountService"

@Component
export default class HttpServiceMixin extends Vue {
  protected accountService: AccountService = new AccountService()
}
</script>
<style scoped>

</style>
