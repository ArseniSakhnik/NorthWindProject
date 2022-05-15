<template>
  <div style="background-color: #f2f6ff">
    <v-container style="margin-top: 250px; margin-bottom: 170px">
      <v-row>
        <v-col
            cols="12"
            lg="5"
        >
          <div class="text-block">
            <h2 class="second-section-font">УТИЛИЗАЦИЯ</h2>
            <p>Мусор утилизируется строго в предназначенных для этого местах: крупногабаритные отходы - в Тургеневском
              карьере, жидкие отходы - в Водоканале.</p>
            <p>К строительному мусору относятся бой кирпича, старые обои, обломки фундамента и стеновых перегородок,
              плиты
              перекрытий, железобетонные конструкции. </p>
          </div>
        </v-col>
        <v-col
            class="svg-container"
            cols="12"
            lg="7"
        >
          <map-svg/>
        </v-col>
      </v-row>
      <v-row class="padding">
        <v-col>
          <h2 class="second-section-font">СВЯЗАТЬСЯ С НАМИ</h2>
        </v-col>
        <v-col v-if="isComputer"/>
      </v-row>
    </v-container>
    <div
        :style="`background-image: url(${getImage()})`"
        class="background-img"
    >
      <v-container class="contact-us-section-container">
        <contact-us-section class="contact-us-section"/>
      </v-container>
    </div>
  </div>
</template>

<script lang="ts">
import {Component, Mixins} from "vue-property-decorator";
import MapSvg from "@/icons/Map.vue";
import BreakPointsMixin from "@/mixins/BreakPointsMixin.vue";
import ContactUsSection from "@/components/HomePage/ContactUsSection/ContactUsSection.vue";

@Component({
  components: {MapSvg, ContactUsSection}
})
export default class ThirdSection extends Mixins(BreakPointsMixin) {
  getImage() {
    return require(`/src/assets/Frame30.png`)
  }
}
</script>
<style lang="scss" scoped>
.background-img {
  height: 564px;
  width: 100%;
  background-color: black;

  background-blend-mode: multiply;
  background-position: center bottom;
  background-color: rgba(#1b3648, 0.35);
  background-size: cover;
  background-repeat: no-repeat;
  background-image: url('/../src/assets/Frame30.png');

  position: relative;

  .contact-us-section {
    position: absolute;
    top: -170px;
    left: 20%;
    right: 20%;
    margin-left: auto;
    margin-right: auto;
  }

  @media screen and (max-width: 1264px) {
    .contact-us-section {
      left: 1em;
      right: 1em;
    }
  }
}

.third-section {
  height: 120vh;
  background-color: #e1e9f9;
}

.second-section-font {
  font-family: Raleway, sans-serif;
  font-style: normal;
  font-weight: 800;
  font-size: 1em;

  letter-spacing: 0.015em;
  text-transform: uppercase;
}

.text-block {
  p {
    font-family: Montserrat, sans-serif;
    font-style: normal;
    font-weight: 600;
    font-size: 0.5em;

    text-align: justify;
    letter-spacing: 0.035em;
  }
}

.svg-container {
  display: flex;
  align-content: center;
  align-items: center;
}
</style>
