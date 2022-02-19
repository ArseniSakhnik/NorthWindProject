<template>
  <v-container>
    <v-row>
      <v-col
          cols="12"
          lg="5"
      >
        <div class="text-block">
          <h2 class="second-section-font">УТИЛИЗАЦИЯ</h2>
          <p>Мусор утилизируется строго в предназначенных для этого местах: крупногабаритные отходы - в Тургеневском
            карьере, жидкие отходы - в Водоканале.</p>
          <p>К строительному мусору относятся бой кирпича, старые обои, обломки фундамента и стеновых перегородок, плиты
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
  </v-container>
</template>

<script lang="ts">
import {Vue, Component} from "vue-property-decorator";
import MapSvg from "@/icons/Map.vue";

@Component({
  components: {MapSvg}
})
export default class ThirdSection extends Vue {

}
</script>
<style scoped lang="scss">
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
