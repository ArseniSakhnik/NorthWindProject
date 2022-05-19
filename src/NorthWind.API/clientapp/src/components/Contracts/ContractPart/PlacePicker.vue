<template>
  <v-card>
    <v-card-title>Место оказания услуги</v-card-title>
    <v-card-text>
      <string-field
          label="Место оказания услуги"
          v-model="localDataSync.placeName"
          :is-readonly="isView"
      />
    </v-card-text>
  </v-card>
</template>

<script lang="ts">
import {Vue, Component, PropSync, Prop} from "vue-property-decorator";
import {BaseContract} from "@/services/ContractService/Requests";
import StringField from "@/components/Fields/StringField.vue";

@Component({
  components: {StringField}
})
export default class PlacePicker extends Vue {
  @PropSync('localData') localDataSync!: BaseContract;
  @Prop({required: false, default: () => false}) isView!: boolean;
}
</script>
<style scoped lang="scss">

</style>
