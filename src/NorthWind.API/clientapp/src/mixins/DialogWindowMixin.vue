<script lang="ts">
import {Component, PropSync, Ref, Vue, Watch} from 'vue-property-decorator'

@Component
export default class DialogWindowMixin extends Vue {
  @PropSync('isActive') isConfirmActive!: boolean;
  @Ref('dialogRef') dialogRef!: any;

  errorMsg: string = '';

  toggleRegisterWindow(isOpen: boolean) {
    this.isConfirmActive = isOpen;
  }

  public close(): void {
    this.isConfirmActive = false
  }

  @Watch('isConfirmActive')
  isConfirmActiveChangeHandler(value: boolean) {
    this.dialogRef.isActive = value;
  }
}
</script>
<style scoped>
.error-message {
  color: red;
}
</style>