import {Module} from "vuex";
import {CurrentUserStoreTypes} from "@/store/CurrentUser/CurrentUserStoreTypes";
import AccountService from "@/services/AccountService/AccountService";
import {UserDto} from "@/services/AccountService/ResponsesAccountService";

export const CurrentUserStore: Module<CurrentUserStoreTypes, any> = {
    namespaced: true,
    state: {
        userId: 0,
        email: '',
        emailConfirmed: false,
        phoneNumber: '',
        name: '',
        surname: '',
        middleName: '',
        fullName: '',
        accountService: new AccountService()
    },
    mutations: {
        SET_CURRENT_USER_INFO(state, userInfo: UserDto) {
            state.userId = userInfo.userId;
            state.email = userInfo.email;
            state.emailConfirmed = userInfo.emailConfirmed;
            state.phoneNumber = userInfo.phoneNumber;
            state.name = userInfo.name;
            state.surname = userInfo.surname;
            state.middleName = userInfo.middleName;
            state.fullName = userInfo.fullName;
        }
    },
    actions: {
        async GET_CURRENT_USER_INFO({state, commit}) {
            const userInfo = await state.accountService.GetCurrentUserInfo();
            commit('SET_CURRENT_USER_INFO', userInfo);
        }
    },
    getters: {
        IS_USER_AUTHENTICATED(state) {
            return state.userId !== 0;
        }
    }
}