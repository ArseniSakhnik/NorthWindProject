<template>
  <div>
    <h2 class="headline font-weight-bold mb-3">Паспортные данные</h2>
    <v-row>
      <v-col
          cols="12"
          sm="4"
      >
        <string-field
            v-model="passportSerialNumberSynced"
            :mask="'## ##'"
            label="Серия паспорта"
        />
      </v-col>
      <v-col
          cols="12"
          sm="5"
      >
        <string-field
            v-model="passportIdSynced"
            :mask="'######'"
            label="Номер паспорта"
        />
      </v-col>
      <v-col
          cols="12"
          sm="3"
      >
        <string-field
            v-model="divisionCodeSynced"
            :mask="'###-###'"
            label="Номер подразделения"
        />
      </v-col>
    </v-row>
    <v-row>
      <v-col
          cols="12"
          sm="3"
      >
        <string-field
            v-model="passportIssueDateSynced"
            :mask="'##-##-####'"
            label="Дата выдачи в формате 28-12-2000"
        />
      </v-col>
      <v-col
          cols="12"
          sm="9"
      >
        <string-field
            v-model="passportIssuedSynced"
            :counter="150"
            label="Место выдачи паспорта"
        />
      </v-col>
    </v-row>
    <v-row>
      <v-col>
        <string-field
          v-model="registrationAddressSynced"
          :counter="250"
          label="Адрес регистрации"
        />
      </v-col>
    </v-row>
  </div>
</template>

<script lang="ts">
import {Vue, Component, PropSync} from "vue-property-decorator";
import StringField from "@/components/Fields/StringField.vue";

@Component({components: {StringField}})
export default class PassportInformation extends Vue {
  @PropSync('passportId') passportIdSynced!: string;
  @PropSync('passportIssueDate') passportIssueDateSynced!: string;
  @PropSync('passportIssued') passportIssuedSynced!: string;
  @PropSync('passportSerialNumber') passportSerialNumberSynced!: string;
  @PropSync('divisionCode') divisionCodeSynced!: string;
  @PropSync('registrationAddress') registrationAddressSynced!: string;
}
</script>
<style scoped lang="scss">

</style>
