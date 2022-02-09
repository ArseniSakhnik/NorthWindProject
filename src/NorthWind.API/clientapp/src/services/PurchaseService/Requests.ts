export interface BaseCreatePurchaseDto {
	email: string,
	phoneNumber: string
}

export interface PurchaseToVacuumTruckIndividualDto extends BaseCreatePurchaseDto {
	fullName: string,
	passportSerialNumber: string,
	passportNumber: string,
	passportIssued: string,
	passportIssueDate: string,
	territoryAddress: string,
	passportDivisionNumber: string,
	registrationAddress: string,
	priceNumber: number
}