import {Module} from "vuex";
import {AlertState} from "@/store/Alert/AlertStoreTypes";

export const AlertStore: Module<AlertState, any> = {
    state: {
        isActive: false,
        alertMessage: '',
        timeoutId: 0
    },
    actions: {
        CALL_ALERT: function({state}, delay: number) {
            state.isActive = true;
            state.timeoutId = setTimeout(() => state.isActive = false, delay)
        }
    }
}