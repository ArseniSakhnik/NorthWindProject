export type LoginModel = {
	email: string,
	password: string,
	rememberMe: boolean
}

export type RegisterModel = {
	email: string,
	password: string,
	confirmPassword: string
}

export type ConfirmEmailModel = {
	userId: string,
	code: string
}