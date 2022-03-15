import AccountService from "@/services/AccountService/AccountService";

export type CurrentUserStoreTypes = {
    userId: number,
    email: string,
    emailConfirmed: boolean,
    phoneNumber: string,
    name: string,
    surname: string,
    middleName: string,
    fullName: string,
    accountService: AccountService
}