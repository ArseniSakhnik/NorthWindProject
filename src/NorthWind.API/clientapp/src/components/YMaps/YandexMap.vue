<template>
  <div
      id="map"
      ref="map"
      class="ymap"
  />
</template>

<script lang="ts">
import {Component, Prop, PropSync, Ref, Vue} from 'vue-property-decorator'
//@ts-ignore
import {loadYmap, yandexMap, ymapMarker} from 'vue-yandex-maps'
import {getCoordinates} from '../../data/CityCoordinates';


@Component({components: {yandexMap, ymapMarker}})
export default class YandexMap extends Vue {
  @Ref('map')
  map!: any

  @PropSync('territoryAddress')
  territoryAddressSynced!: string;

  @PropSync('cityDistance', {required: false}) cityDistanceSynced!: number;
  @PropSync('boundDistance', {required: false}) boundDistanceSynced!: number;

  isMapLoaded: boolean = false

  settings = {
    apiKey: '04ec0a7a-4280-4526-a85b-d7b5c299bae5',
    lang: 'ru_RU',
    coordorder: 'latlong',
    enterprise: false,
    version: '2.1'
  }

  getCityPolygon() {
    const cityCoordinates = getCoordinates();
    //@ts-ignore()
    const coordinatesMap = cityCoordinates.geometries[0].coordinates[0].map(item => item.reverse());

    const cityAreaStyle = {
      // Описываем опции геообъекта.
      // Цвет заливки.
      fillColor: '#00FF00',
      // Цвет обводки.
      strokeColor: '#0000FF',
      // Общая прозрачность (как для заливки, так и для обводки).
      opacity: 0.5,
      // Ширина обводки.
      strokeWidth: 2,
      // Стиль обводки.
      strokeStyle: 'shortdash'
    }

    const cityAreaObject = {
      // Описываем геометрию геообъекта.
      geometry: {
        // Тип геометрии - "Многоугольник".
        type: "Polygon",
        // Указываем координаты вершин многоугольника.
        coordinates: [coordinatesMap],
        // Задаем правило заливки внутренних контуров по алгоритму "nonZero".
        fillRule: "nonZero"
      }
    }

    //@ts-ignore
    const myGeoObject = new ymaps.GeoObject(cityAreaObject, cityAreaStyle);

    return myGeoObject;
  }

  getGeneratedMap() {
    //@ts-ignore
    return new ymaps.Map('map', {
      center: [44.959240, 34.131166],
      zoom: 12,
      controls: []
    })
  }

  getRouteAbdZoomMap() {
    //@ts-ignore
    const routePanelControl = new ymaps.control.RoutePanel({
      options: {
        showHeader: true,
        title: 'Расчет перевозки'
      }
    })

    //@ts-ignore
    const zoomControl = new ymaps.control.ZoomControl({
      options: {
        size: 'small',
        float: 'none',
        position: {
          bottom: 145,
          right: 10
        }
      }
    })

    // Если вы хотите задать неизменяемую точку "откуда", раскомментируйте код ниже.
    routePanelControl.routePanel.state.set({
      fromEnabled: false,
      from: 'Республика Крым, г. Симферополь, ул. Буденного д.32, литера "Ф"',
    });

    routePanelControl.routePanel.options.set({
      types: {auto: true}
    });

    return {routePanelControl, zoomControl};
  }

  setRouteSettings(myMap: any, routePanelControl: any, polygon: any) {
    routePanelControl.routePanel.getRouteAsync()
        .then((route: any) => {
          route.model.setParams({results: 1}, true);

          route.model.events.add('requestsuccess', () => {

            const activeRoute = route.getActiveRoute();

            if (activeRoute) {
              const length = route.getActiveRoute().properties.get('distance');
              const geoInfo = route.getActiveRoute().properties.getAll();
              const coords = geoInfo.rawProperties.boundedBy[1];

              const edgeAndSegments = [];

              for (let i = 0; i < activeRoute.getPaths().getLength(); i++) {
                const way = activeRoute.getPaths().get(i);
                const segments = way.getSegments();
                edgeAndSegments.push(segments)
              }

              //@ts-ignore
              const routeSegments = ymaps.geoQuery(edgeAndSegments)
                  .addToMap(myMap);

              const citySegments = routeSegments.searchInside(polygon);
              const boundSegments = routeSegments.remove(citySegments);

              this.cityDistanceSynced = this.getSegmentDuration(citySegments._objects)
              this.boundDistanceSynced = this.getSegmentDuration(boundSegments._objects);


              const placeInput = this.map.querySelector('*[placeholder="Куда"]');

              this.territoryAddressSynced = `Республика Крым, Россия, Симферополь, ${placeInput.value}`;
            }
          })
        })
  }

  async mounted() {
    await loadYmap({...this.settings, debug: true})
    //@ts-ignore
    ymaps.ready(this.init)
  }

  private init() {
    const cityArea = this.getCityPolygon();
    this.isMapLoaded = true;
    const myMap = this.getGeneratedMap();
    myMap.geoObjects.add(cityArea);
    const {routePanelControl, zoomControl} = this.getRouteAbdZoomMap();
    myMap.controls.add(routePanelControl).add(zoomControl)
    this.setRouteSettings(myMap, routePanelControl, cityArea);
  }

  private getSegmentDuration(segments: any[]): number {
    let duration = 0;

    for (let i = 0; i < segments.length; i++) {
      const segmentInfo = segments[i].properties.get('distance')
      duration += segmentInfo.value;
    }

    return duration;
  }
}
</script>
<style scoped>
.ymap {
  width: 100%;
  height: 100%;
}
</style>
