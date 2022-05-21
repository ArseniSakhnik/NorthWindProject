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
      <template v-slot:item.confirm="props">
        <v-icon v-if="!props.item.isConfirmed" @click="confirmPurchase(props.item)">mdi-thumb-down</v-icon>
        <v-icon v-else @click="confirmPurchase(props.item)">mdi-thumb-up</v-icon>
      </template>
      <template v-slot:item.open="props">
        <v-icon @click="openPurchase(props.item.id)">mdi-eye</v-icon>
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
import AlertMixin from "@/mixins/AlertMixin.vue";

@Component
export default class AdminContracts extends Mixins(HttpServiceMixin, MomentMixin, AlertMixin) {
  headers = [
    {
      text: 'Услуга',
      value: 'serviceName'
    },
    {
      text: 'ФИО',
      value: 'clientFullName'
    },
    {
      text: 'Место',
      value: 'placeName'
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
    },
    {
      text: 'Открыть',
      value: 'open'
    },
    {
      text: 'Подтверждено',
      value: 'confirm',
      align: 'center',
      sortable: false
    },
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

  openPurchase(contractId: number) {
    //@ts-ignore
    this.$router.push(`/contract-info-admin/${contractId}`);
  }

  async confirmPurchase(item: any) {
    await this.contractService.ConfirmContract(item.id, !item.isConfirmed)
        .then(() => this.callAlert({
          message: 'Успешно',
          delay: 7000,
          isError: false
        }))
        .catch(error => this.callAlert({
          message: this.getErrorMessage(error),
          delay: 7000,
          isError: true
        }));

    await this.getContracts();
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
