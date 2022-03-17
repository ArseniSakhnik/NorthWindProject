export type LoginModel = {
    email: string,
    password: string,
    rememberMe: boolean
}

export type RegisterModel = {
    name: string
    surname: string
    middleName: string
    email: string
    phoneNumber: string
    password: string
}

export type ConfirmEmailModel = {
    userId: string,
    code: string
}