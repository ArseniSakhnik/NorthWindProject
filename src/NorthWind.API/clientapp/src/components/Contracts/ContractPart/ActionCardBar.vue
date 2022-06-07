<template>
  <v-card>
    <v-card-actions>
      <v-spacer></v-spacer>
      <v-btn @click="cancel">{{ cancelTitle }}</v-btn>
      <v-btn
          v-if="isAdminView"
          class="orange darken-4"
          style="color: white"
          @click="exportContract"
      >
        Экспортировать
      </v-btn>
      <v-btn
          class="orange darken-4"
          style="color: white"
          @click="send"
      >
        {{ sendTitle }}
      </v-btn>
    </v-card-actions>
  </v-card>
</template>

<script lang="ts">
import {Vue, Component, Emit, Prop} from "vue-property-decorator";

@Component
export default class ActionCardBar extends Vue {
  @Prop({required: false, default: () => 'Отмена'})
  cancelTitle!: string;
  @Prop({required: false, default: () => 'Отправить'})
  sendTitle!: string;
  @Prop({required: false, default: () => false})
  isAdminView!: boolean;


  @Emit()
  send(e: any) {
    return e;
  }

  @Emit()
  cancel(e: any) {
    return e;
  }

  exportContract(e: any) {
    this.$emit('exportContract')
  }

}
</script>
<style scoped lang="scss">

</style>
