<template>
  <div class="user-section">
    <div class="background-image">
    </div>
    <v-row>
      <v-col
          cols="12"
          sm="2"
          style="padding-bottom: 0"
      >
        <user-sidebar
            :current-view.sync="currentView"
        />
      </v-col>
      <v-col
          cols="12"
          sm="10"
      >
        <v-container>
          <v-card>
            <v-card-title>
            </v-card-title>
            <v-card>
              <purchase-table/>
            </v-card>
          </v-card>
        </v-container>
      </v-col>
    </v-row>
  </div>
</template>

<script lang="ts">
import {Component, Vue} from "vue-property-decorator";
import PurchaseTable from "@/components/Tables/PurchaseTable.vue";
import UserSidebar from "@/components/UserSidebar.vue";

@Component({components: {PurchaseTable, UserSidebar}})
export default class UserInfo extends Vue {
  currentView: number = 0;

}
</script>
<style lang="scss" scoped>
.background-image {
  background-image: url('../assets/backgrounds/phons.png');
  height: 20vh;
}

.user-section {
  min-height: 100vh;
  background-color: #f2f6ff;
}
</style>
