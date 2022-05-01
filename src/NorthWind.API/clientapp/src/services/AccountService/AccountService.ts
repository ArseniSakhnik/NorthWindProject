import HttpService from "@/services/HttpService"
import {ConfirmEmailModel, LoginModel, RegisterModel} from "@/services/AccountService/RequestsAccountService"
import {UserDto} from "@/services/AccountService/ResponsesAccountService"
import {AxiosResponse} from "axios";

export default class AccountService extends HttpService {

    constructor() {
        super('account')
    }

    GetCurrentUserInfo(): Promise<AxiosResponse<UserDto>> {
        return this._get('')
    }

    Login(loginModel: LoginModel): Promise<AxiosResponse<void>> {
        return this._post('login', loginModel)
    }

    Register(registerModel: RegisterModel): Promise<AxiosResponse<void>> {
        return this._post('register', registerModel)
    }

    Logout(): Promise<void> {
        return this._post('logout', {})
    }

    ConfirmEmail(confirmEmailModel: ConfirmEmailModel): Promise<AxiosResponse<void>> {
        return this._post('confirm-email', confirmEmailModel)
    }
}