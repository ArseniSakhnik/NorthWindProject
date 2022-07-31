<template>
  <div v-if="isActive" class="alert-section">
    <v-alert
        :type="isError ? 'error' : 'success'"
    >
      {{ alertMessage }}
    </v-alert>
  </div>

</template>

<script lang="ts">
import {Component, Vue} from "vue-property-decorator";
import {namespace} from "vuex-class";

const Alert = namespace('AlertStore')


@Component
export default class SuccessAlert extends Vue {
  @Alert.State('alertMessage') alertMessage!: string;
  @Alert.State('isError') isError!: boolean;
  @Alert.State('isActive') isActive!: boolean;
}
</script>
<style lang="scss" scoped>
.alert-section {
  position: fixed;
  top: 80vh;
  left: 0;
  z-index: 2;
}
</style>
