import Vue from 'vue'
import VueRouter, { RouteConfig } from 'vue-router'
import Home from '../views/Home.vue'
import About from '../views/About.vue'
import Admin from '../views/Admin.vue'
import CreateServicePage from '@/components/Admin/views/Services/CreateServicePage.vue'
import DeveloperPage from "@/views/DeveloperPage/DeveloperPage.vue"
import ConfirmEmail from "@/views/System/ConfirmEmail.vue"
import CreateVacuumTruckPurchase from "@/views/Purchases/CreateVacuumTruckPurchase.vue"

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
    path: '/admin',
    name: 'Admin',
    component: Admin,
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
    path: '/create-vacuum-truck-purchase',
    name: 'CreateVacuumTruckPurchase',
    component: CreateVacuumTruckPurchase,
    meta: {
      layout: 'Action'
    }
  }
]

const router = new VueRouter({
  mode: 'history',
  base: process.env.BASE_URL,
  routes
})

export default router
