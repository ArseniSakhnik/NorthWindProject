<script lang="ts">
import {Component, Vue} from 'vue-property-decorator'

@Component
export default class ValidationMixin extends Vue {

  isStringNotEmpty(value: string | null) {
    if (value === null) {
      return true;
    }

    const string = value.trim();
    return string.length !== 0 || 'Поле обязательно для заполнения'
  }

  validateComponent(): boolean {
    const refs: any = Object.values(this.$refs);

    //@ts-ignore
    refs.forEach(ref => {
      if (ref.validate) {
        ref.validate();
      }
    })

    //@ts-ignore
    return refs.some(ref => {
      if (!ref.validate) {
        return false;
      }
      return ref.validate();
    })
  }
}
</script>
<style scoped>

</style>
