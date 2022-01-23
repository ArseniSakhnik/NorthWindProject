import HttpService from "@/services/HttpService"
import {ConfirmEmailModel, LoginModel, RegisterModel} from "@/services/AccountService/RequestsAccountService"
import {UserDto} from "@/services/AccountService/ResponsesAccountService"

export default class AccountService extends HttpService {

	constructor() {
		super('account')
	}

	GetCurrentUserInfo(): Promise<UserDto> {
		return this._get('')
	}

	Login(loginModel: LoginModel): Promise<void> {
		return this._post('login', loginModel)
	}

	Register(registerModel: RegisterModel): Promise<void> {
		return this._post('register', registerModel)
	}

	Logout(): Promise<void> {
		return this._post('logout', {})
	}

	ConfirmEmail(confirmEmailModel: ConfirmEmailModel): Promise<void> {
		return this._post('confirm-email', confirmEmailModel)
	}
}