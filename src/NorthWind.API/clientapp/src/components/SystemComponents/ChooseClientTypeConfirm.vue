<template>
  <v-dialog
      ref="dialogRef"
      max-width="500px"
      @click:outside="toggleRegisterWindow(false)"
      scrollable
      persistent
  >
    <v-card>
      <v-card-title>Выберите тип договора</v-card-title>
      <v-card-text>
        <v-list-item-group
            v-model="selectedClientSync"
        >
          <v-list-item
              v-for="(item, i) in clientTypes"
              :key="i"
              class="mt-2"
          >
            <v-list-item-content>
              <div style="font-size: 1.5em">{{ item.title }}</div>
            </v-list-item-content>
          </v-list-item>
        </v-list-item-group>
      </v-card-text>
    </v-card>
  </v-dialog>
</template>

<script lang="ts">
import {Component, Mixins, PropSync} from "vue-property-decorator";
import DialogWindowMixin from "@/mixins/DialogWindowMixin.vue";
import {ClientEnum} from "@/enums/Enums";

@Component
export default class ChooseClientTypeConfirm extends Mixins(DialogWindowMixin) {
  @PropSync('selectedClient') selectedClientSync!: ClientEnum;
  
  clientTypes: { id: ClientEnum, title: string }[] = [
    {
      id: ClientEnum.Yur,
      title: 'Юридическое лицо'
    },
    {
      id: ClientEnum.Fiz,
      title: 'Физическое лицо'
    }
  ]
}
</script>
<style scoped lang="scss">

</style>
