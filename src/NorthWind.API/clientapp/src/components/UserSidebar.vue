﻿<template>
  <v-navigation-drawer
      permanent
      expand-on-hover
      style="background-color: #f2f6ff; max-height: 50vh;"
  >
    <v-list
        nav
        dense
    >
      <v-list-item-group v-model="currentViewSynced">
        <v-list-item
            v-for="item in views"
            :key="item.viewId"
            @click="item.action"
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
import {namespace} from "vuex-class";

const User = namespace('CurrentUserStore')

@Component
export default class UserSidebar extends Vue {
  @PropSync('currentView') currentViewSynced!: number;
  @User.Getter('IS_USER_ADMIN') isUserAdmin!: boolean;

  mounted() {
    if (this.$route.fullPath === 'user-contracts') {
      this.currentViewSynced = 1;
    } else if (this.$route.fullPath === 'user-purchases') {
      this.currentViewSynced = 0;
    }
  }

  views: { viewId: number, icon: string, name: string, action: () => void } [] = [
    {
      viewId: 0,
      icon: 'mdi-file-document-multiple-outline',
      name: 'Мои заявки',
      action: () => this.$router.push('/user-purchases')
    },
    {
      viewId: 1,
      icon: 'mdi-check-circle',
      name: 'Мои договоры',
      action: () => this.$router.push('/user-contracts')
    }
  ]
}
</script>
<style scoped lang="scss">
</style>
