<template>
  <div>
    <h2 class="headline font-weight-bold mb-3">Юр данные</h2>
    <v-col>
      <string-field
          label="Сторона ФИО"
          v-model="individualEntrepreneurShortNameSynced"
      />
    </v-col>
    <v-col
        v-if="clientCompanySynced !== null"
    >
      <string-field
          label="Имя компания клиента"
          v-model="clientCompanySynced"
      />
    </v-col>
    <v-col
        v-if="customerContactPersonAndJobTitleSynced !== null"
    >
      <string-field
          label="Контактное имя и должность"
          v-model="customerContactPersonAndJobTitleSynced"
      />
    </v-col>
    <v-col>
      <string-field
          label="ИНН"
          v-model="iNNSynced"
          mask="############"
      />
    </v-col>
    <v-col>
      <string-field
          label="КПП"
          mask="#########"
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
      />
    </v-col>
    <v-col
        v-if="oKPOSynced !== null"
    >
      <string-field
          label="ОКРО"
          v-model="oKPOSynced"
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
  @PropSync('clientCompany', {required: false, default: () => null}) clientCompanySynced!: string | null;
  @PropSync('customerContactPersonAndJobTitle', {
    required: false,
    default: () => null
  }) customerContactPersonAndJobTitleSynced!: string | null;
  @PropSync('oKPO', {required: false, default: () => null}) oKPOSynced!: string | null;
}
</script>
<style scoped lang="scss">

</style>
