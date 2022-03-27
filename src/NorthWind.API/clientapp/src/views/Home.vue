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
</style>

