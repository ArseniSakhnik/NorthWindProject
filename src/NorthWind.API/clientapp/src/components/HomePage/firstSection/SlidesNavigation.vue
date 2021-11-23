<template>
  <div class="navigation">
    <v-item-group
        class="flex"
        :value="syncedCurrentItem">
      <v-item
          v-slot="{ active }"
          v-for="(item, index) in menuItems"
              :key="index">
        <v-card
            flat
            tile
            @click="setCurrentItem(index)"
            dark
            :color="active ? '#FF782E' : '#003366'">
          <v-icon>{{ item.icon }}</v-icon>
          <v-card-title>{{ item.title }}</v-card-title>
        </v-card>
      </v-item>

    </v-item-group>
  </div>
</template>

<script lang="ts">
import {Vue, Component, Prop, PropSync} from 'vue-property-decorator'

type MenuItem = { title: string; icon: string }

@Component
export default class SlidesNavigation extends Vue {
  @PropSync('currentItem',{type: Number, required: true}) syncedCurrentItem!: number;
  private menuItems: MenuItem[] = [
    {
      title: 'Вывоз строительного мусора',
      icon: '$recyclingCar'
    },
    {
      title: 'Откачка бытовых отходов',
      icon: '$recyclingCar'
    },
    {
      title: 'Полив и очистка территории',
      icon: '$recyclingCar'
    },
  ];
  setCurrentItem(index) {
    this.syncedCurrentItem = index
  }
}
</script>

<style scoped>
.navigation {
  position: absolute;
  bottom: 0;
}
</style>
