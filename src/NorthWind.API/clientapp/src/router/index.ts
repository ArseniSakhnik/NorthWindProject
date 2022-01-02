import Vue from 'vue'
import VueRouter, { RouteConfig } from 'vue-router'
import Home from '../views/Home.vue'
import About from '../views/About.vue'
import Admin from '../views/Admin.vue'
import CreateServicePage from '@/components/Admin/views/Services/CreateServicePage.vue'

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
    path: '/create-service',
    name: 'CreateService',
    component: CreateServicePage,
    meta: {
      layout: 'Admin'
    }
  }
]

const router = new VueRouter({
  mode: 'history',
  base: process.env.BASE_URL,
  routes
})

export default router
