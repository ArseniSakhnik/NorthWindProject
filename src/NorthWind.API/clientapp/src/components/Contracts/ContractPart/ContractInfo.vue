<template>
  <v-card>
    <v-card-title>Договор</v-card-title>
    <v-card-text>
      <string-field
          v-model="localDataSync.customerShortName"
          label="ФИО Заказчика"
      />
      <string-field
          v-model="localDataSync.iEShortName"
          label="ФИО Индивидуального предпринимателя"
      />
      <v-select
          :items="actOnBasis"
          item-text="name"
          item-value="name"
          v-model="localDataSync.operatesOnBasis"
          label="Заказчик действует на основании"
          outlined
          dense
      />
    </v-card-text>
  </v-card>
</template>

<script lang="ts">
import {Vue, Component, PropSync} from "vue-property-decorator";
import {BaseYurContract} from "@/services/ContractService/Requests";
import StringField from "@/components/Fields/StringField.vue";
import {namespace} from "vuex-class";

const User = namespace('CurrentUserStore')

@Component({components: {StringField}})
export default class ContractInfo extends Vue {
  @PropSync('localData') localDataSync!: BaseYurContract;

  @User.State('name') name!: string;
  @User.State('surname') surname!: string;
  @User.State('middleName') middleName!: string;

  actOnBasis: { name: string }[] = [
    {
      name: 'Устава',
    },
    {
      name: 'Договоренности'
    }
  ]

  created() {
    this.localDataSync.customerShortName = `ИП ${this.surname} ${this.name.substring(0, 1).toUpperCase()}.${this.middleName.substring(0, 1).toUpperCase()}.`;
  }
}
</script>
<style scoped lang="scss">

</style>
