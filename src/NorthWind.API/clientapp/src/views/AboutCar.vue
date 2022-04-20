<template>
  <div class="about-car">
    <div class="background-image">
      <h2>ОТКАЧКА ЖИДКИХ ОТХОДОВ</h2>
    </div>
    <v-row>
      <v-col
          cols="12"
          md="6"
      >
        <div>
          Lorem ipsum dolor sit amet, consectetur adipisicing elit. Assumenda autem dignissimos dolor eius enim porro
          saepe similique voluptatem voluptates! Ab commodi eveniet id perspiciatis rerum velit! Aut error illum iure
          molestiae nobis rerum sit soluta. Adipisci consequatur dolor dolores expedita fugit illo, in, itaque iure,
          labore laborum nam nisi non porro quaerat qui quibusdam ratione sapiente sit soluta voluptatem. Amet commodi
          et labore maxime temporibus. Adipisci cum cumque cupiditate dignissimos fuga iusto minus molestias vel?
          Distinctio itaque rerum veniam. Ad consectetur distinctio ea eveniet ipsa qui similique. Adipisci assumenda
          commodi dicta, expedita inventore libero magnam, minus mollitia nostrum quam qui sapiente similique sint vero
          voluptate! Cupiditate dolore ea error exercitationem ipsam minus nam neque, odit officiis omnis quasi
          temporibus, voluptatum.
        </div>
      </v-col>
      <v-col
          cols="12"
          md="6"
      >
        <v-container class="v-cnt">
          <hooper style="height: 100%" :itemsToShow="1" ref="hooper" @afterSlide="afterSlideEvent">
            <slide>
              <img src="ServiceImage/Cars/pumpingOutSepticTanks.jpg" alt="Изображение не загружено"/>
              <car-table/>
            </slide>
            <slide>
              <img src="ServiceImage/Cars/pumpingOutSepticTanks.jpg" alt="Изображение не загружено"/>
              <car-table/>
            </slide>
          </hooper>
        </v-container>
      </v-col>
    </v-row>
  </div>
</template>

<script lang="ts">
import {Vue, Component, Ref, Watch} from "vue-property-decorator";
import CarTable from "@/components/CarTable.vue";
//@ts-ignore
import {Hooper, Slide} from 'hooper/dist/hooper.js'

@Component({components: {CarTable, Hooper, Slide}})
export default class AboutCar extends Vue {
  @Ref('hooper') hooperRef!: any;

  afterSlideEvent() {
    console.log(this.hooperRef)
  }

}
</script>
<style scoped lang="scss">
.about-car {
  height: auto;

  .v-cnt {
    display: flex;
    align-items: center;
    justify-content: center;
    flex-direction: column;


    img {
      max-width: 50vw;
      max-height: 50vh;
      margin-bottom: 10vh;
    }

  }
}

.background-image {
  background-image: url('../assets/backgrounds/qweqwe 2.png');
  position: relative;
  background-blend-mode: multiply;
  background-position: center bottom;
  background-color: rgba(#1b3648, 0.35);
  background-size: cover;
  background-repeat: no-repeat;
  width: 100%;
  height: 40vh;

  h2 {
    position: absolute;
    bottom: 50%;
    margin-left: 10vw;
    color: #FFFFFF;

    font-size: 2em;
    font-family: Raleway, sans-serif;
    font-weight: bold;
  }
}


.v-cnt {

}
</style>
