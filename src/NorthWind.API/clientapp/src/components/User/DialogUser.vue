<template>
  <v-dialog
      ref="dialogRef"
      persistent
      width="500"
      @click:outside="toggleRegisterWindow(false)"
      scrollable
  >
    <v-card>
      <v-card-title>
        Данные пользователя
      </v-card-title>
      <v-card-text>
        <string-field
            v-model="localData.fullName"
            label="ФИО"
            :is-readonly="true"
        />
        <string-field
            v-model="localData.email"
            label="Email"
            :is-readonly="true"
        />
        <string-field
            v-model="localData.phoneNumber"
            label="Номер телефона"
            :is-readonly="true"
            prefix="+7"
        />
        <v-select
            v-model="selectedRoles"
            :items="roles"
            multiple
            outlined
            dense
            item-text="text"
            item-value="value"
            label="Выберите роли"
            persistent-hint
        />
      </v-card-text>
      <v-card-actions>
        <v-spacer/>
        <v-btn
            class="orange darken-3 text-white"
            text
            @click="toggleRegisterWindow(false)"
        >
          Закрыть
        </v-btn>
        <v-btn
            class="orange darken-3 text-white"
            text
            @click="changeRoles"
        >
          Отправить
        </v-btn>
      </v-card-actions>
    </v-card>

  </v-dialog>
</template>

<script lang="ts">
import {Component, Emit, Mixins, Prop, Watch} from "vue-property-decorator";
import DialogWindowMixin from "@/mixins/DialogWindowMixin.vue";
import {UserDto} from "@/services/AccountService/ResponsesAccountService";
import StringField from "@/components/Fields/StringField.vue";
import {RolesEnum} from "@/enums/Enums";
import HttpServiceMixin from "@/mixins/HttpServiceMixin.vue";
import AlertMixin from "@/mixins/AlertMixin.vue";

@Component({
  components: {StringField}
})
export default class DialogUser extends Mixins(DialogWindowMixin, HttpServiceMixin, AlertMixin) {
  @Prop() localData!: UserDto;

  selectedRoles: RolesEnum[] = [];

  roles = [
    {
      text: 'Администратор',
      value: RolesEnum.Admin
    },
    {
      text: 'Пользователь',
      value: RolesEnum.Client
    }
  ]

  @Watch('localData')
  localDataChangeHandler(value: UserDto) {
    this.selectedRoles = value.roles;
  }

  @Emit() updateData(e: any) {
    return e;
  }

  async changeRoles() {
    await this.accountService.ChangeUserRoles(this.localData.userId, this.selectedRoles)
        .then(() => {
          this.callAlert({
            message: 'Роли были изменены',
            delay: 7000,
            isError: false
          })
          this.isConfirmActive = false;
          this.updateData(null);
        })
        .catch(error => {
          this.callAlert({
            message: this.getErrorMessage(error),
            delay: 7000,
            isError: true
          })
        });
  }
}
</script>
<style scoped lang="scss">

</style>
