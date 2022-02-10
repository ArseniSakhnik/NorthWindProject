<template>
  <div 
      id="map" 
      class="ymap"
  >
  </div>
</template>

<script lang="ts">
import {Vue, Component, Ref} from 'vue-property-decorator'
//@ts-ignore
import {yandexMap, ymapMarker, loadYmap} from 'vue-yandex-maps'


@Component({components: {yandexMap, ymapMarker}})
export default class YandexMap extends Vue {
  @Ref('map') private map!: any

  private isMapLoaded: boolean = false

  //в рефы
  private DELIVERY_TARIFF: number = 20
  private MINIMUM_COST: number = 500
  
  
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
    console.log(routeLength)
    return (Math.max(routeLength) * this.DELIVERY_TARIFF, this.MINIMUM_COST);
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
