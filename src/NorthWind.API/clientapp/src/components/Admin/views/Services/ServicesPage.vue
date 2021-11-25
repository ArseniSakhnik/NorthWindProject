<template>
  <div>
    <create-service-page/>
  </div>
</template>

<script lang="ts">
import {Vue, Component} from 'vue-property-decorator'
import {namespace} from "vuex-class"
import CreateServicePage from "@/components/Admin/views/Services/CreateServicePage.vue"

const Services = namespace('Services');
@Component({
  components: {CreateServicePage}
})
export default class ServicesPage extends Vue {
  
}
</script>
<style scoped>

</style>
