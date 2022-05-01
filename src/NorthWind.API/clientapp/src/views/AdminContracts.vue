<template>
  <div>
    <contract-grid/>
  </div>
</template>

<script lang="ts">
import {Component, Vue} from "vue-property-decorator";
import ContractGrid from "@/components/Admin/Contract/ContractGrid.vue";

@Component({components: {ContractGrid}})
export default class AdminContracts extends Vue {

}
</script>
<style lang="scss" scoped>
</style>
