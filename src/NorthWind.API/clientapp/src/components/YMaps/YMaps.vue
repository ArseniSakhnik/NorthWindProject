<template>
  <div id="map">
    <yandex-map
        ref="map"
        :settings="settings"
        class="ymap"
        :coords="[64.563385, 39.823782]"
        v-if="isMapLoaded"
    >
    </yandex-map>
  </div>
</template>

<script lang="ts">
import {Vue, Component, Ref} from 'vue-property-decorator'
//@ts-ignore
import {yandexMap, ymapMarker, loadYmap} from 'vue-yandex-maps'


@Component({components: {yandexMap, ymapMarker}})
export default class YandexMap extends Vue {
  @Ref('map') private map!: any

  private isMapLoaded: boolean = false;
  
  //в рефы
  private DELIVERY_TARIFF: number = 20;
  private MINIMUM_COST: number = 500;
  
  
  settings = {
    apiKey: '04ec0a7a-4280-4526-a85b-d7b5c299bae5',
    lang: 'ru_RU',
    coordorder: 'latlong',
    enterprise: false,
    version: '2.1'
  }


  private init() {
    
    this.isMapLoaded = true;
    //@ts-ignore
    const myMap = new ymaps.Map('map', {
      center: [60.906882, 30.067233],
      zoom: 9,
      controls: []
    })
  }

  async mounted() {
    await loadYmap({...this.settings, debug: true})
    //@ts-ignore
    ymaps.ready(this.init)

  }
}
</script>
<style scoped>
.ymap {
  width: 1000px;
  height: 1000px;
}
</style>
