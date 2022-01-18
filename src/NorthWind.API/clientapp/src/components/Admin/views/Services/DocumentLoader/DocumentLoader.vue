<template>
  <div>
    <v-file-input
      v-model="file"
    /> 
    <v-btn @click="test">test</v-btn>
  </div>
</template>

<script lang="ts">
import {Vue, Component} from 'vue-property-decorator'

@Component
export default class DocumentLoader extends Vue {
  private file: any = {};
  
}
</script>
<style scoped>

</style>
