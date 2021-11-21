<template>
  <v-app-bar
      app
      height="100"
      color="transparent"
      class="main-navbar sticky"
      flat
      ref="navbar">
    <a href="logo">
      Логотип
    </a>
    <div>
      <router-link
          v-for="({title, to},index) in menuItems"
          :key="index"
          :to="to">
        <span>
          {{title}}
        </span>
      </router-link>
    </div>

  </v-app-bar>
</template>

<script lang="ts">
import {Vue, Component} from 'vue-property-decorator'

@Component
export default class Navbar extends Vue {
  private menuItems: [] = [
    {
      title: 'Услуги',
      to: '/'
    },
    {
      title: 'Документы',
      to: '/'
    },
    {
      title: 'Вакансии',
      to: '/'
    },
    {
      title: 'Контакты',
      to: '/'
    },
    {
      title: 'Вход',
      to: '/'
    },
  ];

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

</style>
