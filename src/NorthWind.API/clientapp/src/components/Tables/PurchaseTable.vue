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
        :items="desserts"
        :search="search"
    >
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
      value: 'serviceName'
    },
    {
      text: 'Место оказания услуги',
      value: 'place'
    }
  ]

  desserts = []

  async mounted() {
    console.log(1)
    await this.purchaseService.GetPurchases()
        .then(response => {
          this.desserts = response.data.map((item: any) => ({
            ...item,
            serviceName: getServiceName(item.serviceTypeId)
          }))
        })
  }


}
</script>
<style scoped lang="scss">

</style>
