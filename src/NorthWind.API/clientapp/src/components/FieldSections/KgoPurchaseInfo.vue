<template>
  <div>
    <h2 class="headline font-weight-bold mb-3">Откачка жидких бытовых отходов</h2>
    <v-row>
      <v-col
          cols="12"
          md="6"
      >
        <string-field
            v-model="startDateSynced"
            label="Дата начала"
            mask="##-##-####"
        />
      </v-col>
      <v-col
          cols="12"
          md="6"
      >
        <string-field
            v-model="startTimeSynced"
            label="Время начала"
            mask="##:##"
        />
      </v-col>
    </v-row>
    <v-row>
      <v-col
          cols="12"
          md="6"
      >
        <string-field
            v-model="endDateSynced"
            label="Дата конца"
            mask="##-##-####"
        />
      </v-col>
      <v-col
          cols="12"
          md="6"
      >
        <string-field
            v-model="endTimeSynced"
            label="Время конца"
            mask="##:##"
        />
      </v-col>
    </v-row>
    <v-row>
      <v-col>
        <string-field
          v-model="actOnTheBasisSynced"
          :disabled="true"
          label="Устава"
          type="number"
        />
      </v-col>
    </v-row>
    <v-row>
      <v-col>
        <string-field
            label="Стоимость штрафа"
            v-model="coastPriceSynced"
        />
      </v-col>
    </v-row>
    <v-row>
      <v-col>
        <string-field
            v-model="contractValidDateSynced"
            label="Конец действия договора"
            mask="##-##-##"
        />
      </v-col>
    </v-row>
    <v-row>
      <v-col>
        <string-field
            v-model="vehiclesNumberSynced"
            label="Количество техники"
            mask="##"
            type="number"
        />
      </v-col>
    </v-row>
    <v-row>
      <v-col>
        <string-field
            v-model="volumeSynced"
            label="Объем"
            mask="##"
        />
      </v-col>
    </v-row>
  </div>
</template>

<script lang="ts">
import {Vue, Component, PropSync} from "vue-property-decorator";
import StringField from "@/components/Fields/StringField.vue";
@Component({
  components: {StringField}
})
export default class KgoPurchaseInfo extends Vue {
  @PropSync('startDate') startDateSynced!: string;
  @PropSync('startTime') startTimeSynced!: string;
  @PropSync('endDate') endDateSynced!: string;
  @PropSync('endTime') endTimeSynced!: string;

  @PropSync('actOnTheBasis') actOnTheBasisSynced!: number;
  @PropSync('coastPrice') coastPriceSynced!: string;
  @PropSync('contractValidDate') contractValidDateSynced!: string;
  @PropSync('vehiclesNumber') vehiclesNumberSynced!: number;
  @PropSync('volume') volumeSynced!: string;
  // @Prop
}
</script>
<style scoped lang="scss">

</style>
