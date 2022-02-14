<template>
  <v-app class="background-color">
    <navbar/>
    <div class="background-image"/>
    <router-view/>
    <action-bar/>
  </v-app>
</template>

<script lang="ts">
import {Vue, Component} from 'vue-property-decorator'
import Navbar from "@/components/Navbar.vue"
import ActionBar from "@/components/ActionBars/ActionBar.vue";

@Component({components: {ActionBar, Navbar}})
export default class ActionLayout extends Vue {

}
</script>
<style scoped lang="scss">
.background-color {
  background-color: rgba(242, 246, 255, 255);
}

.background-image {
  background-image: url('../assets/purchases/vacuumTruck/insignts-1-1192699.jpg');
  position: relative;
  background-blend-mode: multiply;
  background-position: center bottom;
  background-color: rgba(#1b3648, 0.35);
  background-size: cover;
  background-repeat: no-repeat;
  width: 100%;
  height: 15vh;
}
</style>
