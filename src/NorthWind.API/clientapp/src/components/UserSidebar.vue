<template>
  <v-navigation-drawer
      permanent
      expand-on-hover
      style="height: 100%"
  >
    <v-list
        nav
        dense
    >
      <v-list-item-group v-model="currentViewSynced">
        <v-list-item
            v-for="item in views"
            :key="item.viewId"
        >
          <v-list-item-icon>
            <v-icon>{{ item.icon }}</v-icon>
          </v-list-item-icon>
          <v-list-item-title>{{ item.name }}</v-list-item-title>
        </v-list-item>
      </v-list-item-group>
    </v-list>
  </v-navigation-drawer>
</template>

<script lang="ts">
import {Vue, Component, PropSync} from "vue-property-decorator";

@Component
export default class UserSidebar extends Vue {
  @PropSync('currentView') currentViewSynced!: number;
  
  views: { viewId: number, icon: string, name: string } [] = [
    {
      viewId: 0,
      icon: 'mdi-file-document-multiple-outline',
      name: 'Мои заявки'
    },
    {
      viewId: 1,
      icon: 'mdi-check-circle',
      name: 'Мои контракты'
    }
  ]
}
</script>
<style scoped lang="scss">
</style>
