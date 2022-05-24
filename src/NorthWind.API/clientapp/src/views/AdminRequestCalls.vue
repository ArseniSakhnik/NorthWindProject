<template>
  <v-container>
    <request-call-confirm
        :is-active.sync="isDialogActive"
        :local-data="currentItem"
    />
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
            @click:append="getRequestCalls"
            @keyup.e.enter="getRequestCalls"
            class="mx-4"
            placeholder="Поиск"
            clearable
        >
        </v-text-field>
      </template>
      <template v-slot:item.showComment="props">
        <v-icon @click="showComment(props.item)">mdi-eye</v-icon>
      </template>
    </v-data-table>
  </v-container>
</template>

<script lang="ts">
import {Vue, Component, Mixins} from "vue-property-decorator";
import HttpServiceMixin from "@/mixins/HttpServiceMixin.vue";
import {RequestCallDto} from "@/services/RequestCallService/Responses";
import moment from "moment";
import RequestCallConfirm from "@/components/Confirms/RequestCallConfirm.vue";

@Component({components: {RequestCallConfirm}})
export default class AdminRequestCalls extends Mixins(HttpServiceMixin) {
  headers = [
    {
      text: 'ФИО',
      value: 'name'
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
      text: 'Показать комментарий',
      value: 'showComment',
      sortable: false,
      align: 'center'
    }
  ];

  async mounted() {
    await this.getRequestCalls();
  }

  showComment(item: RequestCallDto) {
    this.currentItem = item;
    this.isDialogActive = true;
  }

  currentItem: RequestCallDto = {
    id: 0,
    comment: '',
    created: '',
    name: '',
    phoneNumber: ''
  }

  isDialogActive: boolean = false;

  data: RequestCallDto[] = []

  page: number = 1;
  pagesCount: number = 1;
  searchName: string = '';

  async getRequestCalls() {
    await this.requestCallService.GetRequestCalls(this.searchName, this.page)
        .then(response => {
          this.data = response.data.requestCalls.map(item => ({
            ...item,
            created: moment(item.created).format('DD-MM-YYYY')
          }));
          this.page = response.data.pagesCount;
        });
  }
}
</script>
<style scoped lang="scss">

</style>
