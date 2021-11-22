import Vue from 'vue';
import Vuetify from 'vuetify/lib/framework';
import RecyclingCar from '@/icons/RecyclingCar.vue'

Vue.use(Vuetify);

export default new Vuetify({
    icons: {
        iconfont: 'mdi',
        values: {
            // @ts-ignore
            recyclingCar: {
                component: RecyclingCar,
            },
        },
    }
});
