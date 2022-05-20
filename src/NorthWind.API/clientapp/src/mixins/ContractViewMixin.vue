<script lang="ts">
import {Vue, Component, Mixins, Prop} from "vue-property-decorator";
import HttpServiceMixin from "@/mixins/HttpServiceMixin.vue";
import AlertMixin from "@/mixins/AlertMixin.vue";

@Component
export default class ContractViewMixin extends Mixins(HttpServiceMixin, AlertMixin) {
  @Prop({required: false, default: () => false}) isRedactPage!: boolean;

  isView: boolean = true;
  
  created() {
    this.isView = this.isRedactPage;
  }

  async createContract() {
    console.log(1)
    //@ts-ignore
    await this.contractService.CreateContract(this.localData)
        .then(() => {
          this.callAlert({
            message: 'Договор был отправлен',
            delay: 7000,
            isError: false
          })
          this.$router.push('/user-contracts')
        })
        .catch(error => this.callAlert({
          message: this.getErrorMessage(error),
          delay: 7000,
          isError: true
        }));
  }
  
  toggleView(isRedact: boolean) {
    this.isView = isRedact;
  }

  async updateContract() {
    //@ts-ignore
    await this.contractService.UpdateContract(this.localData)
        .then(() => {
          this.callAlert({
            message: 'Договор был изменен',
            delay: 7000,
            isError: false
          })
          this.toggleView(true);
        })
        .catch(error => this.callAlert({
          message: this.getErrorMessage(error),
          delay: 7000,
          isError: true
        }));
  }

  back() {
    this.$router.back();
  }
}
</script>
<style scoped lang="scss">

</style>
