<template>
  <v-card>
    <v-card-title>Реквизиты заказчика</v-card-title>
    <v-card-text>
      <string-field
          v-model="localDataSync.iNN"
          label="ИНН"
          mask="############"
          :is-readonly="isView"
      />
      <string-field
          v-model="localDataSync.kPP"
          label="КПП"
          mask="#########"
          :is-readonly="isView"
      />
      <string-field
          v-model="localDataSync.oGRN"
          label="ОГРН"
          mask="############"
          :is-readonly="isView"
      />
      <string-field
          v-model="localDataSync.oKPO"
          label="ОКПО"
          mask="##########"
          :is-readonly="isView"
      />
      <string-field
          v-model="localDataSync.yurAddress"
          label="Юридический адрес"
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
import {BaseYurContract} from "@/services/ContractService/Requests";
import StringField from "@/components/Fields/StringField.vue";
import {namespace} from "vuex-class";

const User = namespace('CurrentUserStore')

@Component({components: {StringField}})
export default class YurContractPart extends Vue {
  @PropSync('localData') localDataSync!: BaseYurContract;
  @Prop({required: false, default: () => false}) isView!: boolean;


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
