import Vue from 'vue'
import Vuex from 'vuex'
import {Services} from '@/store/admin/Services'
import {CurrentUserStore} from "@/store/CurrentUser/CurrentUserStore";

Vue.use(Vuex)

export default new Vuex.Store({
	modules: {Services, CurrentUserStore}
})

