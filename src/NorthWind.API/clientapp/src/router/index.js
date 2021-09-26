import {createRouter, createWebHistory} from 'vue-router';
import HomePage from "../views/HomePage";
import AdminPanelPage from "@/views/AdminPanelPage";
import LoginPage from "@/views/LoginPage";

const routes = [
    {
        path: '/',
        name: 'HomePage',
        component: HomePage,
        meta: {
            layout: 'main'
        },
    },
    {
        path: '/AdminPanel',
        name: 'AdminPanelPage',
        component: AdminPanelPage,
        meta: {
            layout: 'main'
        }
    },
    {
        path: '/Login',
        name: 'LoginPage',
        component: LoginPage,
        meta: {
            layout: 'main'
        }
    }
];

const router = createRouter({
    history: createWebHistory('#'),
    routes,
    linkActiveClass: 'active',
    linkExactActiveClass: 'active',
});

export default router;

