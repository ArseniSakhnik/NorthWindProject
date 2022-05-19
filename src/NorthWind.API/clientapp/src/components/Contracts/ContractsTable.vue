<template>
  <div>
    <v-text-field
        v-model="search"
        append-icon="mdi-magnify"
        label="Поиск"
        single-line
        hide-details
        outlined
    >
    </v-text-field>
    <v-data-table
        :headers="headers"
        :items="data"
        :search="search"
    >
      <template v-slot:item.open="props">
        <v-icon @click="openContract(props.item.id)">mdi-eye</v-icon>
      </template>
      <template v-slot:item.delete="props">
        <v-icon @click="removeContract(props.item.id)">mdi-trash-can-outline</v-icon>
      </template>
    </v-data-table>
  </div>
</template>

<script lang="ts">
import {Vue, Component, Mixins} from "vue-property-decorator";
import HttpServiceMixin from "@/mixins/HttpServiceMixin.vue";
import AlertMixin from "@/mixins/AlertMixin.vue";

@Component
export default class ContractsTable extends Mixins(HttpServiceMixin, AlertMixin) {

  search: string = '';
  data: [] = []

  headers = [
    {
      text: 'Название услуги',
      value: 'serviceName',
    },
    {
      text: 'Место',
      value: 'placeName',
    },
    {
      text: 'Открыть',
      value: 'open',
      align: 'center'
    },
    {
      text: 'Удалить',
      value: 'delete',
      align: 'center'
    }
  ]

  openContract(id: number) {
    
  }

  async removeContract(id: number) {
    await this.contractService.RemoveContracts(id)
        .then(() => {
          this.callAlert({
            delay: 7000,
            message: 'Контракт был удален',
            isError: false
          })
        })
        .catch(error => {
          const errorMessage = this.getErrorMessage(error);
          this.callAlert({
            delay: 7000,
            message: errorMessage,
            isError: true
          });
        })

    await this.getContracts();
  }

  async created() {
    await this.getContracts();
  }

  async getContracts() {
    await this.contractService.GetUserContracts()
        .then(response => this.data = response.data);
  }

}
</script>
<style scoped lang="scss">

</style>
