<template>
  <v-dialog
      ref="dialogRef"
      persistent
      width="500"
      @click:outside="toggleRegisterWindow(false)"
  >
    <v-card style="height: 500px;">
      <v-card-title>
        <v-tabs
            background-color="orange lighten-1 accent-4"
            fixed-tabs
            dark
            v-model="currentTab"
        >
          <v-tab v-if="!isUserAuthenticated">Регистрация</v-tab>
          <v-tab :disabled="!isUserAuthenticated">Анкета</v-tab>
          <v-tab :disabled="!isUserAuthenticated">Расчет стоимости</v-tab>
        </v-tabs>
      </v-card-title>
      <v-card-text v-if="">
        
      </v-card-text>
    </v-card>
  </v-dialog>
</template>

<script lang="ts">
import {Vue, Component, Mixins, Prop} from "vue-property-decorator";
import DialogWindowMixin from "@/mixins/DialogWindowMixin.vue";

@Component
export default class PurchaseDialog extends Mixins(DialogWindowMixin) {
  @Prop() isUserAuthenticated!: boolean;
  currentTab: number = 0;

  mounted() {
    if (this.isUserAuthenticated) {
      this.currentTab = 1;
    }
  }
}
</script>
<style scoped lang="scss">

</style>
