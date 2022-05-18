<template>
  <v-card>
    <v-card-title>Мето оказания услуги</v-card-title>
    <v-card-text>
      <string-field
          label="Мето оказания услуги"
          v-model="localDataSync.placeName"
      />
    </v-card-text>
  </v-card>
</template>

<script lang="ts">
import {Vue, Component, PropSync} from "vue-property-decorator";
import {BaseContract} from "@/services/ContractService/Requests";
import StringField from "@/components/Fields/StringField.vue";

@Component({
  components: {StringField}
})
export default class PlacePicker extends Vue {
  @PropSync('localData') localDataSync!: BaseContract;
}
</script>
<style scoped lang="scss">

</style>
