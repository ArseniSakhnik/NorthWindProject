import HttpService from "@/services/HttpService";
import {AxiosResponse} from "axios";
import {RequestCall} from "@/services/RequestCallService/Request";
import {RequestCallAndPageDto} from "@/services/RequestCallService/Responses";

export default class RequestCallService extends HttpService {
    constructor() {
        super('requestCall');
    }

    public GetRequestCalls(searchName: string, page: number): Promise<AxiosResponse<RequestCallAndPageDto>> {
        return this._get(`?searchName=${searchName}&page=${page}`);
    }

    public CreateRequest(data: RequestCall): Promise<AxiosResponse<void>> {
        return this._post('', data);
    }
}