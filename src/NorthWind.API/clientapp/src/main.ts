import { createApp } from 'vue'
import App from './App.vue'
import router from "@/router"
import '@/css/index.css'
import '@/css/services1.jpg'
import '@/fonts/Raleway-Light.ttf'

createApp(App)
    .use(router)    
    .mount('#app')
