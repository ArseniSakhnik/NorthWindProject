<template>
  <div>
    <div class="background-image">
    </div>
    <v-container class="user-section">
      
    </v-container>
  </div>
</template>

<script lang="ts">
import {Component, Vue} from "vue-property-decorator";

@Component
export default class UserInfo extends Vue {

}
</script>
<style lang="scss" scoped>
.background-image {
  background-image: url('../assets/backgrounds/phons.png');
}

.user-section {
  min-height: 100vh;
  background-color: #f2f6ff;
}
</style>
