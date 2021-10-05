<template>
  <header>
    <nav class="nav-bar">
      <ul class="user-menu">
        <li class="user-menu-item">
          <a class="user-menu-link" href="#">Тут будет лого</a>
        </li>
      </ul>
      <ul class="main-nav">
        <li class="main-nav-item">
          <router-link class="nav-item-link" to="/">Услуги</router-link>
        </li>
        <li class="main-nav-item">
          <router-link class="nav-item-link" to="#">Документы</router-link>
        </li>
        <li class="main-nav-item">
          <router-link class="nav-item-link" to="#">Вакансии</router-link>
        </li>
        <li class="main-nav-item">
          <router-link class="nav-item-link" to="#">Контакты</router-link>
        </li>
        <li class="main-nav-item">
          <router-link class="nav-item-link" to="#">Выход</router-link>
        </li>
      </ul>
    </nav>
  </header>
</template>
<script lang="ts">
import {defineComponent} from 'vue'

export default defineComponent({
  name: 'Navbar',
})
</script>
<style scoped>
</style>