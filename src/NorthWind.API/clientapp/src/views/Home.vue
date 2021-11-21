<template>
  <div class="home-page">
    <first-section/>
    <section class="service-list">

    </section>
    <section style="height: 1000px">
      хуй
    </section>
  </div>
</template>

<script lang="ts">
import {Vue, Component} from 'vue-property-decorator'
import FirstSection from "@/components/HomePage/FirstSection.vue";
@Component({
  components: {FirstSection}
})
export default class Home extends Vue {

}
</script>
<style scoped lang="scss">

</style>

