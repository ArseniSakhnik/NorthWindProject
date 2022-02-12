<template>
  <v-container fluid>
    <h2 class="headline font-weight-bold mb-3">Паспортные данные</h2>
    <v-row>
      <v-col
          cols="12"
          sm="4"
      >
        <v-text-field
            outlined
            dense
            label="Серия"
            v-mask="'## ##'"
            :value="passportSerialNumberSynced"
            @input="passportSerialNumberSyncedHandler"
        />
      </v-col>
      <v-col
          cols="12"
          sm="4"
      >
        <v-text-field
            outlined
            dense
            label="Номер"
            v-mask="'##-##-##'"
            :value="passportNumberSynced"
            @input="passportNumberSyncedHandler"
        />
      </v-col>
    </v-row>
    <v-row>
      <v-col
          cols="12"
          sm="7"
      >
        <v-text-field
            outlined
            dense
            label="Паспорт выдан"
            :value="passportIssuedSynced"
            @input="passportIssuedSyncedHandler"
        />
      </v-col>
      <v-col
          cols="12"
          sm="3"
      >
        <v-text-field
            outlined
            dense
            label="Дата выдачи"
            v-mask="'##.##.####'"
            :value="passportIssueDateSynced"
            @input="passportIssueDateSyncedHandler"
            :rules="passportIssueDateRules"
        />
      </v-col>
      <v-col
          cols="12"
          sm="2"
      >
        <v-text-field
            outlined
            dense
            label="Код подразделения"
            v-mask="'###-###'"
            :value="passportDivisionNumberSynced"
            @input="passportDivisionNumberSyncedHandler"
        />
      </v-col>
    </v-row>
    <v-row>
      <v-col
          cols="12"
          sm="12"
      >
        <v-text-field
            outlined
            dense
            label="Адрес регистрации"
            :value="registrationAddressSynced"
            @input="registrationAddressSyncedHandler"
        />
      </v-col>
    </v-row>
  </v-container>
</template>

<script lang="ts">
import {Vue, Component, PropSync} from "vue-property-decorator";

@Component
export default class PassportFields extends Vue {
  @PropSync('passportSerialNumber', {type: String})
  passportSerialNumberSynced!: string;

  @PropSync('passportNumber', {type: String})
  passportNumberSynced!: string;

  @PropSync('passportIssued', {type: String})
  passportIssuedSynced!: string;

  @PropSync('passportIssueDate', {type: String})
  passportIssueDateSynced!: string;

  @PropSync('passportDivisionNumber', {type: String})
  passportDivisionNumberSynced!: string;
  
  @PropSync('registrationAddress', {type: String})
  registrationAddressSynced!: string;

  passportSerialNumberSyncedHandler(value: string) {
    this.passportSerialNumberSynced = value;
  }

  passportNumberSyncedHandler(value: string) {
    this.passportNumberSynced = value;
  }

  passportIssuedSyncedHandler(value: string) {
    this.passportIssuedSynced = value.toUpperCase();
  }

  passportIssueDateSyncedHandler(value: string) {
    this.passportIssueDateSynced = value;
  }

  passportDivisionNumberSyncedHandler(value: string) {
    this.passportDivisionNumberSynced = value;
  }

  registrationAddressSyncedHandler(value: string) {
    this.registrationAddressSynced = value.toUpperCase();
  }

  passportIssueDateRules: { (value: string): any }[] = [
    (value: string): boolean => {
      const dateElements = value.split('.');
      const day = Number(dateElements[0]);
      const month = Number(dateElements[1]);
      const year = Number(dateElements[2]);

      if ((day >= 1 && day <= 31)
          &&
          (month >= 1 && month <= 12)
          &&
          (year >= 2000 && year <= 2100))
        return true
      else
          //@ts-ignore
        return 'Введите корректную дату';
    }
  ]
}
</script>
<style scoped lang="scss">
.passport-section {
  width: 50vw;
}
</style>
