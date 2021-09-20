import {createRouter, createWebHistory} from 'vue-router';
import HomePage from "../views/HomePage";
import AdminPanelPage from "@/views/AdminPanelPage";

const routes = [
    {
        path: '/',
        name: 'HomePage',
        component: HomePage,
        meta: {
            layout: 'main'
        }
    },
    {
        path: '/#/AdminPanel',
        name: 'AdminPanelPage',
        component: AdminPanelPage,
        meta: {
            layout: 'main'
        }
    }
];

const router = createRouter({
    history: createWebHistory(process.env.BASE_URL),
    routes,
    linkActiveClass: 'active',
    linkExactActiveClass: 'active',
});

export default router;

