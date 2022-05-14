<template>
  <div>
    <h2 class="headline font-weight-bold mb-3">Данные по заявке</h2>
    <v-row>
      <v-col
          cols="12"
          sm="4"
      >
        <string-field
            ref="1"
            v-model="plannedWasteVolumeSynced"
            label="Примерный объем выгребной ямы*"
            mask="####"
            prefix="м³"
            :is-number="true"
        />
      </v-col>
      <v-col
          cols="12"
          sm="4"
      >
      </v-col>
    </v-row>
  </div>
</template>

<script lang="ts">
import {Vue, Component, PropSync} from "vue-property-decorator";
import StringField from "@/components/Fields/StringField.vue";

@Component({components: {StringField}})
export default class KGOPurchase extends Vue {
  @PropSync('plannedWasteVolume') plannedWasteVolumeSynced!: number;
}
</script>
<style scoped lang="scss">

</style>
