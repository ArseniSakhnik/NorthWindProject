<template>
  <v-card>
    <v-card-actions>
      <v-spacer></v-spacer>
      <v-btn @click="cancel">Отмена</v-btn>
      <v-btn
          class="orange darken-4"
          style="color: white"
          @click="send"
      >
        Отправить
      </v-btn>
    </v-card-actions>
  </v-card>
</template>

<script lang="ts">
import {Vue, Component, Emit} from "vue-property-decorator";

@Component
export default class ActionCardBar extends Vue {

  @Emit()
  send(e: any) {
    return e;
  }

  @Emit()
  cancel(e: any) {
    return e;
  }

}
</script>
<style scoped lang="scss">

</style>
