import Vue from 'vue'
import Vuex from 'vuex'
import {AlertStore} from "@/store/Alert/AlertStore";
import {RequestCallStore} from "@/store/RequestCall/RequestCallStore";

Vue.use(Vuex)

export default new Vuex.Store({
    modules: {AlertStore, RequestCallStore}
})

