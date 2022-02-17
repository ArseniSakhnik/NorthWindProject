<template>
  <button class="button">
    {{ title }}
  </button>
</template>

<script lang="ts">
import {Vue, Component, Prop} from "vue-property-decorator";

@Component
export default class OrangeButton extends Vue {
  @Prop({type: String}) title!: string;
}
</script>
<style scoped lang="scss">
.button {
  color: white;
  background-color: #FF782E;
  padding: 0.9em 3.6em;
  font-size: 0.35em;
  
  font-family: 'Raleway', 'serif';
  font-style: normal;
  letter-spacing: 0.1em;
  font-weight: 800;
  text-transform: uppercase;


  box-shadow: 0 0 12px #FFA665;
  -moz-box-shadow: 0 0 12px #FFA665;
  -o-box-shadow: 0 0 12px #FFA665;
  -ms-box-shadow: 0 0 12px #FFA665;
  -webkit-box-shadow: 0 0 12px #FFA665;
  
}
</style>
