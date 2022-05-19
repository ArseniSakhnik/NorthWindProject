<template>
  <v-card>
    <v-card-title>Данные о лице</v-card-title>
    <v-card-text>
      <string-field
          v-model="localDataSync.individualFullName"
          label="ФИО физ. лица"
          :is-readonly="isView"
      />
      <string-field
          v-model="localDataSync.phoneNumber"
          label="Номер телефона"
          prefix="+7"
          :is-readonly="isView"
      />
      <string-field
          v-model="localDataSync.email"
          label="Email"
          :is-readonly="isView"
      />
    </v-card-text>
  </v-card>
</template>

<script lang="ts">
import {Vue, Component, PropSync, Prop} from "vue-property-decorator";
import {VacuumTruckFizContract} from "@/services/ContractService/Requests";
import StringField from "@/components/Fields/StringField.vue";
import {namespace} from "vuex-class";

const User = namespace('CurrentUserStore')

@Component({components: {StringField}})
export default class FizContractPart extends Vue {
  @PropSync('localData') localDataSync!: VacuumTruckFizContract
  @Prop({required: false, default: () => false}) isView!: boolean;


  @User.Getter('FIO') fio!: string;
  @User.State('phoneNumber') phoneNumber!: string;
  @User.State('email') email!: string;

  mounted() {
    this.localDataSync.individualFullName = this.fio;
    this.localDataSync.phoneNumber = this.phoneNumber;
    this.localDataSync.email = this.email;
  }
}
</script>
<style scoped lang="scss">

</style>
