<template>
  <div v-if="isDataLoaded" class="about-car">
    <div class="background-image">
      <h2>{{ cars[currentCarIndex].title }}</h2>
    </div>
    <v-container>
      <v-row>
        <v-col
            cols="12"
            md="3"
        >
          <v-card>
            <v-list dense>
              <v-list-item-group
                  v-model="currentCarIndex"
                  color="primary"
              >
                <v-list-item v-for="(_, index) in cars">
                  <v-list-item-content>
                    <v-list-item-title v-text="cars[index].title"/>
                  </v-list-item-content>
                </v-list-item>
              </v-list-item-group>
            </v-list>
          </v-card>
        </v-col>
        <v-col class="text-info" cols="12" md="4">
          <p>{{ cars[currentCarIndex].about }}</p>
          <p>{{ cars[currentCarIndex].description }}</p>
        </v-col>
        <v-col cols="12" md="5">
          <img :src="imageLink" alt="не удалось загрузить изображение" class="car-img">
          <car-table
              :cars-info-modes="cars[currentCarIndex].carModels"
          />
        </v-col>
      </v-row>
    </v-container>
  </div>
</template>

<script lang="ts">
import {Component, Mixins, Ref} from "vue-property-decorator";
import CarTable from "@/components/CarTable.vue";
import HttpServiceMixin from "@/mixins/HttpServiceMixin.vue";
import {Car} from "@/services/CarsService/Responses";

@Component({components: {CarTable}})
export default class AboutCar extends Mixins(HttpServiceMixin) {
  @Ref('hooper') hooperRef!: any;

  cars: Car[] = [];
  
  mounted() {
    this.currentCarIndex = Number(this.$route.params.id);
  }

  currentCarIndex: number = 0;
  isDataLoaded: boolean = false;

  get imageLink() {
    return `ServiceImage/Cars/${this.cars[this.currentCarIndex].path}`
  }

  async created() {
    const {data} = await this.carsService.getCars();
    this.cars = data
    console.log(this.cars);
    this.isDataLoaded = true;
  }

}
</script>
<style lang="scss" scoped>
.about-car {
  height: auto;

  .v-cnt {
    display: flex;
    align-items: center;
    justify-content: center;
    flex-direction: column;

  }
}

.car-img {
  min-height: 50vh;
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

.text-info {
  p {
    font-family: Montserrat, sans-serif;
    font-style: normal;
    font-weight: normal;
    /* or 27px */

    letter-spacing: 0.1em;
    color: black;
  }
}
</style>
