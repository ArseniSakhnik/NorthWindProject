<template>
  <v-container style="min-height: 100vh;">
    <v-data-table
        :headers="headers"
        :items="data"
        hide-default-footer
        class="elevation-1"
    >
      
      
    </v-data-table>
  </v-container>
</template>

<script lang="ts">
import {Component, Mixins} from "vue-property-decorator";
import HttpServiceMixin from "@/mixins/HttpServiceMixin.vue";
import {PurchaseDto} from "@/services/PurchaseService/Response";
import {getServiceName} from "@/utils/getServiceName";
import {ConfirmedType} from "@/enums/Enums";

@Component
export default class AdminPurchases extends Mixins(HttpServiceMixin) {
  headers: { text: string, value: string }[] = [
    {
      text: 'Услуга',
      value: 'serviceName'
    },
    {
      text: 'ФИО',
      value: 'userFullName'
    },
    {
      text: 'Согласовано',
      value: 'isConfirmed'
    }
  ]

  data: PurchaseDto[] = []

  page: number = 1;
  searchName: string = '';
  confirmedTypeId: ConfirmedType = ConfirmedType.NotCheck;

  async mounted() {
    await this.purchaseService.GetAllPurchases(this.page, this.searchName, this.confirmedTypeId)
        .then(response => this.data = response.data);

    this.data = this.data.map(item => ({...item, serviceName: getServiceName(item.serviceTypeId)}))
  }

  async getPurchases() {

  }
}
</script>
<style scoped lang="scss">

</style>
