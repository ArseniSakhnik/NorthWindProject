<template>
  <div class="home-page">
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

</style>

