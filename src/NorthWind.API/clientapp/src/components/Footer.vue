<template>
  <div>
    <div class="footer-first-section">
      <div class="flex-container">

      </div>
    </div>
    <div class="footer-second-section">
      <div class="dividing-line-container">
        <div class="dividing-line"/>
      </div>
      <div class="flex-container">
          
      </div>
    </div>
  </div>
</template>

<script lang="ts">
import {Vue, Component} from "vue-property-decorator";

@Component
export default class FooterSection extends Vue {

}
</script>
<style scoped lang="scss">
.footer-first-section {
  width: 100%;
  height: 269px;
  background: #002C58;
  
  .flex-container {
    
  }
}

.footer-second-section {
  width: 100%;
  height: 60px;
  background: #002347;

  .dividing-line-container {
    padding-left: 10%;
    padding-right: 10%;

    .dividing-line {
      width: 100%;
      height: 0;
      border: 2px solid rgba(242, 246, 255, 0.2);
    }
  }
}
</style>
