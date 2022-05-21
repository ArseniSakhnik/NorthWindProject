import HttpService from "@/services/HttpService"
import {KgoYurContract, VacuumTruckFizContract, VacuumTruckYurContract,} from "@/services/ContractService/Requests"
import {AxiosResponse} from "axios";
import {BaseContractDto, ContractAndPageDto} from "@/services/ContractService/Responses";
import {ConfirmedType, ServiceEnum} from "@/enums/Enums";

export default class ContractService extends HttpService {

    constructor() {
        super('contract');
    }

    public CreateContract(data: VacuumTruckFizContract | VacuumTruckYurContract | KgoYurContract): Promise<AxiosResponse<string>> {
        switch (data.serviceRequestTypeId) {
            case ServiceEnum.AsseniatorFiz:
                return this.CreateVacuumTruckFizContract(data as VacuumTruckFizContract);
            case ServiceEnum.AssenizatorYur:
                return this.CreateVacuumTruckYurContract(data as VacuumTruckYurContract);
            case ServiceEnum.KGOYur:
                return this.CreateKGOYurContract(data as KgoYurContract);
        }
    }

    public ConfirmContract(contractId: number, isConfirmed: boolean) {
        return this._put('confirm', {
            contractId,
            isConfirmed
        });
    }

    public GetContracts(page: number, searchName: string, confirmedTypeId: ConfirmedType): Promise<AxiosResponse<ContractAndPageDto>> {
        return this._get(`?page=${page}&searchName=${searchName}&confirmedTypeId=${confirmedTypeId}`);
    }

    private CreateVacuumTruckFizContract(data: VacuumTruckFizContract): Promise<AxiosResponse<string>> {
        return this._post('create-vacuum-truck-fiz-contract', data);
    }

    private CreateVacuumTruckYurContract(data: VacuumTruckYurContract): Promise<AxiosResponse<string>> {
        return this._post('create-vacuum-truck-yur-contract', data);
    }

    private CreateKGOYurContract(data: KgoYurContract): Promise<AxiosResponse<string>> {
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

    public UpdateContract(data: BaseContractDto): Promise<AxiosResponse<string>> {
        switch (data.serviceRequestTypeId) {
            case ServiceEnum.AsseniatorFiz:
                return this.UpdateVacuumTruckFizContract(data);
            case ServiceEnum.AssenizatorYur:
                return this.UpdateVacuumTruckYurContract(data);
            case ServiceEnum.KGOYur:
                return this.UpdateKGOYurContract(data);
        }
    }

    private UpdateVacuumTruckFizContract(data: BaseContractDto): Promise<AxiosResponse<string>> {
        return this._put('update-vacuum-truck-fiz-contract', data)
    }

    private UpdateVacuumTruckYurContract(data: BaseContractDto): Promise<AxiosResponse<string>> {
        return this._put('update-vacuum-truck-yur-contract', data);
    }

    private UpdateKGOYurContract(data: BaseContractDto): Promise<AxiosResponse<string>> {
        return this._put('update-kgo-yur-contract', data)
    }

}