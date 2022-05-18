import {Module} from "vuex";
import {AlertState} from "@/store/Alert/AlertStoreTypes";

export const AlertStore: Module<AlertState, any> = {
    namespaced: true,
    state: {
        isActive: false,
        alertMessage: '',
        isError: false,
        timeoutId: 0
    },
    actions: {
        CALL_ALERT: function ({state}, data: { message: string, delay: number, isError: boolean | undefined }) {
            state.isActive = true;
            state.alertMessage = data.message;
            state.timeoutId = setTimeout(() => state.isActive = false, data.delay);
            //@ts-ignore
            state.isError = data.isError;
        }
    }
}