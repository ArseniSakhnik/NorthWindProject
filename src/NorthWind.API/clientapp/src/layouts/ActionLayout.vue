<template>
  <v-app class="background-color">
    <navbar/>
    <div class="background-image"/>
    <router-view/>
  </v-app>
</template>

<script lang="ts">
import {Component, Vue} from 'vue-property-decorator'
import Navbar from "@/components/Navbar.vue"
import ActionBar from "@/components/ActionBars/ActionBar.vue";


@Component({components: {ActionBar, Navbar}})
export default class ActionLayout extends Vue {

}
</script>
<style lang="scss">
.background-color {
  background-color: rgba(242, 246, 255, 255);
}

.background-image {
  background-image: url('../assets/contracts/vacuumTruck/insignts-1-1192699.jpg');
  position: relative;
  background-blend-mode: multiply;
  background-position: center bottom;
  background-color: rgba(#1b3648, 0.35);
  background-size: cover;
  background-repeat: no-repeat;
  width: 100%;
  height: 15vh;
}

@media screen and (max-width: 600px) {
  .text-block-setting {
    font-size: 26px
  }
}

@media screen and (min-width: 601px) and (max-width: 960px) {
  .text-block-setting {
    font-size: 34px;
  }
}

@media screen and (min-width: 961px) and (max-width: 1264px) {
  .text-block-setting {
    font-size: 40px;
  }
}

@media screen and (min-width: 1080px) {
  .text-block-setting {
    font-size: 48px;
  }
}
</style>
