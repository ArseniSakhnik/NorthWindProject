import Vue from 'vue'
import Vuex from 'vuex'
import {CurrentUserStore} from "@/store/CurrentUser/CurrentUserStore";

Vue.use(Vuex)

export default new Vuex.Store({
	modules: {CurrentUserStore}
})

