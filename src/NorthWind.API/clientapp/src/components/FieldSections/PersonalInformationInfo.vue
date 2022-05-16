<template>
  <div>
    <h2 class="headline font-weight-bold mb-3">Персональные данные</h2>
    <v-row>
      <v-col
          cols="12"
          sm="4"
      >
        <string-field
            ref="1"
            v-model="surnameSynced"
            :rules="[isStringNotEmpty]"
            label="Фамилия*"
            :is-readonly="this.isView"
        />
      </v-col>
      <v-col
          cols="12"
          sm="4"
      >
        <string-field
            ref="2"
            v-model="nameSynced"
            :rules="[isStringNotEmpty]"
            label="Имя*"
            :is-readonly="this.isView"
        />
      </v-col>
      <v-col
          cols="12"
          sm="4"
      >
        <string-field
            ref="3"
            v-model="middleNameSynced"
            :rules="[isStringNotEmpty]"
            label="Отчество*"
            :is-readonly="this.isView"
        />
      </v-col>
    </v-row>
    <v-row>
      <v-col
          cols="12"
          sm="6"
      >
        <string-field
            ref="4"
            v-model="phoneNumberSynced"
            v-mask="'(###)-###-##-##'"
            :rules="[isStringNotEmpty]"
            label="Номер телефона*"
            prefix="+7"
            :is-readonly="this.isView"
        />
      </v-col>
      <v-col
          cols="12"
          sm="6"
      >
        <string-field
            ref="5"
            v-model="emailSynced"
            :rules="[emailRules, isStringNotEmpty]"
            label="Email*"
            :is-readonly="this.isView"
        />
      </v-col>
    </v-row>
    <v-row v-if="phoneNumberOrFaxSynced !== null">
      <v-col
          cols="12"
          sm="6"
      >
        <string-field
            ref="6"
            v-model="phoneNumberOrFaxSynced"
            :rules="[isStringNotEmpty]"
            label="Номер телефона или факс*"
            :is-readonly="this.isView"
        />
      </v-col>
    </v-row>
  </div>
</template>

<script lang="ts">
import {Component, Mixins, Prop, PropSync} from "vue-property-decorator";
import StringField from "@/components/Fields/StringField.vue";
import {namespace} from "vuex-class";
import ValidationMixin from "@/mixins/ValidationMixin.vue";

const User = namespace('CurrentUserStore')

@Component({components: {StringField}})
export default class PersonalInformationInfo extends Mixins(ValidationMixin) {
  @Prop({required: false, default: () => false}) isView!: boolean;
  
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
    if (this.isView) return;
    
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
<style lang="scss" scoped>

</style>
