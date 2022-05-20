import HttpService from "@/services/HttpService"
import {
    KgoYurContract,
    VacuumTruckFizContract,
    VacuumTruckYurContract,
} from "@/services/ContractService/Requests"
import {AxiosResponse} from "axios";
import {ContractAndPageDto, ContractDto} from "@/services/ContractService/Responses";
import {ConfirmedType} from "@/enums/Enums";

export default class ContractService extends HttpService {

    constructor() {
        super('contract');
    }

    public GetContracts(page: number, searchName: string, confirmedTypeId: ConfirmedType): Promise<AxiosResponse<ContractAndPageDto>> {
        return this._get(`?page=${page}&searchName=${searchName}&confirmedTypeId=${confirmedTypeId}`);
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

    public GetUserContracts(): Promise<AxiosResponse<any>> {
        return this._get('get-user-contracts');
    }

    public GetContract(contractId: number): Promise<AxiosResponse<any>> {
        return this._get(`${contractId}`)
    }

    public RemoveContracts(contractId: number): Promise<AxiosResponse<any>> {
        return this._delete(`${contractId}`);
    }

}