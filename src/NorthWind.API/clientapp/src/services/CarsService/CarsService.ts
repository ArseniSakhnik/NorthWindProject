import HttpService from "@/services/HttpService";
import {Car} from "@/services/CarsService/Responses";
import {AxiosResponse} from "axios";

export class CarsService extends HttpService {
    constructor() {
        super('cars');
    }

    public getCars(): Promise<AxiosResponse<Car[]>> {
        return this._get('')
    }
}