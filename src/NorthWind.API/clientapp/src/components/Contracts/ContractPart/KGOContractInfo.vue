<template>
  <v-card>
    <v-card-title>Предмет договора</v-card-title>
    <v-card-text>
      <v-select
          :items="volumeItems"
          item-text="name"
          item-value="name"
          v-model="localDataSync.volume"
          label="Тип отходов"
          outlined
          dense
      />
      <v-text-field
          v-model="localDataSync.overload"
          label="Не допускать перегрузка выше"
          outlined
          dense
          readonly
      />
    </v-card-text>
  </v-card>
</template>

<script lang="ts">
import {Vue, Component, PropSync, Watch} from "vue-property-decorator";
import {KgoYurContract} from "@/services/ContractService/Requests";

@Component
export default class KGOContractInfo extends Vue {
  @PropSync('localData') localDataSync!: KgoYurContract;

  volumeItems: { name: string }[] = [
    {
      name: '8 м.куб.'
    },
    {
      name: '27 м.куб.'
    }
  ];

  overloadItems: { name: string }[] = [
    {
      name: '4000 кг'
    },
    {
      name: '12000 кг'
    }
  ]

  @Watch('localDataSync.volume')
  localDataSyncChangeHandler(value: string) {
    if (value === '8 м.куб.') {
      this.localDataSync.overload = '4000 кг';
    }

    if (value === '27 м.куб.') {
      this.localDataSync.overload = '12000 кг';
    }
  }

}
</script>
<style scoped lang="scss">

</style>
