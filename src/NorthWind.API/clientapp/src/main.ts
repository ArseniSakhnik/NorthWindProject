import Vue from 'vue'
import App from './App.vue'
import './registerServiceWorker'
import router from './router'
import store from './store'
import vuetify from './plugins/vuetify'
import '../src/styles/globalStyle.css'
import '../src/styles/index.scss'
// @ts-ignore
import Vuesax from 'vuesax'
import 'vuesax/dist/vuesax.css'

Vue.config.productionTip = false

Vue.use(Vuesax, {

})

new Vue({
  router,
  store,
  vuetify,
  render: h => h(App)
}).$mount('#app')
