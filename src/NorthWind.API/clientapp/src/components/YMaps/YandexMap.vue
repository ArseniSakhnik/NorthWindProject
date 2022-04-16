<template>
  <div
      id="map"
      class="ymap"
      ref="map"
  />
</template>

<script lang="ts">
import {Vue, Component, Ref, Prop, PropSync} from 'vue-property-decorator'
//@ts-ignore
import {yandexMap, ymapMarker, loadYmap} from 'vue-yandex-maps'
import {getCoordinates} from '../../data/CityCoordinates';
import LoginWindow from "@/components/HomePage/loginWindow/LoginWindow.vue";


@Component({components: {yandexMap, ymapMarker}})
export default class YandexMap extends Vue {
  @Ref('map')
  map!: any

  @Prop({type: Function, required: true})
  calculateFunction!: (routeLength: number) => number;

  @PropSync('priceNumber')
  priceNumberSynced!: number;

  @PropSync('territoryAddress')
  territoryAddressSynced!: string;

  isMapLoaded: boolean = false

  settings = {
    apiKey: '04ec0a7a-4280-4526-a85b-d7b5c299bae5',
    lang: 'ru_RU',
    coordorder: 'latlong',
    enterprise: false,
    version: '2.1'
  }


  private init() {

    const coordinatesData = getCoordinates();

    //@ts-ignore
    const coordinatesMap = coordinatesData.geometries[0].coordinates[0].map(item => item.reverse());

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
    };

    const cityAreaObject = {
      // Описываем геометрию геообъекта.
      geometry: {
        // Тип геометрии - "Многоугольник".
        type: "Polygon",
        // Указываем координаты вершин многоугольника.
        coordinates: [coordinatesMap],
        // Задаем правило заливки внутренних контуров по алгоритму "nonZero".
        fillRule: "nonZero"
      },
      // Описываем свойства геообъекта.
      properties: {
        // Содержимое балуна.
        balloonContent: "Многоугольник"
      }
    }

    //@ts-ignore
    const myGeoObject = new ymaps.GeoObject(cityAreaObject, cityAreaStyle);

    // Добавляем многоугольник на карту.


    this.isMapLoaded = true
    //@ts-ignore
    const myMap = new ymaps.Map('map', {
      center: [44.959240, 34.131166],
      zoom: 12,
      controls: []
    })

    myMap.geoObjects.add(myGeoObject);
    
    
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
      from: 'Республика Крым, г. Симферополь, ул. Буденного д.32, литера "Ф"'
    });

    routePanelControl.routePanel.options.set({
      types: {auto: true}
    });

    myMap.controls.add(routePanelControl).add(zoomControl)

    routePanelControl.routePanel.getRouteAsync()
        .then((route: any) => {
          route.model.setParams({results: 1}, true);

          route.model.events.add('requestsuccess', () => {

            const activeRoute = route.getActiveRoute();

            if (activeRoute) {
              const length = route.getActiveRoute().properties.get('distance');
              const geoInfo = route.getActiveRoute().properties.getAll();
              const coords = geoInfo.rawProperties.boundedBy[1];
              const price = this.calculate(Math.round(length.value / 1000));

              //@ts-ignore
              ymaps.geocode(coords.reverse())
                  .then((res: any) => {
                    const geoObject = res.geoObjects.get(0);
                    const geoInfo = geoObject.properties.getAll()
                    this.territoryAddressSynced = geoInfo.text
                  })

              //@ts-ignore
              const balloonContentLayout = ymaps.templateLayoutFactory.createClass(
                  '<span>Расстояние: ' + length.text + '.</span><br/>' +
                  '<span style="font-weight: bold; font-style: italic">Стоимость перевозки: ' + price + ' р.</span>');

              route.options.set('routeBalloonContentLayout', balloonContentLayout);
            }
          })
        })
  }


  private calculate(routeLength: number) {
    // return (Math.max(routeLength) * this.DELIVERY_TARIFF, this.MINIMUM_COST);
    const price = this.calculateFunction(routeLength);
    this.priceNumberSynced = price;
    return price;
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
  width: 100%;
  height: 100%;
}
</style>
