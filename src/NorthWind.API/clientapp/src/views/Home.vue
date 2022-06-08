<template>
  <div class="home-page text-block-setting">
    <div v-if="isSecondSectionOpened" class="second-section-opened"/>
    <first-section
        @toSecondSection="toSecondSection"
    />
    <second-section
        ref="secondSection"
    />
    <third-section/>
  </div>
</template>

<script lang="ts">
import {Component, Ref, Vue} from 'vue-property-decorator'
import FirstSection from "@/components/HomePage/FirstSection.vue";
import SecondSection from "@/components/HomePage/SecondSection.vue";
import ThirdSection from "@/components/HomePage/thirdSection/ThirdSection.vue";

@Component({
  components: {ThirdSection, SecondSection, FirstSection}
})
export default class Home extends Vue {
  @Ref('secondSection') secondSection!: any;

  toSecondSection() {
    const el = this.secondSection.$el;

    if (el) {
      el.scrollIntoView({behavior: 'smooth'});
    }
  }


  private isSecondSectionOpened: boolean = false;
}
</script>

<style lang="scss" scoped>
.home-page {
  background-color: #f2f6ff;
}

.second-section-opened {
  width: 100vw;
  height: 100vh;
  position: absolute;
  background: linear-gradient(180deg, rgba(0, 51, 102, 0) 23.94%, #003366 100%);
  z-index: 1;
}
</style>

