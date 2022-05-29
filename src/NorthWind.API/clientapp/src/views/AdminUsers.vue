<template>
  <v-container>
    <v-data-table
        :headers="headers"
        :items="data"
        hide-default-footer
        class="elevation-1"
    >
      <template v-slot:top>
        <v-text-field
            v-model="searchName"
            append-icon="mdi-account-search"
            @click:append="getUsers"
            @keyup.e.enter="getUsers"
            class="mx-4"
            placeholder="Поиск"
            clearable
        >
        </v-text-field>
      </template>
      <template v-slot:item.open="props">
        <v-icon @click="redactUser(props.item)">mdi-grease-pencil</v-icon>
      </template>
    </v-data-table>
    <v-pagination
        v-model="page"
        :length="pagesCount"
        :total-visible="5"
    ></v-pagination>
    <dialog-user
        :local-data="selectedUser"
        :is-active.sync="isUserDialogActive"
        @update-data="getUsers"
    />
  </v-container>
</template>

<script lang="ts">
import {Vue, Component, Mixins, Watch} from "vue-property-decorator";
import {RolesEnum} from "@/enums/Enums";
import {UserDto} from "@/services/AccountService/ResponsesAccountService";
import HttpServiceMixin from "@/mixins/HttpServiceMixin.vue";
import DialogUser from "@/components/User/DialogUser.vue";

@Component({
  components: {DialogUser}
})
export default class AdminUsers extends Mixins(HttpServiceMixin) {
  headers = [
    {
      text: 'ФИО',
      value: 'fullName'
    },
    {
      text: 'Роли',
      value: 'roleNames'
    },
    {
      text: 'Номера телефона',
      value: 'phoneNumber'
    },
    {
      text: 'Просмотреть/редактировать',
      value: 'open',
      sortable: false,
      align: 'center'
    }
  ]

  data: UserDto[] = []

  selectedUser: UserDto = {
    email: "",
    emailConfirmed: false,
    fullName: "",
    middleName: "",
    name: "",
    phoneNumber: "",
    roles: [],
    surname: "",
    userId: 0
  }
  isUserDialogActive: boolean = false;

  page: number = 1;
  pagesCount: number = 1;
  searchName: string = '';
  roleTypeId: RolesEnum = RolesEnum.All;

  async mounted() {
    await this.getUsers();
  }

  redactUser(user: UserDto) {
    this.selectedUser = user;
    this.isUserDialogActive = true;
  }

  async getUsers() {
    await this.accountService.GetUsersAll(this.page, this.searchName, this.roleTypeId)
        .then(response => {
          this.data = response.data.users;
          this.pagesCount = response.data.pagesCount;
        })
  }

  @Watch('page')
  async pageChangeHandler() {
    await this.getUsers();
  }
}
</script>
<style scoped lang="scss">

</style>
