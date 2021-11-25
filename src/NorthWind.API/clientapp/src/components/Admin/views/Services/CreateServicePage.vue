<template>
  <div>
    <create-service-stepper
        v-model="step"
    />
  </div>
</template>

<script lang="ts">
import {Vue, Component} from 'vue-property-decorator'
import CreateServiceStepper from '@/components/Admin/views/Services/CreateServiceStepper.vue'

@Component({components: {CreateServiceStepper}})
export default class CreateServicePage extends Vue {
  private step: number = 1;
}
</script>
<style scoped>

</style>
