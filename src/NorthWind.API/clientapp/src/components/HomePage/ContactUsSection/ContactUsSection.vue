<template>
  <v-row class="questionnaire">
    <v-col
        cols="12"
        md="5"
        class="contact-section"
    >
      <h5 class="text-white">Контакты</h5>
      <ul>
        <li>ул. Буденного д.32, литера "Ф",
          г. Симферополь
        </li>
        <li>+7 (978) 024-30-06
          +7 (978) 024-30-07
        </li>
        <li>northwind82@bk.ru</li>
      </ul>
    </v-col>
    <v-col
        cols="12"
        md="7"
        class="call-request"
    >
      <h5>ЗАКАЗАТЬ ЗВОНОК</h5>
      <v-text-field
          label="Ваше имя"
          outlined
          dense
      />
      <v-text-field
          v-mask="'(###) ###-##-##'"
          v-model="phoneNumber"
          label="Номер телефона"
          outlined
          dense
          prefix="+7"
      />
      <v-text-field
          label="Сообщение или дополнительная информация"
          outlined
          dense
      />
    </v-col>
  </v-row>
</template>

<script lang="ts">
import {Vue, Component} from "vue-property-decorator";

@Component
export default class ContactUsSection extends Vue {
  private phoneNumber: string = '';
}
</script>
<style scoped lang="scss">
.questionnaire {
  background: linear-gradient(0deg, #002C58, #002C58);
  box-shadow: -12px 15px 79px rgba(57, 78, 112, 0.06);
  
  .contact-section {
    height: 100%;
    width: 100%;
    padding: 0.5em 1em 1em;

    h5 {
      font-family: Raleway, sans-serif;
      font-style: normal;
      font-weight: bold;
      font-size: 0.5em;
      letter-spacing: 0.1em;
      padding-bottom: 0.4em;
    }

    ul {
      li {
        font-family: Montserrat, sans-serif;
        font-style: normal;
        font-weight: normal;
        font-size: 0.3em;
        color: rgba(255, 255, 255, 0.76);
        letter-spacing: 0.035em;
      }
    }
  }

  .call-request {
    background: linear-gradient(0deg, #FFFFFF, #FFFFFF);
    height: 100%;
    width: 100%;
    padding: 0.5em 4em 1em 1em;

    h5 {
      font-family: Raleway, sans-serif;
      font-style: normal;
      font-weight: bold;
      font-size: 0.5em;
      letter-spacing: 0.1em;
      padding-bottom: 0.4em;

      color: #000000;
    }
  }
}



</style>
