﻿<template>
  <v-app-bar
      class="navbar"
      color="#6A76AB"
      dark
      fade-img-on-scroll
      prominent
      scroll-target="#scrolling-techniques-3"
      shrink-on-scroll
      src="https://picsum.photos/1920/1080?random"
  >
    <template v-slot:img="{ props }">
      <v-img
          gradient="to top right, rgba(100,115,201,.7), rgba(25,32,72,.7)"
          v-bind="props"
      ></v-img>
    </template>

    <v-app-bar-nav-icon></v-app-bar-nav-icon>
    <v-app-bar-title class="title">{{ fullName }}</v-app-bar-title>
    <v-spacer></v-spacer>
    <v-btn icon>
      <v-icon>mdi-magnify</v-icon>
    </v-btn>
    <v-btn icon>
      <v-icon>mdi-heart</v-icon>
    </v-btn>
    <v-btn icon>
      <v-icon>mdi-dots-vertical</v-icon>
    </v-btn>
  </v-app-bar>
</template>

<script lang="ts">
import {Component, Vue} from "vue-property-decorator";
import {namespace} from "vuex-class";

const User = namespace('CurrentUserStore')

@Component
export default class NavbarUser extends Vue {
  @User.State('fullName') fullName!: string;
}
</script>
<style lang="scss" scoped>

</style>
