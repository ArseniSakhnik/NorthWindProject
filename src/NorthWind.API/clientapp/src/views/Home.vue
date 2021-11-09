<template>
  <div class="home-page">
    <nav class="main-navbar sticky" ref="navbar">
      <a href="logo">
        Логотип
      </a>
      <ul>
        <li>
          <router-link to="" class="navbar-link">Услуги</router-link>
        </li>
        <li>
          <router-link to="" class="navbar-link active">Документы</router-link>
        </li>
        <li>
          <router-link to="" class="navbar-link">Вакансии</router-link>
        </li>
        <li>
          <router-link to="" class="navbar-link">Контакты</router-link>
        </li>
        <li>
          <router-link to="" class="navbar-link">Вход</router-link>
        </li>
      </ul>
    </nav>
    <section class="service-list">
      
    </section>
    <section style="height: 1000px">
      хуй
    </section>
  </div>
</template>

<script lang="ts">
import {Vue, Component} from 'vue-property-decorator'

@Component
export default class Home extends Vue {
  mounted() {
    window.addEventListener('scroll', () => {
      //@ts-ignore
      this.$refs.navbar.classList.toggle('sticky', window.scrollY > 0)
    })

  }
}
</script>
<style scoped lang="scss">
.main-navbar {
  width: 100%;
  position: fixed;
  display: flex;
  justify-content: space-between;
  padding: 0 1.92vw;
  height: 100px;
  align-items: center;
  transition: 0.6s;

  ul {
    display: flex;
    justify-content: center;

    li {
      list-style: none;
      padding-left: 0.96vw;

      .navbar-link {
        text-decoration: none;
        font-family: 'Raleway', sans-serif;
        font-size: 18px;
        font-weight: 400;
        color: rgba(242, 246, 255, .75);
      }

      .active {
        color: white;
      }
    }
  }
}

.sticky {
  background-color: rgba(255, 255, 255, .5);
  -webkit-backdrop-filter: blur(1x);
  backdrop-filter: blur(1x);
  transition: 0.6s;
}

.service-list {
  background-image: url(../assets/services1.jpg);
  background-position: center top;
  background-blend-mode: overlay;
  background-color: rgba(27, 54, 72, 0.5);
  background-size: cover;
  width: 100vw;
  height: 100vh;
}
</style>

