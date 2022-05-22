import {RolesEnum} from "@/enums/Enums";

export type UserDto = {
    userId: number,
    email: string,
    emailConfirmed: boolean,
    phoneNumber: string,
    name: string,
    surname: string,
    middleName: string,
    fullName: string,
    roles: RolesEnum[]
}

export type UserAndPageDto = {
    users: UserDto[],
    pagesCount: number
}