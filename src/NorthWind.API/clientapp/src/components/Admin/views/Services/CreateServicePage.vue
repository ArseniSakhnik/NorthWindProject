<template>
  <div>
    <create-service-stepper
        v-model="step"
    />
    <document-loader/>
  </div>
</template>

<script lang="ts">
import {Vue, Component} from 'vue-property-decorator'
import CreateServiceStepper from '@/components/Admin/views/Services/CreateServiceStepper.vue'
import DocumentLoader from '@/components/Admin/views/Services/DocumentLoader/DocumentLoader.vue'

@Component({components: {CreateServiceStepper, DocumentLoader}})
export default class CreateServicePage extends Vue {
  private step: number = 1;
  created() {
    console.log(1)
  }
}
</script>
<style scoped>

</style>
