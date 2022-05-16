<template>
  <v-card
      outlined
      tile
  >
    <v-card-text>
      <personal-information-info
          ref="personalInformationInfo"
          :email.sync="localDataInit.email"
          :middleName.sync="localDataInit.middleName"
          :name.sync="localDataInit.name"
          :phoneNumber.sync="localDataInit.phoneNumber"
          :surname.sync="localDataInit.surname"
          :is-view="isView"
      />
      <k-g-o-purchase
          ref="purchase"
          :planned-waste-volume="localDataInit.plannedWasteVolume"
          :is-view="isView"
      />
      <calculate-k-g-o
          ref="calculate"
          :place.sync="localDataInit.place"
          :planned-waste-volume="localDataInit.plannedWasteVolume"
          :comment.sync="localDataInit.comment"
          :is-view="isView"
      />
    </v-card-text>
    <v-card-actions>
      <v-spacer></v-spacer>
      <div v-if="isView">
        <v-btn @click="back">Назад</v-btn>
        <v-btn class="orange darken-3" style="color: white" @click="setView(false)">Редактировать</v-btn>
      </div>
      <div v-else>
        <v-btn @click="cancelRedact">Отмена</v-btn>
        <v-btn class="orange darken-3" style="color: white" @click="save(localData.serviceTypeId)">Сохранить</v-btn>
      </div>
    </v-card-actions>
  </v-card>
</template>

<script lang="ts">
import {Vue, Component, PropSync, Prop, Ref, Mixins} from "vue-property-decorator";
import {KGODto} from "@/services/PurchaseService/Requests";
import PersonalInformationInfo from "@/components/FieldSections/PersonalInformationInfo.vue";
import KGOPurchase from "@/components/Purchase/KGOPurchase.vue";
import CalculateKGO from "@/components/Calculate/CalculateKGO.vue";
import KillReactivityMixin from "@/mixins/KillReactivityMixin.vue";
import PurchaseViewMixin from "@/mixins/PurchaseViewMixin.vue";

@Component({components: {PersonalInformationInfo, KGOPurchase, CalculateKGO}})
export default class KGOPurchaseView extends Mixins(PurchaseViewMixin) {
  
}
</script>
<style scoped lang="scss">

</style>
