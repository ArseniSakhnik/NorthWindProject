<template>
  <div class="second-section">
    <about-service/>
  </div>
</template>

<script lang="ts">
import {Vue, Component} from 'vue-property-decorator'
import AboutService from "@/components/HomePage/secondSection/AboutService.vue";
@Component({
  components: {AboutService}
})
export default class SecondSection extends Vue {
}
</script>

<style scoped>
.second-section{
  height: 120vh;
  background: linear-gradient(180deg, #003366 0%, #002347 100%),
  radial-gradient(21.56% 41.41% at 17.53% 51.62%, #003F7D 0%, rgba(0, 63, 125, 0) 100%);
}
</style>
