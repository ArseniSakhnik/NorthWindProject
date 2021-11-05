<template>
  <v-app>
    <v-container>
      <v-navigation-drawer permanent class="sidebar">
        <v-list-item>
          <v-list-item-content>
            <v-list-item-title class="text-h6">
              Application
            </v-list-item-title>
            <v-list-item-subtitle>
              subtext
            </v-list-item-subtitle>
          </v-list-item-content>
        </v-list-item>

        <v-divider></v-divider>

        <v-list
          dense
          nav
        >
          <v-list-item
            v-for="item in managementLinks"
            :key="item.title"
            link
          >
            <v-list-item-icon>
              <v-icon> icon</v-icon>
            </v-list-item-icon>

            <v-list-item-content>
              <v-list-item-title>{{ item.name }}</v-list-item-title>
            </v-list-item-content>


          </v-list-item>
        </v-list>
      </v-navigation-drawer>
    </v-container>
  </v-app>
</template>

<script lang="ts">
import {Vue, Component, Prop} from 'vue-property-decorator'

@Component
export default class AdminPanel extends Vue {
  private get managementLinks() {
    return [
      {
        name: 'Управление услугами',
        link: '',
      },
      {
        name: 'Управление документами',
        link: '',
      },
      {
        name: 'Управление вакансиями',
        link: '',
      },
      {
        name: 'Управление контактами',
        link: '',
      },
    ]
  }
}
</script>
<style lang="scss">
.sidebar {
  width: 100%
}
</style>
