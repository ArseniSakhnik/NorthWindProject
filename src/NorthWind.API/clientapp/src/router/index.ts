import Vue from 'vue'
import VueRouter, {RouteConfig} from 'vue-router'
import Home from '../views/Home.vue'
import About from '../views/About.vue'
import Admin from '../views/Admin.vue'
import DeveloperPage from "@/views/DeveloperPage/DeveloperPage.vue"
import ConfirmEmail from "@/views/System/ConfirmEmail.vue"
import CreateVacuumTruckFizContract from "@/views/Contracts/CreateVacuumTruckContract.vue"
import CreateVacuumTruckYurContract from "@/views/Contracts/CreateVacuumTruckYurContract.vue";
import CreateKgoContract from "@/views/Contracts/CreateKgoContract.vue";
import UserPurchases from "@/views/UserPurchases.vue";
import AboutCar from "@/views/AboutCar.vue";
import DocumentsPage from "@/views/DocumentsPage.vue";
import ContactsPage from "@/views/ContactsPage.vue";
import PurchaseInfo from "@/views/PurchaseInfo.vue";
import AdminPurchases from "@/views/AdminPurchases.vue";
import UserContracts from "@/views/UserContracts.vue";

Vue.use(VueRouter)

const adminRoutes: Array<RouteConfig> = [
    {
        path: '/admin-purchases',
        name: 'AdminPurchases',
        component: AdminPurchases,
        meta: {
            layout: 'Admin'
        }
    }
]

const userRoutes: Array<RouteConfig> = [
    {
        path: '/user-purchases',
        name: 'UserInfo',
        component: UserPurchases,
        meta: {
            layout: 'User'
        }
    },
    {
        path: '/purchase-info/:id',
        name: 'PurchaseInfo',
        component: PurchaseInfo,
        meta: {
            layout: 'User'
        }
    },
    {
        path: '/user-contracts',
        name: 'UserContracts',
        component: UserContracts,
        meta: {
            layout: 'User'
        }
    }
]

const mainRoutes: Array<RouteConfig> = [
    {
        path: '/about-car',
        name: 'AboutCar',
        component: AboutCar,
        meta: {
            layout: 'main'
        }
    },
    {
        path: '/documents',
        name: 'Documents',
        component: DocumentsPage,
        meta: {
            layout: 'main'
        }
    },
    {
        path: '/contacts',
        name: 'Contacts',
        component: ContactsPage,
        meta: {
            layout: 'main'
        }
    },
    {
        path: '/developer-page',
        name: 'DeveloperPage',
        component: DeveloperPage,
        meta: {
            layout: 'main'
        }
    },
    {
        path: '/',
        name: 'Home',
        component: Home,
        meta: {
            layout: 'Main'
        }
    },
]

const systemRoutes: Array<RouteConfig> = [
    {
        path: '/confirm-email',
        name: 'ConfirmEmail',
        component: ConfirmEmail,
        meta: {
            layout: 'System'
        }
    },
]

const actionRoutes: Array<RouteConfig> = [
    {
        path: '/create-vacuum-truck-fiz-contract',
        name: 'CreateVacuumTruckFizContract',
        component: CreateVacuumTruckFizContract,
        meta: {
            layout: 'Action'
        }
    },
    {
        path: '/create-vacuum-truck-yur-contract',
        name: 'CreateVacuumTruckContract',
        component: CreateVacuumTruckYurContract,
        meta: {
            layout: 'Action'
        }
    },
    {
        path: '/create-kgo-contract',
        name: 'CreateKgoContract',
        component: CreateKgoContract,
        meta: {
            layout: 'Action'
        }
    },
]

const routes: Array<RouteConfig> = adminRoutes
    .concat(userRoutes)
    .concat(mainRoutes)
    .concat(systemRoutes)
    .concat(actionRoutes)

const router = new VueRouter({
    routes
})

export default router
