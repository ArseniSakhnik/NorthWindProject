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
  </div>
</template>

<script lang="ts">
import {Vue, Component} from "vue-property-decorator";

@Component
export default class ContractsTable extends Vue {
  search: string = '';

}
</script>
<style scoped lang="scss">

</style>
