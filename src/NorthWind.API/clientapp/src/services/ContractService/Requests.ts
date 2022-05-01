export interface BaseCreateContractDto {
    email: string
    phoneNumber: string
    name: string
    surname: string
    middleName: string
}

export interface VacuumTruckFizIndividualContractDto extends BaseCreateContractDto {
    passportSerialNumber: string
    passportId: string
    passportIssued: string
    passportIssueDate: string
    divisionCode: string
    registrationAddress: string
    territoryAddress: string
    price: number
}

export interface VacuumTruckYurContractDto extends BaseCreateContractDto {
    clientShortName: string,
    personalNameEntrepreneur: string,
    actsOnBasis: string,
    territoryAddress: string,
    price: number,
    priceString: string,
    oGRN: string,
    iNN: string,
    kPP: string,
    legalAddress: string,
    phoneNumber: string,
}

export interface KGOYurContractDto extends BaseCreateContractDto {
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