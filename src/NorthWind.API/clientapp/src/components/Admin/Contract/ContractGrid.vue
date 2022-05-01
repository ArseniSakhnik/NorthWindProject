<template>
  <dx-data-grid
      ref="dataGrid"
      :allow-column-reordering="false"
      :allow-column-resizing="false"
      :column-auto-width="true"
      :column-hiding-enabled="false"
      :data-source="dataSource"
      :highlight-changes="true"
      :hover-state-emabled="true"
      :remote-operations="true"
      :repaint-changes-only="true"
      :row-alternation-enabled="false"
      :show-borders="true"
      :show-row-lines="false"
      :word-wrap-enabled="true"
  >
    <dx-column
        :allow-editing="false"
        caption="ФИО"
        data-field="clientFullName"
    />
    <dx-column
        :allow-editing="false"
        caption="Номер телефона"
        data-field="phoneNumber"
    />
    <dx-column
        :allow-editing="false"
        caption="Email"
        data-field="email"
    />
    <dx-column
        :allow-editing="false"
        caption="Дата создания"
        data-field="created"
    />
  </dx-data-grid>
</template>

<script lang="ts">
import {Component, Mixins, Ref} from "vue-property-decorator";
import HttpServiceMixin from "@/mixins/HttpServiceMixin.vue";
import {DxDataGrid} from "devextreme-vue";
import {DxColumn} from "devextreme-vue/data-grid";

@Component({components: {DxDataGrid, DxColumn}})
export default class ContractGrid extends Mixins(HttpServiceMixin) {
  @Ref('dataGrid')
  dataGrid!: any;

  get dataSource() {
    return this.contractService.GetContracts();
  }
}
</script>
<style lang="scss" scoped>

</style>
