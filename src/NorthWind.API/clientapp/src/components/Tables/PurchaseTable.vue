<template>
  <div>
    <v-text-field
        v-model="search"
        append-icon="mdi-magnify"
        label="Поиск"
        single-line
        hide-details
        outlined
    ></v-text-field>
    <v-data-table
        :headers="headers"
        :items="data"
        :search="search"
    >
      <template v-slot:item.open="props">
        <v-icon @click="openPurchase(props.item)">mdi-eye</v-icon>
      </template>
      <template v-slot:item.delete="props">
        <v-icon @click="removePurchase(props.item)">mdi-trash-can-outline</v-icon>
      </template>
    </v-data-table>
  </div>
</template>

<script lang="ts">
import {Vue, Component, Mixins} from "vue-property-decorator";
import HttpServiceMixin from "@/mixins/HttpServiceMixin.vue";
import {getServiceName} from "@/utils/getServiceName";

@Component
export default class PurchaseTable extends Mixins(HttpServiceMixin) {
  search: string = '';

  headers = [
    {
      text: 'Услуга',
      value: 'serviceName',
    },
    {
      text: 'Место оказания услуги',
      value: 'placeName'
    },
    {
      text: '',
      value: 'open',
      sortable: false
    },
    {
      text: '',
      value: 'delete',
      sortable: false
    }
  ]

  data = []

  async mounted() {
    await this.getPurchases();
  }

  async getPurchases() {
    await this.purchaseService.GetPurchases()
        .then(response => {
          this.data = response.data.map((item: any) => ({
            ...item,
            serviceName: getServiceName(item.serviceTypeId)
          }))
        })
  }

  openPurchase(e: any) {
    this.$router.push(`/purchase-info/${e.id}`);
  }

  async removePurchase(e: any) {
    await this.purchaseService.DeletePurchase(e.id);
    await this.getPurchases();
  }


}
</script>
<style scoped lang="scss">

</style>
