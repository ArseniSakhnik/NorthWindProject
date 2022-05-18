<template>
  <v-container>
    <v-card>
      <v-card-title>
      </v-card-title>
      <v-card>
        <purchase-table/>
      </v-card>
    </v-card>
  </v-container>
</template>

<script lang="ts">
import {Component, Vue} from "vue-property-decorator";
import PurchaseTable from "@/components/Tables/PurchaseTable.vue";
import UserSidebar from "@/components/UserSidebar.vue";

@Component({components: {PurchaseTable, UserSidebar}})
export default class UserPurchases extends Vue {

}
</script>
<style lang="scss" scoped>
</style>
