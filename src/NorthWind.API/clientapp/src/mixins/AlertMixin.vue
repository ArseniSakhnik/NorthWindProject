<script lang="ts">
import {Vue, Component} from "vue-property-decorator";
import {namespace} from "vuex-class";

const Alert = namespace('AlertStore')

@Component
export default class AlertMixin extends Vue {
  @Alert.Action('CALL_ALERT') callAlert!: (data: { message: string, delay: number, isError: boolean | undefined }) => void;

}
</script>
<style scoped lang="scss">

</style>
