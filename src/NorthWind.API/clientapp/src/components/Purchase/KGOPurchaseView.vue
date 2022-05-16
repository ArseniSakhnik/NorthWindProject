<template>
  <v-card
      outlined
      tile
  >
    <v-card-text>
      <personal-information-info
          ref="personalInformationInfo"
          :email.sync="localDataSync.email"
          :middleName.sync="localDataSync.middleName"
          :name.sync="localDataSync.name"
          :phoneNumber.sync="localDataSync.phoneNumber"
          :surname.sync="localDataSync.surname"
          :is-view="true"
      />
      <k-g-o-purchase
          :planned-waste-volume="localData.plannedWasteVolume"
          :is-view="true"
      />
      <calculate-k-g-o
          :place.sync="localDataSync.place"
          :planned-waste-volume="localDataSync.plannedWasteVolume"
          :comment.sync="localDataSync.comment"
          :is-view="true"
      />
    </v-card-text>
  </v-card>
</template>

<script lang="ts">
import {Vue, Component, PropSync} from "vue-property-decorator";
import {KGODto} from "@/services/PurchaseService/Requests";
import PersonalInformationInfo from "@/components/FieldSections/PersonalInformationInfo.vue";
import KGOPurchase from "@/components/Purchase/KGOPurchase.vue";
import CalculateKGO from "@/components/Calculate/CalculateKGO.vue";

@Component({components: {PersonalInformationInfo, KGOPurchase, CalculateKGO}})
export default class KGOPurchaseView extends Vue {
  @PropSync('localData') localDataSync!: KGODto;

}
</script>
<style scoped lang="scss">

</style>
