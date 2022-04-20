import Vue from 'vue'
import VueRouter, {RouteConfig} from 'vue-router'
import Home from '../views/Home.vue'
import About from '../views/About.vue'
import Admin from '../views/Admin.vue'
import CreateServicePage from '@/components/Admin/views/Services/CreateServicePage.vue'
import DeveloperPage from "@/views/DeveloperPage/DeveloperPage.vue"
import ConfirmEmail from "@/views/System/ConfirmEmail.vue"
import CreateVacuumTruckFizPurchase from "@/views/Purchases/CreateVacuumTruckPurchase.vue"
import CreateVacuumTruckYurPurchase from "@/views/Purchases/CreateVacuumTruckYurPurchase.vue";
import CreateKgoPurchase from "@/views/Purchases/CreateKgoPurchase.vue";
import AdminPurchases from "@/views/AdminPurchases.vue";
import AdminPurchase from "@/views/AdminPurchase.vue";
import UserInfo from "@/views/UserInfo.vue";
import Purchase from "@/components/Purchase.vue";
import AboutCar from "@/views/AboutCar.vue";

Vue.use(VueRouter)

const routes: Array<RouteConfig> = [
    {
        path: '/',
        name: 'Home',
        component: Home,
        meta: {
            layout: 'Main'
        }
    },
    {
        path: '/about',
        name: 'About',
        component: About,
        meta: {
            layout: 'Main'
        }
    },
    {
        path: '/user-info',
        name: 'UserInfo',
        component: UserInfo,
        meta: {
            layout: 'User'
        }
    },
    {
        path: '/admin',
        name: 'Admin',
        component: AdminPurchases,
        meta: {
            layout: 'Admin'
        }
    },
    {
        path: '/confirm-email',
        name: 'ConfirmEmail',
        component: ConfirmEmail,
        meta: {
            layout: 'System'
        }
    },
    {
        path: '/create-service',
        name: 'CreateService',
        component: CreateServicePage,
        meta: {
            layout: 'Admin'
        }
    },
    {
        path: '/developer-page',
        name: 'DeveloperPage',
        component: DeveloperPage,
        meta: {
            layout: 'Main'
        }
    },
    {
        path: '/create-vacuum-truck-fiz-purchase',
        name: 'CreateVacuumTruckFizPurchase',
        component: CreateVacuumTruckFizPurchase,
        meta: {
            layout: 'Action'
        }
    },
    {
        path: '/create-vacuum-truck-yur-purchase',
        name: 'CreateVacuumTruckPurchase',
        component: CreateVacuumTruckYurPurchase,
        meta: {
            layout: 'Action'
        }
    },
    {
        path: '/create-kgo-purchase',
        name: 'CreateKgoPurchase',
        component: CreateKgoPurchase,
        meta: {
            layout: 'Action'
        }
    },
    {
        path: '/purchase',
        name: 'Purchase',
        component: AdminPurchase,
        meta: {
            layout: 'Admin'
        }
    },
    {
        path: '/about-car',
        name: 'AboutCar',
        component: AboutCar,
        meta: {
            layout: 'Main'
        }
    }
]

const router = new VueRouter({
    routes
})

export default router
