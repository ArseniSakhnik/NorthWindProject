<template>
  <div>
    <div class="arrow"/>
  </div>
</template>

<script lang="ts">
import {Vue, Component} from "vue-property-decorator";

@Component
export default class Arrow extends Vue {
  
}
</script>
<style scoped lang="scss">
.arrow {
  /* Group 15 */

  position: absolute;
  width: 34px;
  height: 34px;

  filter: drop-shadow(-1px -1px 14px #FFA665);


  /* Ellipse 8 */

  position: absolute;
  width: 34px;
  height: 34px;

  background: rgba(243, 243, 243, 0.12);
  border: 1px solid #FF9B52;
  box-sizing: border-box;
  backdrop-filter: blur(4px);
  /* Note: backdrop-filter has minimal browser support */


  /* arrow-right */

  position: absolute;
  width: 24px;
  height: 24px;



  /* Vector */

  position: absolute;
  left: 20.83%;
  right: 20.83%;
  top: 50%;
  bottom: 50%;

  border: 2px solid #FF9B52;


  /* Vector */

  position: absolute;
  left: 50%;
  right: 20.83%;
  top: 20.83%;
  bottom: 20.83%;

  border: 2px solid #FF9B52;

}
</style>
