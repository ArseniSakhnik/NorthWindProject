import HttpService from "@/services/HttpService";
import {ServiceViewDto} from "@/services/ServiceViewService/ServiceViewServiceResponse";

export default class ServiceViewService extends HttpService {
    constructor() {
        super('ServiceView');
    }

    public GetServiceViews(): Promise<ServiceViewDto[]> {
        return this._get('')
    }
}