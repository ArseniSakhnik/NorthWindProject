<template>
  <v-text-field
      v-mask="mask"
      :value="valueSync"
      :counter="counter"
      :label="label"
      :prefix="prefix"
      :suffix="suffix"
      :rules="rules"
      :disabled="isDisabled"
      @input="valueChangeHandler"
      outlined
      dense
  />
</template>

<script lang="ts">
import {Vue, Component, ModelSync, Prop, Watch} from "vue-property-decorator";

@Component
export default class StringField extends Vue {
  @ModelSync('value', 'change', {type: String})
  valueSync!: string;

  @Prop({type: String, required: false, default: null})
  mask!: string | null;
  @Prop({type: String, required: false, default: ''})
  label!: string;
  @Prop({type: String, required: false, default: ''})
  suffix!: string;
  @Prop({type: Number, required: false, default: null})
  counter!: number | null;
  @Prop({type: Function, required: false, default: null})
  valueHandler!: ((value: string) => string) | null;
  @Prop({required: false, default: () => ([])})
  rules!: any[];
  @Prop({type: String, required: false, default: ''})
  prefix!: string;
  @Prop({type: Boolean, required: false, default: false})
  isDisabled!: boolean;

  valueChangeHandler(value: string) {
    this.valueSync = value;
  }
}
</script>
<style scoped lang="scss">

</style>
