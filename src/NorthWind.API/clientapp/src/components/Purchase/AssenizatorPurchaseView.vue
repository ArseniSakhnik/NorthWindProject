﻿<template>
  <v-card
      outlined
      tile
  >
    <v-card-title>Заявка на откачку жидких бытовых отходов</v-card-title>
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
      <assenizator-purchase
          ref="purchase"
          :waste-type.sync="localDataInit.wasteType"
          :pit-volume.sync="localDataInit.pitVolume"
          :distance-from-driveway.sync="localDataInit.distanceFromDriveway"
          :is-view="isView"
      />
      <calculate-assenizator
          ref="calculate"
          :distance-from-driveway="localDataInit.distanceFromDriveway"
          :place.sync="localDataInit.place"
          :comment.sync="localDataInit.comment"
          :is-view="isView"
      />
    </v-card-text>
    <v-card-actions v-if="isUserView">
      <v-spacer></v-spacer>
      <div v-if="isView">
        <v-btn @click="back" class="m-3">Назад</v-btn>
        <v-btn class="orange darken-3" style="color: white" @click="setView(false)">Редактировать</v-btn>
      </div>
      <div v-else>
        <v-btn @click="cancelRedact" class="m-3">Отмена</v-btn>
        <v-btn class="orange darken-3" style="color: white" @click="save(localData.serviceTypeId)">Сохранить</v-btn>
      </div>
    </v-card-actions>
    <v-card-actions v-if="isAdminView">
      <v-spacer></v-spacer>
      <div>
        <v-btn @click="back" class="m-3">Назад</v-btn>
        <v-btn
            class="orange darken-3"
            style="color: white"
            @click="confirmPurchase(localData)"

        >
          {{ confirmTitle }}
        </v-btn>
      </div>
    </v-card-actions>
  </v-card>
</template>

<script lang="ts">
import {Vue, Component, PropSync, Mixins, Watch} from "vue-property-decorator";
import PersonalInformationInfo from "@/components/FieldSections/PersonalInformationInfo.vue";
import AssenizatorPurchase from "@/components/Purchase/AssenizatorPurchase.vue";
import CalculateAssenizator from "@/components/Calculate/CalculateAssenizator.vue";
import PurchaseViewMixin from "@/mixins/PurchaseViewMixin.vue";
import IsUserView from "@/mixins/IsUserView.vue";
import {PurchaseDto} from "@/services/PurchaseService/Response";

@Component({components: {PersonalInformationInfo, AssenizatorPurchase, CalculateAssenizator}})
export default class AssenizatorPurchaseView extends Mixins(PurchaseViewMixin, IsUserView) {


}
</script>
<style scoped lang="scss">

</style>
