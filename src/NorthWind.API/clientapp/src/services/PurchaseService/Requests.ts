import {ServiceTypeEnum, WasteType} from "@/enums/Enums";

export interface BasePurchaseDto {
    email: string
    phoneNumber: string
    name: string
    surname: string
    middleName: string
    //место оказания услуг
    place: string
    comment: string,
    serviceTypeId: ServiceTypeEnum | undefined;
}

export interface AssenizatorPurchaseDto extends BasePurchaseDto {
    //тип отходов
    wasteType: WasteType
    //объем выгребной ямы
    pitVolume: number
    // Расстояние от подъездного пути в метрах
    distanceFromDriveway: number
}

export interface KGODto extends BasePurchaseDto {
    //какой объем мусора планируется вывозить 
    plannedWasteVolume: number,
    // Расстояние от подъездного пути в метрах
    distanceFromDriveway: number
}

export interface KDMDto extends BasePurchaseDto {

}
