<template>
  <v-container fluid>
    <h2 class="headline font-weight-bold mb-3">Данные о пользователе</h2>
    <v-row>
      <v-col
          cols="12"
          sm="4"
      >
        <v-text-field
            outlined
            dense
            label="Фамилия"
            v-model="nameSynced"
        />
      </v-col>
      <v-col
          cols="12"
          sm="4"
      >
        <v-text-field
            outlined
            dense
            label="Имя"
            v-model="surnameSynced"
        />
      </v-col>
      <v-col
          cols="12"
          sm="4"
      >
        <v-text-field
            outlined
            dense
            label="Отчество"
            v-model="middleNameSynced"
        />
      </v-col>
    </v-row>
    <v-row>
      <v-col
          cols="12"
          sm="6"
      >
        <v-text-field
            outlined
            dense
            label="Номер телефона"
            :value="phoneNumberSynced"
            v-mask="'#(###)-###-##-##'"
            @input="phoneNumberSyncedHandler"
        />
      </v-col>
      <v-col
          cols="12"
          sm="6"
      >
        <v-text-field
            outlined
            dense
            label="Email"
            v-model="emailSynced"
            :rules="[emailRules]"
        />
      </v-col>
    </v-row>
  </v-container>
</template>

<script lang="ts">
import {Vue, Component, PropSync} from "vue-property-decorator";

@Component
export default class PersonalData extends Vue {
  @PropSync('name', {type: String})
  nameSynced!: string;
  @PropSync('surname', {type: String})
  surnameSynced!: string;
  @PropSync('middleName', {type: String})
  middleNameSynced!: string;
  @PropSync('phoneNumber', {type: String})
  phoneNumberSynced!: string;
  @PropSync('email', {type: String})
  emailSynced!: string;

  phoneNumberSyncedHandler(value: string) {
    this.phoneNumberSynced = value;
  }

  private emailRules(value: string) : any {
    const pattern = /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/
    return pattern.test(value) || 'Invalid e-mail.'
  }
}
</script>
<style scoped lang="scss">

</style>
