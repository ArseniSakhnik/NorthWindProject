export interface BaseCreatePurchaseDto {
    email: string
    phoneNumber: string
    name: string
    surname: string
    middleName: string
}

export interface PurchaseToVacuumTruckFizIndividualDto extends BaseCreatePurchaseDto {
    passportSerialNumber: string
    passportId: string
    passportIssued: string
    passportIssueDate: string
    divisionCode: string
    registrationAddress: string
    territoryAddress: string
    price: number
    contractValidDate: string
}

export interface PurchaseToVacuumTruckYurIndividualDto extends BaseCreatePurchaseDto {
    individualEntrepreneurShortName: string,
    act: number,
    territoryAddress: string,
    price: number,
    contractValidDate: string,
    oGRN: string
    iNN: string,
    kPP: string,
    legalAddress: string
}

export interface PurchaseToKGOYurIndividualDto extends BaseCreatePurchaseDto {
    fullNameClient: string
    actOnTheBasis: number
    volume: string
    territoryAddress: string
    machineReload: string
    coastPrice: string
    contractValidDate: string
    price: number
    iNN: string
    kPP: string
    oGRN: string
    oKPO: string
    legalAddress: string
    phoneNumber: string
    clientCompany: string
    customerContactPersonAndJobTitle: string
    phoneNumberOrFax: string
    vehiclesNumber: number,
    startDate: string
    endDate: string
    startTime: string
    endTime: string
}