<template>
  <div>
    <h2 class="headline font-weight-bold mb-3">Данные по заявке</h2>
    <v-row>
      <v-col
      >
        <string-field
            v-model="territoryAddress"
            :is-disabled="true"
        />
      </v-col>
    </v-row>
    <v-row>
      <v-col
          cols="12"
          sm="4"
      >
        <string-field
            v-model="contractValidDateSynced"
            :mask="'##-##-####'"
            label="Период оказания услуг в формате 28-12-2000"
        />
      </v-col>
      <v-col
          cols="12"
          sm="4"
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

@Component({
  components: {StringField}
})
export default class VacuumTruckPurchaseInfo extends Vue {
  @Prop() territoryAddress!: string;
  @Prop() price!: number;
  @PropSync('contractValidDate') contractValidDateSynced!: string;
}
</script>
<style scoped lang="scss">

</style>
