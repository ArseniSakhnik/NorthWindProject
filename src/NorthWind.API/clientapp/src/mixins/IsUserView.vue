<script lang="ts">
import {Vue, Component} from "vue-property-decorator";

@Component
export default class IsUserView extends Vue {
  get isUserView() {
    //@ts-ignore
    return this.$route.meta.layout === 'User'
  }
  
  get isAdminView() {
    //@ts-ignore
    return this.$route.meta.layout === 'Admin'
  }
}
</script>
<style scoped lang="scss">

</style>
