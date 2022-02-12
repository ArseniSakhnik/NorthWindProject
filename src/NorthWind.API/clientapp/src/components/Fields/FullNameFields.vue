<template>
  <v-container fluid>
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
  </v-container>
</template>

<script lang="ts">
import {Vue, Component, PropSync} from "vue-property-decorator";

@Component
export default class FullNameFields extends Vue {
  @PropSync('name', {type: String}) 
  private nameSynced!: string;
  @PropSync('surname', {type: String})
  private surnameSynced!: string;
  @PropSync('middleName', {type: String})
  private middleNameSynced!: string;
}
</script>
<style scoped lang="scss">

</style>
