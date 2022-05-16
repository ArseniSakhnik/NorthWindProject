<script lang="ts">
import {Vue, Component, Prop, Mixins} from "vue-property-decorator";
import {KGODto} from "@/services/PurchaseService/Requests";
import KillReactivityMixin from "@/mixins/KillReactivityMixin.vue";

@Component
export default class PurchaseViewMixin extends Mixins(KillReactivityMixin) {
  updateToken: number = 1;
  @Prop() localData!: any;

  localDataInit!: any;
  isView: boolean = true;

  created() {
    this.localDataInit = this.killReactivity(this.localData);
  }

  setView(isView: boolean) {
    this.isView = isView;
  }

  back() {
    this.$router.back();
  }

  setOldData() {
    this.localDataInit = this.killReactivity(this.localData);
  }

  cancelRedact() {
    this.setOldData();
    this.setView(true);
    this.updateToken++;
  }
}
</script>
<style scoped lang="scss">

</style>
