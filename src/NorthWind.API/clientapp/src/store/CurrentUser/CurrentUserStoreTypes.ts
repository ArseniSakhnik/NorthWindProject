import AccountService from "@/services/AccountService/AccountService";
import {RolesEnum} from "@/enums/Enums";

export type CurrentUserStoreTypes = {
    userId: number,
    email: string,
    emailConfirmed: boolean,
    phoneNumber: string,
    name: string,
    surname: string,
    middleName: string,
    fullName: string,
    accountService: AccountService,
    roles: RolesEnum[]
}