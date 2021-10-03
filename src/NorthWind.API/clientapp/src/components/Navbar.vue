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
          <a class="nav-item-link" href="#">Услуги</a>
        </li>
        <li class="main-nav-item">
          <a class="nav-item-link" href="#">Документы</a>
        </li>
        <li class="main-nav-item">
          <a class="nav-item-link" href="#">Вакансии</a>
        </li>
        <li class="main-nav-item">
          <a class="nav-item-link" href="#">Контакты</a>
        </li>
        <li class="main-nav-item">
          <a class="nav-item-link" href="#">Выход</a>
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