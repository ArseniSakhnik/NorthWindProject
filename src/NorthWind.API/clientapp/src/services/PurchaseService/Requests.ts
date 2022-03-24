export interface BaseCreatePurchaseDto {
    email: string
    phoneNumber: string
    name: string
    surname: string
    middleName: string
}

export interface PurchaseToVacuumTruckIndividualDto extends BaseCreatePurchaseDto {
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