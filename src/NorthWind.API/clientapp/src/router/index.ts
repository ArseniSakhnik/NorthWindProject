import {createRouter, createWebHistory, RouteRecordRaw} from 'vue-router';
import HomePage from "@/views/HomePage.vue";
import AdminPanelPage from "@/views/AdminPanelPage.vue";
import LoginPage from "@/views/LoginPage.vue";
import DocumentsPage from '@/views/DocumentsPage.vue'


enum layouts {
    main = 'main',
    additional = 'additional'
}

const routes : Array<RouteRecordRaw> = [
    {
        path: '/',
        name: 'HomePage',
        component: HomePage,
        meta: {
            layout: layouts.main
        },
    },
    {
        path: '/AdminPanel',
        name: 'AdminPanelPage',
        component: AdminPanelPage,
        meta: {
            layout: layouts.additional
        }
    },
    {
        path: '/Login',
        name: 'LoginPage',
        component: LoginPage,
        meta: {
            layout: layouts.additional
        }
    },
    {
        path: '/Documents',
        name: 'DocumentPage',
        component: DocumentsPage,
        meta: {
            layout: layouts.additional
        }
    },
    {
        path: '/Vacancies',
        name: 'VacanciesPage',
        component: DocumentsPage,
        meta: {
            layout: layouts.additional
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

