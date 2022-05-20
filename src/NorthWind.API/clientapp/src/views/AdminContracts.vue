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
            @click:append="getContracts"
            @keyup.e.enter="getContracts"
            class="mx-4"
            placeholder="Поиск"
            clearable
        >
        </v-text-field>
      </template>
    </v-data-table>
    <v-pagination
        v-model="page"
        :length="pagesCount"
        :total-visible="5"
    ></v-pagination>
  </v-container>
</template>

<script lang="ts">
import {Vue, Component, Mixins, Watch} from "vue-property-decorator";
import {ContractDto} from "@/services/ContractService/Responses";
import {ConfirmedType} from "@/enums/Enums";
import HttpServiceMixin from "@/mixins/HttpServiceMixin.vue";
import MomentMixin from "@/mixins/MomentMixin.vue";
import moment from "moment";

@Component
export default class AdminContracts extends Mixins(HttpServiceMixin, MomentMixin) {
  headers: { text: string, value: string }[] = [
    {
      text: 'Услуга',
      value: 'serviceName'
    },
    {
      text: 'Место',
      value: 'placeName'
    },
    {
      text: 'ФИО',
      value: 'clientFullName'
    },
    {
      text: 'Номер телефона',
      value: 'phoneNumber'
    },
    {
      text: 'Дата создания',
      value: 'created'
    },
    {
      text: 'Email',
      value: 'email'
    }
  ]

  data: ContractDto[] = []

  page: number = 1;
  pagesCount: number = 1;
  searchName: string = '';
  confirmedTypeId: ConfirmedType = ConfirmedType.NotCheck;

  async mounted() {
    await this.getContracts();
  }

  async getContracts() {
    await this.contractService.GetContracts(this.page, this.searchName, this.confirmedTypeId)
        .then(response => {
          this.data = response.data.contracts.map(item => ({
            ...item,
            created: moment(item.created).format('DD-MM-YYYY')
          }));
          this.pagesCount = response.data.pageCount;
        });
  }

  @Watch('searchName')
  async searchNameHandler(search: string | null) {
    if (!search) search = '';

    await this.getContracts();

    this.page = 1;
  }
  
  @Watch('page')
  async pageChangeHandler() {
    await this.getContracts()
  }
}
</script>
<style scoped lang="scss">
</style>
