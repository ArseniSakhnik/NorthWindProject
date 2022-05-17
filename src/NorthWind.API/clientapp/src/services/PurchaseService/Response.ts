import {ServiceTypeEnum} from "@/enums/Enums";

export type PurchaseDto = {
    id: number
    email: string
    phoneNumber: string
    name: string
    surname: string
    middleName: string
    place: string
    comment: string
    userFullName: string
    serviceTypeId: ServiceTypeEnum
}