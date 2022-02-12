<template>
  <div
      id="map"
      class="ymap"
  />
</template>

<script lang="ts">
import {Vue, Component, Ref, Prop, PropSync} from 'vue-property-decorator'
//@ts-ignore
import {yandexMap, ymapMarker, loadYmap} from 'vue-yandex-maps'


@Component({components: {yandexMap, ymapMarker}})
export default class YandexMap extends Vue {
  @Ref('map')
  map!: any

  @Prop({type: Function, required: true})
  calculateFunction!: (routeLength: number) => number;

  @PropSync('priceNumber')
  priceNumberSynced!: number;

  @PropSync('distance')
  distanceSynced!: number;

  isMapLoaded: boolean = false

  settings = {
    apiKey: '04ec0a7a-4280-4526-a85b-d7b5c299bae5',
    lang: 'ru_RU',
    coordorder: 'latlong',
    enterprise: false,
    version: '2.1'
  }


  private init() {
    this.isMapLoaded = true

    //@ts-ignore
    const myMap = new ymaps.Map('map', {
      center: [60.906882, 30.067233],
      zoom: 9,
      controls: []
    })

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

    routePanelControl.routePanel.options.set({
      type: {auto: true}
    })

    myMap.controls.add(routePanelControl).add(zoomControl)

    routePanelControl.routePanel.getRouteAsync()
        .then((route: any) => {
          route.model.setParams({results: 1}, true);

          route.model.events.add('requestsuccess', () => {

            const activeRoute = route.getActiveRoute();

            if (activeRoute) {
              const length = route.getActiveRoute().properties.get('distance');

              const price = this.calculate(Math.round(length.value / 1000));

              //@ts-ignore
              const balloonContentLayout = ymaps.templateLayoutFactory.createClass(
                  '<span>Расстояние: ' + length.text + '.</span><br/>' +
                  '<span style="font-weight: bold; font-style: italic">Стоимость доставки: ' + price + ' р.</span>');

              route.options.set('routeBalloonContentLayout', balloonContentLayout);

              activeRoute.ballom.open()
            }

          })
        })
  }

  private calculate(routeLength: number) {
    // return (Math.max(routeLength) * this.DELIVERY_TARIFF, this.MINIMUM_COST);
    const price = this.calculateFunction(routeLength)
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
