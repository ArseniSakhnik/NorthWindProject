import HttpService from "@/services/HttpService";
import {AxiosResponse} from "axios";
import {RequestCall} from "@/services/RequestCallService/Request";

export default class RequestCallService extends HttpService {
    constructor() {
        super('requestCall');
    }
    
    CreateRequest(data: RequestCall): Promise<AxiosResponse<void>> {
        return this._post('', data);
    }
}