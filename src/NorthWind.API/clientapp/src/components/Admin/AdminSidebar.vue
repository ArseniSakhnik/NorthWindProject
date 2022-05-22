<template>
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
            @click="goTo(item.route)"
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
export default class AdminSidebar extends Vue {
  @PropSync('currentView') currentViewSynced!: number;
  @User.Getter('IS_USER_ADMIN') isUserAdmin!: boolean;

  views: { viewId: number, icon: string, name: string, route: string } [] = [
    {
      viewId: 0,
      icon: 'mdi-file-document-multiple-outline',
      name: 'Заявки',
      route: '/admin-purchases'
    },
    {
      viewId: 1,
      icon: 'mdi-check-circle',
      name: 'Контракты',
      route: '/admin-contracts'
    },
    {
      viewId: 2,
      icon: 'mdi-human-edit',
      name: 'Пользователи',
      route: '/admin-users'
    }
  ]

  goTo(route: string) {
    this.$router.push(route);
  }
}
</script>
<style scoped lang="scss">

</style>
