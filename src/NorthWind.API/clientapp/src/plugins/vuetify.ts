import Vue from 'vue';
import Vuetify from 'vuetify/lib/framework';
import RecyclingCar from '@/icons/RecyclingCar.vue'
import RecyclingHome from '@/icons/RecyclingHome.vue'
import Land from '@/icons/Land.vue'

Vue.use(Vuetify);

export default new Vuetify({
    icons: {
        iconfont: 'mdi',
        values: {
            // @ts-ignore
            recyclingCar: {
                component: RecyclingCar,
            },
            // @ts-ignore
            recyclingHome: {
                component: RecyclingHome,
            },
            // @ts-ignore
            land: {
                component: Land,
            },
        },
    }
});
