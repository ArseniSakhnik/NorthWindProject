<template>
  <div class="home-page text-block-setting">
    <div class="second-section-opened" v-if="isSecondSectionOpened"/>
    <first-section/>
    <second-section/>
    <third-section/>
  </div>
</template>

<script lang="ts">
import {Vue, Component} from 'vue-property-decorator'
import FirstSection from "@/components/HomePage/FirstSection.vue";
import SecondSection from "@/components/HomePage/SecondSection.vue";
import ThirdSection from "@/components/HomePage/thirdSection/ThirdSection.vue";

@Component({
  components: {ThirdSection, SecondSection, FirstSection}
})
export default class Home extends Vue {
  private isSecondSectionOpened: boolean = false;
}
</script>

<style scoped lang="scss">
.second-section-opened {
  width: 100vw;
  height: 100vh;
  position: absolute;
  background: linear-gradient(180deg, rgba(0, 51, 102, 0) 23.94%, #003366 100%);
  z-index: 1;
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

