<template>
  <div class="second-section">
    <v-container>
      <v-btn color="#FF9B52" text @click="toService">
        <v-icon left>
          mdi-arrow-up-left
        </v-icon>
        На главную
      </v-btn>
      <v-row>
        <v-col
            cols="12"
            lg="6"
        >
          <h2 class="text-white about-font">ВЫВОЗ СТРОИТЕЛЬНОГО И КРУПНОГАБАРИТНОГО МУСОРА</h2>
        </v-col>
        <v-col
            cols="12"
            lg="6"
        >
          <h3 class="about-company"><span class="company-font">ООО "Северный Ветер"</span> предоставляет услуги
            специализированной техники по
            вывозу отходов твердого и жидкого типа в Крыму. </h3>
        </v-col>
      </v-row>
      <v-row>
        <v-col
            cols="12"
            lg="4"
            style="width: 100%"
        >
          <div class="about-company-block">
            <Time class="about-company-icon"/>
            <h4>
              Удобное время
            </h4>
            <p>
              Учитывая сложность транспортной инфраструктуры,
              сотрудники нашей компании оказывают услуги в удобное для
              Заказчика время как в дневное, так и в ночное.
            </p>
          </div>
        </v-col>
        <v-col
            cols="12"
            lg="4"
        >
          <div class="about-company-block">
            <Reward class="about-company-icon"/>
            <h4>Качество исполнения</h4>
            <p>
              Основным принципом, которым руководствуется все,
              без исключения, сотрудники нашей компании, является
              качество исполнения поставленных задач.
            </p>
          </div>
        </v-col>
        <v-col
            cols="12"
            lg="4"
        >
          <div class="about-company-block">
            <Customer class="about-company-icon" style="margin-right: 0"/>
            <h4>
              Индивидуальный подход
            </h4>
            <p>
              При долгосрочном сотрудничестве,
              ООО «Северный Ветер», гарантирует индивидуальный подход к Заказчику.
            </p>
          </div>
        </v-col>
      </v-row>
      <v-row class="section-padding">
        <v-col
            cols="12"
            lg="6"
        >
          <h2 class="text-white about-font">ВЫВОЗ СТРОИТЕЛЬНОГО И КРУПНОГАБАРИТНОГО МУСОРА</h2>
        </v-col>
        <v-col
            cols="12"
            lg="6"
        >
          <h3 class="about-company">
            В автопарке предприятия имеются <span
              class="company-font">транспортные средства различного назначения:</span> комбинированные
            дорожно-уборочные машины с поливом, бункеровозы для вывоза крупногабаритных и строительных отходов,
            ассенизационная техника.
          </h3>
        </v-col>
      </v-row>
      <slider-auto/>
    </v-container>
  </div>
</template>

<script lang="ts">
import {Component, Vue} from 'vue-property-decorator'
import AboutService from "@/components/HomePage/secondSection/AboutService.vue";
import Customer from "@/icons/Customer.vue";
import Land from "@/icons/Land.vue";
import RecyclingCar from "@/icons/RecyclingCar.vue";
import Reward from "@/icons/Reward.vue";
import Time from "@/icons/Time.vue";
import RecyclingHome from "@/icons/RecyclingHome.vue";
import ArrowRight from "@/icons/ArrowRight.vue";
import SliderAuto from "@/components/SliderAuto.vue";

@Component({
  components: {SliderAuto, RecyclingHome, AboutService, Customer, Land, RecyclingCar, Reward, Time, ArrowRight}
})
export default class SecondSection extends Vue {
  toService() {
    scroll(0, 0)
  }
  
}
</script>

<style lang="scss" scoped>
.slider-auto-section {
  position: absolute;
  width: calc(100% - 30px);
  height: 501px;
}

.second-section {
  height: auto;
  background: linear-gradient(180deg, #003366 0%, #002347 100%),
  radial-gradient(21.56% 41.41% at 17.53% 51.62%, #003F7D 0%, rgba(0, 63, 125, 0) 100%);
}

.about-font {
  font-family: 'Raleway', 'serif';
  font-style: normal;
  font-weight: 800;
  font-size: 1em;
}

.about-company {
  font-family: 'Montserrat', 'serif';
  font-style: normal;
  font-weight: normal;
  font-size: 0.5em;
  /* or 27px */

  letter-spacing: 0.1em;
  color: #F2F6FF;
}

.company-font {
  color: #FF9B52;
}

.about-company-block {


  background: linear-gradient(179.94deg, rgba(93, 124, 204, 0.2) 3.9%, rgba(255, 255, 255, 0) 123.19%);
  filter: drop-shadow(-14px 14px 41px rgba(0, 17, 34, 0.5));
  border-radius: 7px;


  display: flex;
  flex-direction: column;
  justify-content: flex-start;
  align-items: center;
  align-content: center;


  padding: 0.5em;

  h4 {
    font-size: 0.8em;
    color: white;
    font-family: 'Raleway', 'serif';
    font-style: normal;
    font-weight: bold;
    text-align: center;
  }

  p {
    padding-top: 0.3em;
    font-size: 0.5em;
    font-family: 'Montserrat', 'serif';
    font-style: normal;
    font-weight: normal;
    text-align: center;
    color: #FFFFFF;
  }

  height: 100%;

}

.about-company-icon {
  height: 10vh;
}


</style>
