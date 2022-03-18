<template>
  <v-alert
      type="success"
  >
    {{ message }}
  </v-alert>
</template>

<script lang="ts">
import {Vue, Component, Prop} from "vue-property-decorator";

@Component
export default class SuccessAlert extends Vue {
  @Prop() message!: string;
}
</script>
<style scoped lang="scss">

</style>
