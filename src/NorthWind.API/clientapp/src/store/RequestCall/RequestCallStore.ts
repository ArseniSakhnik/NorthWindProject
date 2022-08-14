import {Module} from "vuex";
import {RequestCall} from "@/store/RequestCall/RequestCallType";

export const RequestCallStore: Module<RequestCall, any> = {
    namespaced: true,
    state: {
        signal: false
    },
    mutations: {
        OPEN_CONTACT_US_SECTION(state, value: boolean) {
            state.signal = value;
        }
    }
}