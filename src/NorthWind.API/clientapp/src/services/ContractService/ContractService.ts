import HttpService from "@/services/HttpService"
import {
    VacuumTruckFizIndividualContractDto,
    VacuumTruckYurContractDto
} from "@/services/ContractService/Requests"

export default class ContractService extends HttpService {

    constructor() {
        super('contract');
    }

    public GetContracts() {
        return this._createStore('')
    }

    public SendVacuumTruckFizContract(data: VacuumTruckFizIndividualContractDto) {
        return this._post('create-vacuum-truck-fiz-contract', data);
    }

    public SendVacuumTruckYurContract(data: VacuumTruckYurContractDto) {
        return this._post('create-vacuum-truck-yur-contract', data);
    }

}