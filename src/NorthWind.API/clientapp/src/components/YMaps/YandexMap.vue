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
    const cityArea = this.getCityPolygon();
    this.isMapLoaded = true;
    const myMap = this.getGeneratedMap();
    myMap.geoObjects.add(cityArea);
    const {routePanelControl, zoomControl} = this.getRouteAbdZoomMap();
    myMap.controls.add(routePanelControl).add(zoomControl)
    this.setRouteSettings(myMap, routePanelControl, cityArea);
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
              const price = this.calculate(Math.round(length.value / 1000));

              const edges = [];

              for (let i = 0; i < activeRoute.getPaths().getLength(); i++) {
                const way = activeRoute.getPaths().get(i);
                const segments = way.getSegments();

                for (let j = 0; j < segments.getLength(); j++) {
                  // console.log(segments.get(j).geometry.getCoordinates())
                  const coordinates = segments.get(j).geometry.getCoordinates();
                  console.log(segments.get(j).properties.getAll())
                  for (let k = 1, l = coordinates.length; k < l; k++) {
                    edges.push({
                      type: 'LineString',
                      coordinates: [coordinates[k], coordinates[k - 1]]
                    })
                  }
                }
              }

              //@ts-ignore
              const routeObjects = ymaps.geoQuery(edges)
                  .addToMap(myMap);

              const objectsInCity = routeObjects.searchInside(polygon);
              // Найдем объекты, пересекающие МКАД.
              const boundaryObjects = routeObjects.searchIntersect(polygon);
              
              boundaryObjects.setOptions({
                strokeColor: '#ff0000', //красный не в городе
              });
              
              objectsInCity.setOptions({
                strokeColor: '#0000ff', //синий в городе
              });
              
              routeObjects.remove(objectsInCity).remove(boundaryObjects).setOptions({
                strokeColor: '#ff00e1', //фиолетовый на пересечении
              });

              
              

              // //@ts-ignore
              // ymaps.route(coordinates).then(
              //     //@ts-ignore
              //     function (res) {
              //       // Объединим в выборку все сегменты маршрута.
              //       //@ts-ignore
              //       const pathsObjects = ymaps.geoQuery(res.getPaths());
              //       const edges: any[] = [];
              //
              //       console.log(pathsObjects)

              // //Переберем все сегменты и разобьем их на отрезки.
              // //@ts-ignore
              // pathsObjects.each(function (path) {
              //   const coordinates = path.geometry.getCoordinates();
              //   for (let i = 1, l = coordinates.length; i < l; i++) {
              //     edges.push({
              //       type: 'LineString',
              //       coordinates: [coordinates[i], coordinates[i - 1]]
              //     });
              //   }
              // });
              //
              // console.log(edges);

              //
              // // Создадим новую выборку, содержащую:
              // // - отрезки, описываюшие маршрут;
              // // - начальную и конечную точки;
              // // - промежуточные точки.
              // //@ts-ignore
              // const routeObjects = ymaps.geoQuery(edges)
              //     .add(res.getWayPoints())
              //     .add(res.getViaPoints())
              //     .setOptions('strokeWidth', 3)
              //     .addToMap(myMap);
              // // Найдем все объекты, попадающие внутрь МКАД.
              // const objectsInMoscow = routeObjects.searchInside(polygon);
              // // Найдем объекты, пересекающие МКАД.
              // const boundaryObjects = routeObjects.searchIntersect(polygon);
              // // Раскрасим в разные цвета объекты внутри, снаружи и пересекающие МКАД.
              // boundaryObjects.setOptions({
              //   strokeColor: '#06ff00',
              //   preset: 'islands#greenIcon'
              // });
              // objectsInMoscow.setOptions({
              //   strokeColor: '#ff0005',
              //   preset: 'islands#redIcon'
              // });
              // // Объекты за пределами МКАД получим исключением полученных выборок из
              // // исходной.
              // routeObjects.remove(objectsInMoscow).remove(boundaryObjects).setOptions({
              //   strokeColor: '#0010ff',
              //   preset: 'islands#blueIcon'
              // });
              // }
              // );


            }
          })
        })
  }

  test(myMap: any, route: any, polygon: any) {

    console.log('test')
    console.log(route)

    // Объединим в выборку все сегменты маршрута.
    //@ts-ignore
    const pathsObjects = ymaps.geoQuery(route.getPaths());
    const edges: any[] = [];

    // Переберем все сегменты и разобьем их на отрезки.
    //@ts-ignore
    pathsObjects.each(function (path) {
      const coordinates = path.geometry.getCoordinates();
      for (var i = 1, l = coordinates.length; i < l; i++) {
        edges.push({
          type: 'LineString',
          coordinates: [coordinates[i], coordinates[i - 1]]
        });
      }
    });

    // Создадим новую выборку, содержащую:
    // - отрезки, описываюшие маршрут;
    // - начальную и конечную точки;
    // - промежуточные точки.
    //@ts-ignore
    const routeObjects = ymaps.geoQuery(edges)
        .add(route.getWayPoints())
        .add(route.getViaPoints())
        .setOptions('strokeWidth', 3)
        .addToMap(myMap)

    // Найдем все объекты, попадающие внутрь МКАД.
    const objectsInMoscow = routeObjects.searchInside(polygon);
    // Найдем объекты, пересекающие МКАД.
    const boundaryObjects = routeObjects.searchIntersect(polygon);
    // Раскрасим в разные цвета объекты внутри, снаружи и пересекающие МКАД.
    boundaryObjects.setOptions({
      strokeColor: '#06ff00',
      preset: 'islands#greenIcon'
    });
    objectsInMoscow.setOptions({
      strokeColor: '#ff0005',
      preset: 'islands#redIcon'
    });
    // Объекты за пределами МКАД получим исключением полученных выборок из
    // исходной.
    routeObjects.remove(objectsInMoscow).remove(boundaryObjects).setOptions({
      strokeColor: '#0010ff',
      preset: 'islands#blueIcon'
    });
  }

  test2(myMap: any, route: any, polygon: any) {

    // Объединим в выборку все сегменты маршрута.
    //@ts-ignore
    const pathsObjects = ymaps.geoQuery(route.getRoutes());
    const edges: any[] = [];

    // Переберем все сегменты и разобьем их на отрезки.
    //@ts-ignore
    pathsObjects.each(function (path) {
      const coordinates = path.geometry.getCoordinates();
      for (let i = 1, l = coordinates.length; i < l; i++) {
        edges.push({
          type: 'LineString',
          coordinates: [coordinates[i], coordinates[i - 1]]
        });
      }
    });

    //@ts-ignore
    const routeObjects = ymaps.geoQuery(edges)
        .add(route.getWayPoints())
        .add(route.getViaPoints())
        .setOptions('strokeWidth', 3)
        .addToMap(myMap)

    // Найдем все объекты, попадающие внутрь МКАД.
    const objectsInMoscow = routeObjects.searchInside(polygon);
    // Найдем объекты, пересекающие МКАД.
    const boundaryObjects = routeObjects.searchIntersect(polygon);
    // Раскрасим в разные цвета объекты внутри, снаружи и пересекающие МКАД.
    boundaryObjects.setOptions({
      strokeColor: '#06ff00',
      preset: 'islands#greenIcon'
    });
    objectsInMoscow.setOptions({
      strokeColor: '#ff0005',
      preset: 'islands#redIcon'
    });
    // Объекты за пределами МКАД получим исключением полученных выборок из
    // исходной.
    routeObjects.remove(objectsInMoscow).remove(boundaryObjects).setOptions({
      strokeColor: '#0010ff',
      preset: 'islands#blueIcon'
    });
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
