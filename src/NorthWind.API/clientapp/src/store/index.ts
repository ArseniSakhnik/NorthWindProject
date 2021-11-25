import Vue from 'vue'
import Vuex from 'vuex'
import {Services} from '@/store/admin/Services'

Vue.use(Vuex)

export default new Vuex.Store({
	modules: {Services}
})

