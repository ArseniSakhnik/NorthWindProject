<script lang="ts">
import {Component, Vue} from 'vue-property-decorator'
import ServiceViewService from "@/services/ServiceViewService/ServiceViewService";
import {CarsService} from "@/services/CarsService/CarsService";

@Component
export default class HttpServiceMixin extends Vue {
  protected carsService: CarsService = new CarsService()
  protected serviceViewService: ServiceViewService = new ServiceViewService()

  getErrorMessage(error: any): string {
    return error.response.data.errorMessage;
  }
}
</script>
<style scoped>

</style>
