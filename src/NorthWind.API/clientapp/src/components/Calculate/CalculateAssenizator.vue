﻿<template>
  <div>
    <h2 class="headline font-weight-bold mb-3">Расчет стоимости и выбор пункта назначения</h2>
    <v-row>
      <v-col
          cols="12"
          :sm="isView ? 12 : 6"
      >
        <string-field
            ref="1"
            :rules="[isStringNotEmpty]"
            v-model="placeSynced"
            label="Место оказания услуги*"
            :is-readonly="isMapOpened || isView"
        />
        <string-field
            v-if="!isView"
            v-model="price"
            :is-number="true"
            :is-readonly="true"
            label="Предварительная стоимость оказания услуг"
            prefix="Руб."
        />
        <v-textarea
            v-model="commentSync"
            label="Комментарий"
            counter
            maxlength="120"
            single-line
            outlined
            :readonly="isView"
        />
      </v-col>
      <v-col
          cols="12"
          sm="6"
          v-if="!isView"
      >
        <v-expansion-panels
            v-model="openedExpansionPanel"
            multiple
        >
          <v-expansion-panel>
            <v-expansion-panel-header>Открыть карту для расчета цены</v-expansion-panel-header>
            <v-expansion-panel-content>
              <yandex-map
                  v-if="isMapOpened"
                  style="width: 100%; height: 50vh;"
                  :bound-distance.sync="boundDistance"
                  :territory-address.sync="placeSynced"
              />
            </v-expansion-panel-content>
          </v-expansion-panel>
        </v-expansion-panels>
      </v-col>
    </v-row>
  </div>
</template>

<script lang="ts">
import {Vue, Component, Prop, PropSync, Mixins} from "vue-property-decorator";
import YandexMap from "@/components/YMaps/YandexMap.vue";
import StringField from "@/components/Fields/StringField.vue";
import ValidationMixin from "@/mixins/ValidationMixin.vue";

@Component({components: {YandexMap, StringField}})
export default class CalculateAssenizator extends Mixins(ValidationMixin) {
  @Prop({required: false, default: () => false}) isView!: boolean;
  @Prop() distanceFromDriveway!: number;
  @PropSync('place') placeSynced!: string;
  @PropSync('comment') commentSync!: string;

  openedExpansionPanel: any[] = []

  get isMapOpened() {
    return this.openedExpansionPanel.length > 0;
  }

  boundDistance: number = 0;

  get price() {
    const basePrice = 3000;
    const piceHouse = Math.ceil(this.distanceFromDriveway / 10);
    const boundDistanceMetrs = Math.floor(this.boundDistance / 1000);
    return basePrice + 500 * piceHouse + boundDistanceMetrs * 2 * 60;
  }


}
</script>
<style scoped lang="scss">

</style>
