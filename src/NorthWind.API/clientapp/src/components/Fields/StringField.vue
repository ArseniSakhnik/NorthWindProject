<template>
  <v-form ref="formRef">
    <v-text-field
        v-mask="mask"
        :counter="counter"
        :disabled="isDisabled"
        :label="label"
        :prefix="prefix"
        :rules="rules"
        :suffix="suffix"
        :type="fieldType"
        :value="typedValue"
        dense
        outlined
        @input="valueChangeHandler"
    />
  </v-form>
</template>

<script lang="ts">
import {Component, ModelSync, Prop, Ref, Vue} from "vue-property-decorator";

@Component
export default class StringField extends Vue {
  @Ref('formRef') formRef!: any;

  @ModelSync('value', 'change')
  valueSync!: string | number;

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
  @Prop({type: String, required: false, default: () => 'text'})
  fieldType!: string;
  @Prop({type: Boolean, required: false, default: () => false})
  isNumber!: boolean;


  get typedValue() {
    if (this.isNumber) {
      return String(this.valueSync);
    }
    return this.valueSync;
  }

  set typedValue(value: string | number) {
    if (this.isNumber) {
      this.valueSync = Number(value);
    }
    this.valueSync = value;
  }

  valueChangeHandler(value: string) {
    this.typedValue = value;
  }

  validate(): boolean {
    this.formRef.validate();
    return this.rules.some(rule => {
      const result = rule(this.valueSync);
      return Boolean(result.length)
    })
  }
}
</script>
<style lang="scss" scoped>

</style>
