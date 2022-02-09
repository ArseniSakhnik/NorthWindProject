import HttpService from "@/services/HttpService"
import {PurchaseToVacuumTruckIndividualDto} from "@/services/PurchaseService/Requests"

export default class PurchaseService extends HttpService {
	
	constructor() {
		super('purchase');
	}
	
	public SendVacuumTruckPurchase(data: PurchaseToVacuumTruckIndividualDto) {
		return this._post('create-vacuum-truck-individual-purchase', data);
	}
	
}