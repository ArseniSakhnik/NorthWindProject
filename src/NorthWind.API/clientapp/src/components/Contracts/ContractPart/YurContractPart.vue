<template>
  <v-card>
    <v-card-title>Реквизиты заказчика</v-card-title>
    <v-card-text>
      <string-field
          v-model="localDataSync.iNN"
          label="ИНН"
          mask="############"
      />
      <string-field
          v-model="localDataSync.kPP"
          label="КПП"
          mask="#########"
      />
      <string-field
          v-model="localDataSync.oGRN"
          label="ОГРН"
          mask="############"
      />
      <string-field
          v-model="localDataSync.oKPO"
          label="ОКПО"
          mask="##########"
      />
      <string-field
          v-model="localDataSync.yurAddress"
          label="Юридический адрес"
      />
      <string-field
          v-model="localDataSync.phoneNumber"
          label="Номер телефона"
          prefix="+7"
      />
      <string-field
          v-model="localDataSync.email"
          label="Email"
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
export default class YurContractPart extends Vue {
  @PropSync('localData') localDataSync!: BaseYurContract;

  @User.State('phoneNumber') phoneNumber!: string;
  @User.State('email') email!: string;

  created() {
    this.localDataSync.phoneNumber = this.phoneNumber;
    this.localDataSync.email = this.email;
  }

}
</script>
<style scoped lang="scss">

</style>
