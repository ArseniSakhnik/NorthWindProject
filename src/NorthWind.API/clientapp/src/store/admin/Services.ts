import {Module} from "vuex"


type testType = {
	niggers: boolean,
}

export const Services: Module<testType, unknown> = {
	namespaced: true,
	state: {
		niggers: true
	},
	mutations: {
		SET_HATE_NIGGERS: function ({niggers}, payload: boolean) {
			niggers = payload
		}
	},
	actions: {},
	modules: {}
}