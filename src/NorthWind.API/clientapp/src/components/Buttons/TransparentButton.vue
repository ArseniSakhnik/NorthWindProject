<template>
  <button class="button">
    Подробнее
  </button>
</template>

<script lang="ts">
import {Vue, Component} from "vue-property-decorator";

@Component
export default class TransparentButton extends Vue {

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

  background-color: rgba(255, 255, 255, 0.9);
}

@supports (-webkit-backdrop-filter: none) or (backdrop-filter: none) {
  .button {
    -webkit-backdrop-filter: blur(10px);
    backdrop-filter: blur(1px);
    background-color: rgba(255, 255, 255, 0.2);
  }
}
</style>
