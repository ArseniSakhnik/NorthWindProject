<template>
  <v-container class="flex-container">
    <v-btn>Назад</v-btn>
    <v-btn
        :disabled="isDisabled"
        color="warning"
        dark
        x-large
        @click="send"
    >
      Отправить
    </v-btn>
  </v-container>
</template>

<script lang="ts">
import {Component, Emit, Prop, Vue} from "vue-property-decorator";

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
<style lang="scss" scoped>
.flex-container {
  display: flex;
  align-items: center;
  justify-content: space-between;
}
</style>
