<template>
  <v-alert
      type="success"
  >
    {{ message }}
  </v-alert>
</template>

<script lang="ts">
import {Component, Prop, Vue} from "vue-property-decorator";

@Component
export default class SuccessAlert extends Vue {
  @Prop() message!: string;
}
</script>
<style lang="scss" scoped>

</style>
