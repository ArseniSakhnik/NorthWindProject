import HttpService from "@/services/HttpService"
import {ConfirmEmailModel, LoginModel, RegisterModel} from "@/services/AccountService/RequestsAccountService"
import {UserAndPageDto, UserDto} from "@/services/AccountService/ResponsesAccountService"
import {AxiosResponse} from "axios";
import {RolesEnum} from "@/enums/Enums";

export default class AccountService extends HttpService {

    constructor() {
        super('account')
    }

    GetCurrentUserInfo(): Promise<AxiosResponse<UserDto>> {
        return this._get('')
    }

    GetUsersAll(page: number, searchName: string, roleTypeId: RolesEnum): Promise<AxiosResponse<UserAndPageDto>> {
        return this._get(`get-all?page=${page}&searchName=${searchName}&roleTypeId=${roleTypeId}`);
    }

    ChangeUserRoles(userId: number, roles: RolesEnum[]) {
        return this._put('change-user-roles', {
            userId,
            roles
        });
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

    ResetPassword(email: string): Promise<AxiosResponse<void>> {
        return this._post('reset-password', {
            email
        });
    }
}