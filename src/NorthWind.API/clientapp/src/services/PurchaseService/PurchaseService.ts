import HttpService from "@/services/HttpService"
import {PurchaseToVacuumTruckFizIndividualDto} from "@/services/PurchaseService/Requests"

export default class PurchaseService extends HttpService {
	
	constructor() {
		super('purchase');
	}
	
	public SendVacuumTruckFizPurchase(data: PurchaseToVacuumTruckFizIndividualDto) {
		return this._post('create-vacuum-truck-fiz-purchase', data);
	}
	
	public SendVacuumTruckYurPurchase(data: PurchaseToVacuumTruckFizIndividualDto) {
		return this._post('/create-vacuum-truck-yur-purchase', data);
	}
	
}