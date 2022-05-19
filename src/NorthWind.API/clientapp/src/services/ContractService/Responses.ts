import {ServiceEnum} from "@/enums/Enums";

export interface BaseContractDto {
    day: string
    month: string
    year: string
    phoneNumber: string
    placeName: string
    email: string
    serviceRequestTypeId: ServiceEnum
}

export interface BaseFizContractDto extends BaseContractDto {
    individualFullName: string
}

export interface BaseYurContractDto extends BaseContractDto {
    iNN: string
    kPP: string
    oGRN: string
    oKPO: string
    yurAddress: string
    customerShortName: string
    iEShortName: string
    operatesOnBasis: string
}

export interface KGOYurContractDto extends BaseYurContractDto {
    overload: string;
    volume: string;
}