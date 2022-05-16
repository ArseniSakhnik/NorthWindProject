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
      <assenizator-purchase
          :waste-type.sync="localDataSync.wasteType"
          :pit-volume.sync="localDataSync.pitVolume"
          :distance-from-driveway.sync="localDataSync.distanceFromDriveway"
          :is-view="true"
      />
      <calculate-assenizator
          :distance-from-driveway="localDataSync.distanceFromDriveway"
          :place.sync="localDataSync.place"
          :comment.sync="localDataSync.comment"
          :is-view="true"
      />
    </v-card-text>
    <v-card-actions>
      <v-spacer></v-spacer>
      <v-btn>Назад</v-btn>
      <v-btn class="orange darken-3" style="color: white">Редактировать</v-btn>
    </v-card-actions>
  </v-card>
</template>

<script lang="ts">
import {Vue, Component, PropSync} from "vue-property-decorator";
import {AssenizatorPurchaseDto} from "@/services/PurchaseService/Requests";
import PersonalInformationInfo from "@/components/FieldSections/PersonalInformationInfo.vue";
import AssenizatorPurchase from "@/components/Purchase/AssenizatorPurchase.vue";
import CalculateAssenizator from "@/components/Calculate/CalculateAssenizator.vue";

@Component({components: {PersonalInformationInfo, AssenizatorPurchase, CalculateAssenizator}})
export default class AssenizatorPurchaseView extends Vue {
  @PropSync('localData') localDataSync!: AssenizatorPurchaseDto;

  mounted() {
    console.log(this.localDataSync)
  }
}
</script>
<style scoped lang="scss">

</style>
