<template>
  <div>
    <div class="background-image">
      <h2> Документы </h2>
    </div>
  </div>
</template>

<script lang="ts">
import {Vue, Component} from "vue-property-decorator";

@Component
export default class PurchaseInfo extends Vue {
  
}
</script>
<style scoped lang="scss">
.background-image {
  background-image: url('../assets/backgrounds/documents.jpg');
  height: 20vh;
}
</style>
