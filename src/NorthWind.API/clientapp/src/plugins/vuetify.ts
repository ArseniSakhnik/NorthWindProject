import Vue from 'vue';
import Vuetify from 'vuetify/lib/framework';
import RecyclingCar from '@/icons/RecyclingCar.vue'
import RecyclingHome from '@/icons/RecyclingHome.vue'
import Land from '@/icons/Land.vue'
import Customer from '@/icons/Customer.vue'
import Time from '@/icons/Time.vue'
import Reward from '@/icons/Reward.vue'


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
            // @ts-ignore
            customer: {
                component: Customer,
            },
            time: {
                component: Time,
            },
            reward: {
                component: Reward,
            },
        },
    }
});
