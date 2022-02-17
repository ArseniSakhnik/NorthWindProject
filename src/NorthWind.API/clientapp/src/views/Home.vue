<template>
  <div class="home-page text-block-setting">
    <first-section/>

  </div>
</template>

<!--<second-section/>-->
<!--<section class="service-list">-->

<!--</section>-->
<!--<section style="height: 1000px">-->
<!--хуй-->
<!--</section>-->

<script lang="ts">
import {Vue, Component} from 'vue-property-decorator'
import FirstSection from "@/components/HomePage/FirstSection.vue";
import SecondSection from "@/components/HomePage/SecondSection.vue";

@Component({
  components: {SecondSection, FirstSection}
})
export default class Home extends Vue {

}
</script>
<style scoped lang="scss">
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

