import HttpService from "@/services/HttpService";
import {AssenizatorPurchaseDto, KDMDto, KGODto} from "@/services/PurchaseService/Requests";
import {ConfirmedType, ServiceTypeEnum} from "@/enums/Enums";
import {AxiosResponse} from "axios";
import {PurchaseDto, PurchasesAndPageCount} from "@/services/PurchaseService/Response";

export default class PurchaseService extends HttpService {
    constructor() {
        super('purchase');
    }

    public createPurchase(serviceTypeId: ServiceTypeEnum, data: AssenizatorPurchaseDto | KGODto | KDMDto): Promise<AxiosResponse<string>> {
        switch (serviceTypeId) {
            case ServiceTypeEnum.Assenizator:
                return this.CreateAssenizator(data as AssenizatorPurchaseDto);
            case ServiceTypeEnum.KGO:
                return this.CreateKGO(data as KGODto);
            case ServiceTypeEnum.WaterCleaning:
                return this.CreateKDM(data as KDMDto);
        }
    }

    private CreateAssenizator(assenizatorPurchase: AssenizatorPurchaseDto): Promise<AxiosResponse<string>> {
        return this._post('assenizator', assenizatorPurchase);
    }

    private CreateKGO(kgoPurchase: KGODto): Promise<AxiosResponse<string>> {
        return this._post('kgo', kgoPurchase);
    }

    private CreateKDM(kdmPurchase: KDMDto): Promise<AxiosResponse<string>> {
        return this._post('kdm', kdmPurchase);
    }

    public UpdatePurchase(serviceTypeId: ServiceTypeEnum, data: AssenizatorPurchaseDto | KGODto | KDMDto): Promise<AxiosResponse<string>> {
        switch (serviceTypeId) {
            case ServiceTypeEnum.Assenizator:
                return this.UpdateAssenizator(data as AssenizatorPurchaseDto);
            case ServiceTypeEnum.KGO:
                return this.UpdateKGO(data as KGODto);
            case ServiceTypeEnum.WaterCleaning:
                return this.updateKDM(data as KDMDto);
        }
    }

    private UpdateAssenizator(data: AssenizatorPurchaseDto): Promise<AxiosResponse<string>> {
        return this._put('assenizator', data);
    }

    private UpdateKGO(data: KGODto): Promise<AxiosResponse<string>> {
        return this._put('kgo', data);
    }

    private updateKDM(data: KDMDto): Promise<AxiosResponse<string>> {
        return this._put('kdm', data);
    }

    public GetPurchases(): Promise<AxiosResponse> {
        return this._get('')
    }

    public GetPurchase(purchaseId: number): Promise<AxiosResponse<AssenizatorPurchaseDto | KGODto | KDMDto>> {
        return this._get(`${purchaseId}`);
    }

    public DeletePurchase(purchaseId: number) {
        return this._delete(`${purchaseId}`);
    }

    public GetAllPurchases(page: number, searchName: string, confirmedTypeId: ConfirmedType): Promise<AxiosResponse<PurchasesAndPageCount>> {
        const search = searchName ? searchName : '';
        return this._get(`getAll?page=${page}&searchName=${search}&confirmedTypeId=${confirmedTypeId}`);
    }

    public ConfirmPurchase(purchaseId: number, isConfirmed: boolean): Promise<AxiosResponse<string>> {
        return this._put(`confirm`, {purchaseId, isConfirmed})
    }

    public GetPagesCount(): Promise<AxiosResponse<number>> {
        return this._get('pages')
    }
}