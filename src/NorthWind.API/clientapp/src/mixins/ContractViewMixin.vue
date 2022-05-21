<script lang="ts">
import {Vue, Component, Mixins, Prop} from "vue-property-decorator";
import HttpServiceMixin from "@/mixins/HttpServiceMixin.vue";
import AlertMixin from "@/mixins/AlertMixin.vue";
import IsUserView from "@/mixins/IsUserView.vue";

@Component
export default class ContractViewMixin extends Mixins(HttpServiceMixin, AlertMixin, IsUserView) {
  @Prop({required: false, default: () => false}) isRedactPage!: boolean;

  isView: boolean = true;

  created() {
    this.isView = this.isRedactPage;
  }

  async createContract() {
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

  async confirmPurchase() {
    //@ts-ignore
    await this.contractService.ConfirmContract(this.localData.id, !this.localData.isConfirmed)
        .then(() => {
          this.callAlert({
            message: 'Успешно',
            delay: 7000,
            isError: false,
          });
          //@ts-ignore
          this.localData.isConfirmed = !this.localData.isConfirmed;
          this.$router.push('/admin-contracts')
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
