<template>
  <div>
    <purchase-grid/>
  </div>
</template>

<script lang="ts">
import {Vue, Component} from "vue-property-decorator";
import PurchaseGrid from "@/components/Admin/Purchase/PurchaseGrid.vue";

@Component({components: {PurchaseGrid}})
export default class AdminPurchases extends Vue {

}
</script>
<style scoped lang="scss">
</style>
