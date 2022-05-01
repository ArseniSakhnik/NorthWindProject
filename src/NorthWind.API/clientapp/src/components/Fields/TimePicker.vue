<template>
  <div>
    <v-text-field
        :value="dateSyncedModel"
        label="Период оказания услуг"
        readonly
        @focus="openTimePicker"
    />
    <v-date-picker
        v-if="isTimePickerOpened"
        v-model="dateSyncedModel"
        locale="ru"
        @change="closeTimePicker"
    />
  </div>
</template>

<script lang="ts">
import {Component, Mixins, PropSync} from "vue-property-decorator";
import StringField from "@/components/Fields/StringField.vue";
import MomentMixin from "@/mixins/MomentMixin.vue";

@Component({components: {StringField}})
export default class TimePicker extends Mixins(MomentMixin) {
  @PropSync('date') dateSynced!: string;
  isTimePickerOpened: boolean = false;

  get dateSyncedModel() {
    if (!this.dateSynced.length && !this.isTimePickerOpened) {
      return '';
    }
    return this.getDateForCalendar(this.dateSynced)
  }

  set dateSyncedModel(value) {
    const date = this.$moment(value);
    this.dateSynced = date.toISOString(true);
  }

  openTimePicker() {

    this.isTimePickerOpened = true;
  }

  closeTimePicker() {
    this.isTimePickerOpened = false;
  }
}
</script>
<style lang="scss" scoped>

</style>
