import HttpService from "@/services/HttpService";
import {ServiceViewDto} from "@/services/ServiceViewService/ServiceViewServiceResponse";
import {AxiosResponse} from "axios";

export default class ServiceViewService extends HttpService {
    constructor() {
        super('ServiceView');
    }

    public GetServiceViews(): Promise<AxiosResponse<ServiceViewDto[]>> {
        return this._get('')
    }
}