import HttpService from "@/services/HttpService"
import {
    KgoYurContract,
    VacuumTruckFizContract,
    VacuumTruckYurContract,
} from "@/services/ContractService/Requests"
import {AxiosResponse} from "axios";

export default class ContractService extends HttpService {

    constructor() {
        super('contract');
    }

    public GetContracts() {
        return this._createStore('')
    }

    public CreateVacuumTruckFizContract(data: VacuumTruckFizContract): Promise<AxiosResponse<string>> {
        return this._post('create-vacuum-truck-fiz-contract', data);
    }

    public CreateVacuumTruckYurContract(data: VacuumTruckYurContract): Promise<AxiosResponse<string>> {
        return this._post('create-vacuum-truck-yur-contract', data);
    }

    public CreateKGOYurContract(data: KgoYurContract) {
        return this._post('create-kgo-yur-contract', data)
    }

}