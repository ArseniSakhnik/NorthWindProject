<template>
  <div>
    <h2 class="headline font-weight-bold mb-3">Юр данные</h2>
    <v-row>
      <v-col>
        <string-field
            v-model="individualEntrepreneurShortNameSynced"
            label="Сторона ФИО"
        />
      </v-col>
    </v-row>
    <v-row>
      <v-col
          v-if="clientCompanySynced !== null"
      >
        <string-field
            v-model="clientCompanySynced"
            label="Имя компания клиента"
        />
      </v-col>
    </v-row>
    <v-row>
      <v-col
          v-if="customerContactPersonAndJobTitleSynced !== null"
      >
        <string-field
            v-model="customerContactPersonAndJobTitleSynced"
            label="Контактное имя и должность"
        />
      </v-col>
    </v-row>
    <v-row>
      <v-col>
        <string-field
            v-model="iNNSynced"
            label="ИНН"
            mask="############"
        />
      </v-col>
    </v-row>
    <v-row>
      <v-col>
        <string-field
            label="КПП"
            mask="#########"
        />
      </v-col>
    </v-row>
    <v-row>
      <v-col>
        <string-field
            v-model="legalAddressSynced"
            :counter="250"
            label="Юридический адрес"
        />
      </v-col>
    </v-row>
    <v-row>
      <v-col>
        <string-field
            label="ОГРН"
            mask="#############"
        />
      </v-col>
    </v-row>
    <v-row>
      <v-col
          v-if="oKPOSynced !== null"
      >
        <string-field
            v-model="oKPOSynced"
            label="ОКРО"
        />
      </v-col>
    </v-row>
  </div>
</template>

<script lang="ts">
import {Component, PropSync, Vue} from "vue-property-decorator";
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
<style lang="scss" scoped>

</style>
