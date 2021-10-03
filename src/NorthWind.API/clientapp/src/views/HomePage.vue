<template>
  <div>
      Привет
  </div>
</template>

<script lang="ts">
import {defineComponent} from "vue";

export default defineComponent({
  name: "HomePage",
  created() {
    console.log('Привет')
  }
})
</script>

<style scoped>

</style>