<template>
  <div>
    <h2 class="headline font-weight-bold mb-3">Данные по заявке</h2>
    <v-row>
      <v-col
          cols="12"
          sm="4"
      >
        <v-select
            :items="items"
            item-text="name"
            item-value="id"
            v-model="wasteTypeSynced"
            label="Тип отходов*"
            outlined
            dense
            :readonly="isView"
        ></v-select>
      </v-col>
      <v-col
          cols="12"
          sm="4"
      >
        <string-field
            ref="2"
            v-model="pitVolumeSynced"
            label="Примерный объем выгребной ямы*"
            mask="####"
            prefix="м³"
            :is-number="true"
            :is-readonly="isView"
            :rules="[isStringNotEmpty]"
        />
      </v-col>
      <v-col
          cols="12"
          sm="4"
      >
        <string-field
            ref="3"
            v-model="distanceFromDrivewaySynced"
            label="Расстояние от подъездных путей*"
            mask="####"
            prefix="м"
            :is-number="true"
            :is-readonly="isView"
            :rules="[isStringNotEmpty]"
        />
      </v-col>
    </v-row>
  </div>
</template>

<script lang="ts">
import {Component, Mixins, Prop, PropSync, Vue} from "vue-property-decorator";
import StringField from "@/components/Fields/StringField.vue";
import {WasteType} from "@/enums/Enums";
import ValidationMixin from "@/mixins/ValidationMixin.vue";

@Component({
  components: {StringField}
})
export default class AssenizatorPurchase extends Mixins(ValidationMixin) {
  @Prop({required: false, default: () => false}) isView!: boolean;
  @PropSync('wasteType') wasteTypeSynced!: number;
  @PropSync('pitVolume') pitVolumeSynced!: number;
  @PropSync('distanceFromDriveway') distanceFromDrivewaySynced!: number;

  items = [
    {
      id: WasteType.cessPool,
      name: 'Выгребная яма'
    },
    {
      id: WasteType.sewageCarWashes,
      name: 'Уличный туалет'
    },
    {
      id: WasteType.outdoorToilet,
      name: 'Cточные воды автомоек'
    },
    {
      id: WasteType.other,
      name: 'Другое (Указать в комментарии)'
    }
  ]
}
</script>
<style scoped lang="scss">

</style>
