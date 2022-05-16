import Vue from 'vue'
import VueRouter, {RouteConfig} from 'vue-router'
import Home from '../views/Home.vue'
import About from '../views/About.vue'
import Admin from '../views/Admin.vue'
import CreateServicePage from '@/components/Admin/views/Services/CreateServicePage.vue'
import DeveloperPage from "@/views/DeveloperPage/DeveloperPage.vue"
import ConfirmEmail from "@/views/System/ConfirmEmail.vue"
import CreateVacuumTruckFizContract from "@/views/Contracts/CreateVacuumTruckContract.vue"
import CreateVacuumTruckYurContract from "@/views/Contracts/CreateVacuumTruckYurContract.vue";
import CreateKgoContract from "@/views/Contracts/CreateKgoContract.vue";
import AdminContracts from "@/views/AdminContracts.vue";
import AdminContract from "@/views/AdminContract.vue";
import UserInfo from "@/views/UserInfo.vue";
import AboutCar from "@/views/AboutCar.vue";
import DocumentsPage from "@/views/DocumentsPage.vue";
import ContactsPage from "@/views/ContactsPage.vue";
import PurchaseInfo from "@/views/PurchaseInfo.vue";

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
        component: AdminContracts,
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
    {
        path: '/contract',
        name: 'Contract',
        component: AdminContract,
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
        path: '/purchase-info/:id',
        name: 'PurchaseInfo',
        component: PurchaseInfo,
        meta: {
            layout: 'User'
        }
    }
]

const router = new VueRouter({
    routes
})

export default router
