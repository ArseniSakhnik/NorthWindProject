import Vue from 'vue'
import VueRouter, {RouteConfig} from 'vue-router'
import Home from '../views/Home.vue'
import Admin from '../views/Admin.vue'
import DeveloperPage from "@/views/DeveloperPage/DeveloperPage.vue"
import ConfirmEmail from "@/views/System/ConfirmEmail.vue"
import UserPurchases from "@/views/UserPurchases.vue";
import AboutCar from "@/views/AboutCar.vue";
import DocumentsPage from "@/views/DocumentsPage.vue";
import ContactsPage from "@/views/ContactsPage.vue";
import PurchaseInfo from "@/views/PurchaseInfo.vue";
import AdminPurchases from "@/views/AdminPurchases.vue";
import UserContracts from "@/views/UserContracts.vue";
import CreateKgoYurContract from '@/views/Contracts/CreateKgoYurContract.vue';
import CreateVacuumTruckYurContract from "@/views/Contracts/CreateVacuumTruckYurContract.vue";
import CreateVacuumTruckFizContract from "@/views/Contracts/CreateVacuumTruckFizContract.vue";
import ContractInfoPage from "@/views/ContractInfoPage.vue";
import AdminContracts from "@/views/AdminContracts.vue";

Vue.use(VueRouter)

const adminRoutes: Array<RouteConfig> = [
    {
        path: '/admin-purchases',
        name: 'AdminPurchases',
        component: AdminPurchases,
        meta: {
            layout: 'Admin',
            name: 'Заявки'
        }
    },
    {
        path: '/admin-contracts',
        name: 'AdminContracts',
        component: AdminContracts,
        meta: {
            layout: 'Admin',
            name: 'Договоры'
        }
    },
    {
        path: '/purchase-info-admin/:id',
        name: 'PurchaseInfo',
        component: PurchaseInfo,
        meta: {
            layout: 'Admin',
            name: 'Информация о заявке'
        }
    },
    {
        path: '/contract-info-admin/:id',
        name: 'ContractInfoAdmin',
        component: ContractInfoPage,
        meta: {
            layout: 'Admin',
            name: 'Информация о договоре'
        }
    }
]

const userRoutes: Array<RouteConfig> = [
    {
        path: '/user-purchases',
        name: 'UserInfo',
        component: UserPurchases,
        meta: {
            layout: 'User',
            name: 'Ваши заявки'
        }
    },
    {
        path: '/purchase-info/:id',
        name: 'PurchaseInfo',
        component: PurchaseInfo,
        meta: {
            layout: 'User',
            name: 'Информация о заявке'
        }
    },
    {
        path: '/user-contracts',
        name: 'UserContracts',
        component: UserContracts,
        meta: {
            layout: 'User',
            name: 'Ваши договоры'
        }
    },
    {
        path: '/create-kgo-yur-contract',
        name: 'CreateKgoYurContract',
        component: CreateKgoYurContract,
        meta: {
            layout: 'User',
            name: 'Заявка на вывоз крупногабаритного мусора'
        }
    },
    {
        path: '/create-vacuum-truck-yur-contract',
        name: 'CreateVacuumTruckContract',
        component: CreateVacuumTruckYurContract,
        meta: {
            layout: 'User',
            name: 'Заявка на вывоз крупногабаритного мусора '
        }
    },
    {
        path: '/create-vacuum-truck-fiz-contract',
        name: 'CreateVacuumTruckFizContract',
        component: CreateVacuumTruckFizContract,
        meta: {
            layout: 'User',
            name: 'Заявка на откачку жидких бытовых отходов'
        }
    },
    {
        path: '/contract-info/:id',
        name: 'ContractInfo',
        component: ContractInfoPage,
        meta: {
            layout: 'User',
            name: 'Сведения о заявке'
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

const routes: Array<RouteConfig> = adminRoutes
    .concat(userRoutes)
    .concat(mainRoutes)
    .concat(systemRoutes)

const router = new VueRouter({
    routes
})

export default router
