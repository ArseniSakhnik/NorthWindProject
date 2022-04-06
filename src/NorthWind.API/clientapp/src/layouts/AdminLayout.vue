<template>
  <v-app>
    <v-main>
      <router-view/>
    </v-main>
  </v-app>
</template>

<script lang="ts">
import {Vue, Component} from 'vue-property-decorator'

@Component({components: {}})
export default class AdminLayout extends Vue {

}
</script>
<style scoped>

</style>
