<template>
  <div>
    <h2 class="headline font-weight-bold mb-3">Юр данные</h2>
    <v-col>
      <string-field
          label="Сторона ФИО"
          v-model="individualEntrepreneurShortNameSynced"
      />
    </v-col>
    <v-col>
      <string-field
          label="ИНН"
          prefix="ИНН"
          v-model="iNNSynced"
          mask="############"
      />
    </v-col>
    <v-col>
      <string-field
          label="КПП"
          mask="#########"
          prefix="КПП"
      />
    </v-col>
    <v-col>
      <string-field
          label="Юридический адрес"
          v-model="legalAddressSynced"
          :counter="250"
      />
    </v-col>
    <v-col>
      <string-field
          label="ОГРН"
          mask="#############"
          prefix="ОГРН"
      />
    </v-col>
  </div>
</template>

<script lang="ts">
import {Vue, Component, PropSync} from "vue-property-decorator";
import StringField from "@/components/Fields/StringField.vue";

@Component({
  components: {StringField}
})
export default class IndividualEntrepreneurInfo extends Vue {
  @PropSync('individualEntrepreneurShortName') individualEntrepreneurShortNameSynced!: string;
  @PropSync('iNN') iNNSynced!: string;
  @PropSync('kPP') kPPSynced!: string;
  @PropSync('legalAddress') legalAddressSynced!: string;
  @PropSync('oGRN') oGRNSynced!: string;
}
</script>
<style scoped lang="scss">

</style>
