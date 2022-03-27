<template>
  <button class="button" @click="action">
    Подробнее
  </button>
</template>

<script lang="ts">
import {Vue, Component, Emit} from "vue-property-decorator";

@Component
export default class TransparentButton extends Vue {
  @Emit()
  action(e: any) {
    return e;
  }
}
</script>
<style scoped lang="scss">
.button {
  color: white;
  padding: 0.9em 3.6em;
  font-size: 0.35em;

  font-family: 'Raleway', 'serif';
  font-style: normal;
  letter-spacing: 0.1em;
  font-weight: 800;
  text-transform: uppercase;

  background: rgba(0, 35, 71, 0.1);
  border: 1px solid rgba(255, 255, 255, 0.18);
  box-sizing: border-box;
  backdrop-filter: blur(5px);
}
</style>
