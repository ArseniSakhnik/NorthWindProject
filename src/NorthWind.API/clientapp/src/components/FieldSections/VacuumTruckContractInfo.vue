﻿<template>
  <div>
    <h2 class="headline font-weight-bold mb-3">Данные по заявке</h2>
    <v-row>
      <v-col
      >
        <string-field
            v-model="territoryAddress"
            :is-disabled="true"
            label="Адрес"
        />
      </v-col>
    </v-row>
    <v-row>
      <!--      <v-col-->
      <!--          cols="12"-->
      <!--          sm="6"-->
      <!--      >-->
      <!--        <time-picker-->
      <!--            :date.sync="contractValidDateSynced"-->
      <!--        />-->
      <!--      </v-col>-->
      <v-col
          cols="12"
          sm="6"
      >
        <string-field
            v-model="price.toString()"
            :is-disabled="true"
            label="Приблизительная цена"
            suffix="Руб."
        />
      </v-col>
    </v-row>
  </div>
</template>

<script lang="ts">
import {Component, Prop, PropSync, Vue} from "vue-property-decorator";
import StringField from "@/components/Fields/StringField.vue";
import TimePicker from "@/components/Fields/TimePicker.vue";

@Component({
  components: {StringField, TimePicker}
})
export default class VacuumTruckContractInfo extends Vue {
  @PropSync('contractValidDate') contractValidDateSynced!: string;
  @Prop() territoryAddress!: string;
  @Prop() price!: number;
}
</script>
<style lang="scss" scoped>

</style>
