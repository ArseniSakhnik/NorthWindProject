<template>
  <v-footer
      app
      color="transparent"
      height="72"
      inset
  >
    <v-text-field
        background-color="grey lighten-1"
        dense
        flat
        hide-details
        rounded
        solo
    ></v-text-field>
  </v-footer>
</template>

<script lang="ts">
import {Vue, Component} from 'vue-property-decorator'

@Component
export default class AdminFooter extends Vue {
  
}
</script>
<style scoped>

</style>
