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
      <template v-slot:item.check="props">
        <v-icon @click="openPurchase(props.item.id)">mdi-eye</v-icon>
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
import AlertMixin from "@/mixins/AlertMixin.vue";

@Component
export default class AdminPurchases extends Mixins(HttpServiceMixin, AlertMixin) {
  headers = [
    {
      text: 'Услуга',
      value: 'serviceName',
    },
    {
      text: 'ФИО',
      value: 'userFullName'
    },
    {
      text: 'Место',
      value: 'place'
    },
    {
      text: 'Номер телефона',
      value: 'phoneNumber'
    },
    {
      text: 'Email',
      value: 'email'
    },
    {
      text: 'Открыть',
      value: 'check',
      align: 'center'
    },
    {
      text: 'Согласовано',
      value: 'isConfirmed',
      align: 'center'
    },
  ]

  data: PurchaseDto[] = []

  page: number = 1;
  pagesCount: number = 1;
  searchName: string = '';
  confirmedTypeId: ConfirmedType = ConfirmedType.NotCheck;

  async mounted() {
    await this.getPurchases();
  }

  async confirmPurchase(item: PurchaseDto) {
    await this.purchaseService.ConfirmPurchase(item.id, !item.isConfirmed)
        .then(() => {
          this.getPurchases()
          this.callAlert({
            message: 'Успешно',
            isError: false,
            delay: 7000
          })
        })
        .catch(error => this.callAlert({
          message: this.getErrorMessage(error),
          delay: 7000,
          isError: false
        }));
  }

  async getPurchases() {
    await this.purchaseService.GetAllPurchases(this.page, this.searchName, this.confirmedTypeId)
        .then(response => {
          this.data = response.data.purchases;
          this.pagesCount = response.data.pagesCount
        });

    this.data = this.data.map(item => ({...item, serviceName: getServiceName(item.serviceTypeId)}))
  }

  openPurchase(id: number) {
    this.$router.push(`purchase-info-admin/${id}`)
  }

  @Watch('searchName')
  async searchNameHandler(search: string | null) {
    if (!search) search = '';

    await this.getPurchases();
  }

  @Watch('page')
  async pagesCountChangeHandler() {
    await this.getPurchases();
  }
}
</script>
<style scoped lang="scss">

</style>
