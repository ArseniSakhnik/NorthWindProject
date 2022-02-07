<template>
  <v-app class="background-color">
    <navbar/>
    <router-view/>
  </v-app>
</template>

<script lang="ts">
import {Vue, Component} from 'vue-property-decorator'
import Navbar from "@/components/Navbar.vue"

@Component({components: {Navbar}})
export default class ActionLayout extends Vue {
  
}
</script>
<style scoped>
  .background-color {
    background-color: rgba(242,246,255,255);
  }
</style>
