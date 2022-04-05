<template>
  <div>
    <h2 class="headline font-weight-bold mb-3">Данные по заявке</h2>
    <v-row>
      <v-col
      >
        <string-field
            label="Адрес"
            v-model="territoryAddress"
            :is-disabled="true"
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
            label="Приблизительная цена"
            v-model="price.toString()"
            :is-disabled="true"
            suffix="Руб."
        />
      </v-col>
    </v-row>
  </div>
</template>

<script lang="ts">
import {Vue, Component, Prop, PropSync} from "vue-property-decorator";
import StringField from "@/components/Fields/StringField.vue";
import TimePicker from "@/components/Fields/TimePicker.vue";

@Component({
  components: {StringField, TimePicker}
})
export default class VacuumTruckPurchaseInfo extends Vue {
  @PropSync('contractValidDate') contractValidDateSynced!: string;
  @Prop() territoryAddress!: string;
  @Prop() price!: number;
}
</script>
<style scoped lang="scss">

</style>
