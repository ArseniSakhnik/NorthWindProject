<script lang="ts">
import {Component, Vue} from 'vue-property-decorator'

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
