<template>
  <div>
    <h2 class="headline font-weight-bold mb-3">Персональные данные</h2>
    <v-row>
      <v-col
          cols="12"
          sm="4"
      >
        <string-field
            label="Фамилия"
            v-model="surnameSynced"
        />
      </v-col>
      <v-col
          cols="12"
          sm="4"
      >
        <string-field
            label="Имя"
            v-model="nameSynced"
        />
      </v-col>
      <v-col
          cols="12"
          sm="4"
      >
        <string-field
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
        <string-field
            label="Номер телефона"
            v-model="phoneNumberSynced"
            prefix="+7"
            v-mask="'(###)-###-##-##'"
        />
      </v-col>
      <v-col
          cols="12"
          sm="6"
      >
        <string-field
            label="Email"
            v-model="emailSynced"
            :rules="[emailRules]"
        />
      </v-col>
    </v-row>
    <v-row v-if="phoneNumberOrFaxSynced !== null">
      <v-col
          cols="12"
          sm="6"
      >
        <string-field
            label="Номер телефона или факс"
            v-model="phoneNumberOrFaxSynced"
        />
      </v-col>
    </v-row>
  </div>
</template>

<script lang="ts">
import {Vue, Component, PropSync, Watch} from "vue-property-decorator";
import StringField from "@/components/Fields/StringField.vue";
import {namespace} from "vuex-class";

const User = namespace('CurrentUserStore')

@Component({components: {StringField}})
export default class PersonalInformationInfo extends Vue {
  @PropSync('email') emailSynced!: string;
  @PropSync('phoneNumber') phoneNumberSynced!: string;
  @PropSync('name') nameSynced!: string;
  @PropSync('surname') surnameSynced!: string;
  @PropSync('middleName') middleNameSynced!: string;
  @PropSync('phoneNumberOrFax', {required: false, default: () => null}) phoneNumberOrFaxSynced!: string | null

  @User.State('email') emailUser!: string;
  @User.State('phoneNumber') phoneNumberUser!: string;
  @User.State('name') nameUser!: string;
  @User.State('surname') surnameUser!: string;
  @User.State('middleName') middleNameUser!: string;

  mounted() {
    this.initialData();
  }

  initialData() {
    this.emailSynced = this.emailUser;
    this.phoneNumberSynced = this.phoneNumberUser;
    this.nameSynced = this.nameUser;
    this.surnameSynced = this.surnameUser;
    this.middleNameSynced = this.middleNameUser;
  }

  emailRules(value: string): any {
    const pattern = /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/
    return pattern.test(value) || 'Неверный email'
  }
}
</script>
<style scoped lang="scss">

</style>
