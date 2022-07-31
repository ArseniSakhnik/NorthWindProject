import HttpService from "@/services/HttpService";
import {RequestCall} from "@/services/RequestCallService/RequestCallServiceRequests";
import {AxiosResponse} from "axios";

export default class RequestCallService extends HttpService {
    constructor() {
        super('RequestCall');
    }
    
    public SendRequestCall(data: RequestCall) : Promise<AxiosResponse<void>> {
        return this._post('', data);
    }
}