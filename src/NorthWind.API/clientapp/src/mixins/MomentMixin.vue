<script lang="ts">
import {Vue, Component} from 'vue-property-decorator'
import AccountService from "@/services/AccountService/AccountService"
import ServiceViewService from "@/services/ServiceViewService/ServiceViewService";

@Component
export default class MomentMixin extends Vue {
  getDateForCalendar(value: string): string {
    let date;
    if (!value.length) {
      date = this.$moment(new Date);
    } else {
      date = this.$moment(value);
    }
    return date.format('YYYY-MM-DD');
  }
}
</script>
<style scoped>

</style>
