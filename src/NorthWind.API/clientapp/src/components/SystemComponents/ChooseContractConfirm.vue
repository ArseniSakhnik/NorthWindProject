<template>
  <v-dialog
      ref="dialogRef"
      max-width="500px"
      @click:outside="toggleRegisterWindow(false)"
      scrollable
      persistent
  >
    <v-card>
      <v-card-title>Выберите услугу</v-card-title>
      <v-card-text>
        <v-list-item-group>
          <v-list-item
              v-for="(item, i) in services"
              :key="i"
              class="mt-2"
              @click="selectService(item.id)"
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
import {ServiceTypeEnum} from "@/enums/Enums";

@Component
export default class ChooseContractConfirm extends Mixins(DialogWindowMixin) {
  @PropSync('selectedService') selectedServiceSync!: ServiceTypeEnum | null;

  services: { title: string, id: ServiceTypeEnum }[] = [
    {
      id: ServiceTypeEnum.KGO,
      title: 'Вывоз строительного и крупногабаритного мусора',
    },
    {
      id: ServiceTypeEnum.Assenizator,
      title: 'Откачка жидких бытовых отходов',
    },
    // {
    //   id: ServiceTypeEnum.WaterCleaning,
    //   title: 'Полив и очистка территорий'
    // }
  ]

  selectService(id: ServiceTypeEnum) {
    this.selectedServiceSync = id;
  }
}
</script>
<style scoped lang="scss">
.standard-font {
  font-family: Montserrat, sans-serif;
  font-style: normal;
  font-weight: normal;
}
</style>
