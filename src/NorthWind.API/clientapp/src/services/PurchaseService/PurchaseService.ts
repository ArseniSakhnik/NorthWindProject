import HttpService from "@/services/HttpService"
import {
	PurchaseToVacuumTruckFizIndividualDto,
	PurchaseToVacuumTruckYurIndividualDto
} from "@/services/PurchaseService/Requests"

export default class PurchaseService extends HttpService {
	
	constructor() {
		super('purchase');
	}
	
	public GetPurchases() {
		return this._createStore('')
	}
	
	public SendVacuumTruckFizPurchase(data: PurchaseToVacuumTruckFizIndividualDto) {
		return this._post('create-vacuum-truck-fiz-purchase', data);
	}
	
	public SendVacuumTruckYurPurchase(data: PurchaseToVacuumTruckYurIndividualDto) {
		return this._post('create-vacuum-truck-yur-purchase', data);
	}
	
}