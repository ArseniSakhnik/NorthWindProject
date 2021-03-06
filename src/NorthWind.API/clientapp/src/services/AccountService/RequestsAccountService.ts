export type LoginModel = {
    email: string,
    password: string,
}

export type RegisterModel = {
    name: string
    surname: string
    middleName: string
    email: string
    phoneNumber: string
}

export type ConfirmEmailModel = {
    userId: string,
    code: string
}