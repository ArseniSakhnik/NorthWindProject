<script lang="ts">
import {Vue, Component} from "vue-property-decorator";

@Component
export default class KillReactivityMixin extends Vue {
  killReactivity<T>(value: T) : T {
    return JSON.parse(JSON.stringify(value));
  }
}
</script>
<style scoped lang="scss">

</style>
