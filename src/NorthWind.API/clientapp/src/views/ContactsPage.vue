<template>
  <div>
    <div class="background-image">
      <h2> Документы </h2>
    </div>
    <v-container>
      <v-list>
        <v-list-item v-for="(item, index) in contacts">
          <v-list-item-icon>
            <v-icon>{{ item.icon }}</v-icon>
          </v-list-item-icon>
          <v-list-item-content>
            <v-list-item-title>{{ item.title }}</v-list-item-title>
            <div>{{ item.description }}</div>
          </v-list-item-content>
        </v-list-item>
      </v-list>
    </v-container>
  </div>
</template>

<script lang="ts">
import {Component, Vue} from "vue-property-decorator";

@Component
export default class ContactsPage extends Vue {
  contacts = [
    {
      title: 'Адрес',
      icon: 'mdi-map-marker',
      description: '295053, Россия, Республика Крым, г. Симферополь, ул. Буденного д.32, помещение 1, литера "Ф"'
    },
    {
      title: 'Номера телефонов',
      icon: 'mdi-phone',
      description: '+7 (978) 024-30-05 ; +7 (978) 024-30-06'
    },
    {
      title: 'Почта',
      icon: 'mdi-email',
      description: 'northwind82@bk.ru'
    }
  ]
}
</script>
<style lang="scss" scoped>
.background-image {
  background-image: url('../assets/backgrounds/phons.png');
}


</style>
