import {ServiceEnum} from "@/enums/Enums";

export interface BaseContract {
    phoneNumber: string
    placeName: string
    email: string,
    serviceRequestTypeId: ServiceEnum
}

export interface BaseFizContract extends BaseContract {
    individualFullName: string;
}

export interface BaseYurContract extends BaseContract {
    iNN: string
    kPP: string
    oGRN: string
    oKPO: string
    yurAddress: string
    customerShortName: string
    iEShortName: string
    operatesOnBasis: string
}

export interface VacuumTruckFizContract extends BaseFizContract {

}

export interface VacuumTruckYurContract extends BaseYurContract {
    
}

export interface KgoYurContract extends BaseYurContract {
    volume: string
    overload: string
}

export interface KgoFizContract extends BaseFizContract {
    volume: string,
    overload: string
}