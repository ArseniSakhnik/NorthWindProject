<template>
  <div>
    <v-container style="margin-top: 250px;">
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
            cols="12"
            lg="7"
            class="svg-container"
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
    <div class="relative-container">
      <div class="margin-section"/>
      <v-container class="relative-container">
        <contact-us-section class="contact-us-section"/>
      </v-container>
      <div class="background-img"/>
    </div>
  </div>
</template>

<script lang="ts">
import {Vue, Component, Mixins} from "vue-property-decorator";
import MapSvg from "@/icons/Map.vue";
import BreakPointsMixin from "@/mixins/BreakPointsMixin.vue";
import ContactUsSection from "@/components/HomePage/ContactUsSection/ContactUsSection.vue";

@Component({
  components: {MapSvg, ContactUsSection}
})
export default class ThirdSection extends Mixins(BreakPointsMixin) {

}
</script>
<style scoped lang="scss">
.relative-container {
  position: relative;

  .background-img {
    position: absolute;
    width: 100%;
    height: 900px;
    background-color: black;
    z-index: -1;
  }
}

.contact-us-section {
  position: absolute;
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

.contact-us-section {
  position: absolute;
  width: 100%;
  height: 501px;
}
</style>
