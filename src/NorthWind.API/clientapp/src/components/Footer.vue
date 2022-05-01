<template>
  <div>
    <div class="footer-first-section">
      <div class="flex-container">
        <div class="about-company-column">
          <img alt="Не удалось загрузить изображение" src="../assets/small_logo.png"><span>Северный Ветер</span>
          <p class="position">295053, Республика Крым, г. Симферополь, ул. Буденного д.32, литера "Ф" </p>
          <p class="enity">ИНН: 9102241410 КПП: 910201001</p>
        </div>
        <div class="navigation">
          <h4>Навигация</h4>
          <ul>
            <li v-for="(item, index) in navigationItems"
                :key="index"
            >
              {{ item.title }}
            </li>
          </ul>
        </div>
        <div class="phone-numbers">
          <h4>Навигация</h4>
          <ul>
            <li>+7 (xxx) xxx-xx-xx</li>
            <li>+7 (xxx) xxx-xx-xx</li>
            <li>todotodo@bk.ru</li>
          </ul>
        </div>
      </div>
    </div>
    <div class="footer-second-section">
      <div class="dividing-line-container">
        <div class="dividing-line"/>
      </div>
      <div class="flex-container">

      </div>
    </div>
  </div>
</template>

<script lang="ts">
import {Component, Vue} from "vue-property-decorator";

@Component
export default class FooterSection extends Vue {
  navigationItems: { title: string, to: string }[] = [
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
      title: 'Аккаунт',
      to: '/'
    },
  ]
}
</script>
<style lang="scss" scoped>
.footer-first-section {
  padding-top: 4em;
  padding-bottom: 4em;
  width: 100%;
  height: auto;
  background: #002C58;
  display: flex;
  align-items: center;

  .flex-container {
    display: flex;
    flex-wrap: wrap;
    justify-content: flex-start;

    padding-left: 10%;
    padding-right: 10%;

    .about-company-column {

      margin-right: 100px;


      .position {
        font-family: Roboto, sans-serif;
        font-style: normal;
        font-weight: normal;
        font-size: 1em;
        letter-spacing: 0.035em;

        padding-top: 1em;
        color: rgba(242, 246, 255, 0.75);
      }

      .enity {
        font-family: Roboto, sans-serif;
        font-style: normal;
        font-weight: normal;
        font-size: 1em;
        letter-spacing: 0.035em;

        padding-top: 1em;
        color: rgba(242, 246, 255, 0.75);
      }

      img {
        display: inline;
      }

      span {
        font-family: Bona Nova, sans-serif;
        font-style: normal;
        font-weight: bold;
        font-size: 1em;
        color: #FFFFFF;
      }

    }

    .navigation {

      margin-right: 60px;

      ul {
        padding: 0;

        li {
          font-family: Montserrat, sans-serif;
          font-style: normal;
          font-weight: normal;
          letter-spacing: 0.035em;

          color: rgba(242, 246, 255, 0.75);
          cursor: pointer;
        }
      }

      h4 {
        font-family: Raleway, sans-serif;
        font-style: normal;
        font-weight: bold;
        font-size: 1em;
        letter-spacing: 0.1em;
        color: #FFFFFF;
      }
    }

    .phone-numbers {
      ul {
        padding: 0;

        li {
          font-family: Montserrat, sans-serif;
          font-style: normal;
          font-weight: normal;
          letter-spacing: 0.035em;

          color: rgba(242, 246, 255, 0.75);
        }
      }

      h4 {
        font-family: Raleway, sans-serif;
        font-style: normal;
        font-weight: bold;
        font-size: 1em;
        letter-spacing: 0.1em;
        color: #FFFFFF;
      }
    }
  }
}

.footer-second-section {
  width: 100%;
  height: 60px;
  background: #002347;

  .dividing-line-container {
    padding-left: 10%;
    padding-right: 10%;

    .dividing-line {
      width: 100%;
      height: 0;
      border: 2px solid rgba(242, 246, 255, 0.2);
    }
  }
}
</style>
