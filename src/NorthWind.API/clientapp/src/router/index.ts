import Vue from 'vue'
import VueRouter, {RouteConfig} from 'vue-router'
import Home from '../views/Home.vue'
import AboutCar from "@/views/AboutCar.vue";
import DocumentsPage from "@/views/DocumentsPage.vue";
import ContactsPage from "@/views/ContactsPage.vue";


Vue.use(VueRouter)

const mainRoutes: Array<RouteConfig> = [
    {
        path: '/about-car/:id',
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
        path: '/',
        name: 'Home',
        component: Home,
        meta: {
            layout: 'Main'
        }
    },
]

const routes: Array<RouteConfig> = mainRoutes

const router = new VueRouter({
    routes
})

export default router
