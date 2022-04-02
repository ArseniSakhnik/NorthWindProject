<template>
  <v-container class="flex-container">
    <v-btn>Назад</v-btn>
    <v-btn
        x-large
        color="warning"
        dark
        :disabled="isDisabled"
        @click="send"
    >
      Отправить
    </v-btn>
  </v-container>
</template>

<script lang="ts">
import {Vue, Component, Emit, Prop} from "vue-property-decorator";

@Component
export default class ActionBar extends Vue {
  @Prop()
  isDisabled!: boolean;

  @Emit()
  send(e: any) {
    return e;
  }
}
</script>
<style scoped lang="scss">
.flex-container {
  display: flex;
  align-items: center;
  justify-content: space-between;
}
</style>
