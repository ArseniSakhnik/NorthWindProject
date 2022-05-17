<template>
  <v-container style="min-height: 100vh;">
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
            @click:append="getPurchases"
            @keyup.e.enter="getPurchases"
            class="mx-4"
            placeholder="Поиск"
            clearable
        >

        </v-text-field>
      </template>
      <template v-slot:item.isConfirmed="props">
        <v-icon v-if="!props.item.isConfirmed" @click="confirmPurchase(props.item)">mdi-thumb-down</v-icon>
        <v-icon v-else @click="confirmPurchase(props.item)">mdi-thumb-up</v-icon>
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
import {Component, Mixins, Watch} from "vue-property-decorator";
import HttpServiceMixin from "@/mixins/HttpServiceMixin.vue";
import {PurchaseDto} from "@/services/PurchaseService/Response";
import {getServiceName} from "@/utils/getServiceName";
import {ConfirmedType} from "@/enums/Enums";

@Component
export default class AdminPurchases extends Mixins(HttpServiceMixin) {
  headers: { text: string, value: string }[] = [
    {
      text: 'Услуга',
      value: 'serviceName',
    },
    {
      text: 'Место',
      value: 'place'
    },
    {
      text: 'ФИО',
      value: 'userFullName'
    },
    {
      text: 'Номер телефона',
      value: 'phoneNumber'
    },
    {
      text: 'Согласовано',
      value: 'isConfirmed'
    },
  ]

  data: PurchaseDto[] = []

  page: number = 1;
  pagesCount: number = 1;
  searchName: string = '';
  confirmedTypeId: ConfirmedType = ConfirmedType.NotCheck;

  async mounted() {
    await this.getPagesCount();
    await this.getPurchases();
  }

  async confirmPurchase(item: PurchaseDto) {
    await this.purchaseService.ConfirmPurchase(item.id, !item.isConfirmed)
        .then(() => this.getPurchases());
  }

  async getPurchases() {
    await this.purchaseService.GetAllPurchases(this.page, this.searchName, this.confirmedTypeId)
        .then(response => this.data = response.data);

    this.data = this.data.map(item => ({...item, serviceName: getServiceName(item.serviceTypeId)}))
  }

  async getPagesCount() {
    await this.purchaseService.GetPagesCount()
        .then(response => this.pagesCount = response.data);
  }

  @Watch('searchName')
  async searchNameHandler(search: string | null) {
    if (!search) search = '';
    
    await this.getPagesCount();
    await this.getPurchases();
    
    this.page = 1;
  }

  @Watch('page')
  async pagesCountChangeHandler() {
    await this.getPurchases();
  }
}
</script>
<style scoped lang="scss">

</style>
