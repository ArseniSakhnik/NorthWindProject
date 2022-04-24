import HttpService from "@/services/HttpService";
import {Car} from "@/services/CarsService/Responses";

export class CarsService extends HttpService {
    constructor() {
        super('cars');
    }

    public getCars(): Promise<Car[]> {
        return this._get('')
    }
}