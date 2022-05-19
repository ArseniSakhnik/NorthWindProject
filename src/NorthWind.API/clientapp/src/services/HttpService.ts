import * as AspNetData from 'devextreme-aspnet-data-nojquery'
import axios, {AxiosRequestConfig} from "axios";

type MethodType = 'GET' | 'POST' | 'PUT' | 'DELETE';
type ContentType = 'application/json'

export default abstract class HttpService {
    private readonly basePath: string = 'api/'

    protected constructor(basePath: string) {
        this.basePath += basePath
    }

    baseRequest<TResponse, TBody>(path: string, methodType: MethodType, body: TBody | null = null): Promise<TResponse> {
        const url = this.basePath + '/' + path;
        const requestConfig: AxiosRequestConfig = {
            withCredentials: true
        }

        switch (methodType) {
            case "GET":
                return axios.get(url, requestConfig);
            case "POST":
                return axios.post(url, body, requestConfig);
            case "PUT":
                return axios.put(url, body, requestConfig);
            case "DELETE":
                return axios.delete(url, requestConfig);
        }
    }

    protected _get<TResponse>(path: string): Promise<TResponse> {
        return this.baseRequest(path, 'GET')
    }

    protected _post<TResponse, TBody>(path: string, body: TBody): Promise<TResponse> {
        return this.baseRequest(path, 'POST', body)
    }

    protected _put<TResponse, TBody>(path: string, body: TBody): Promise<TResponse> {
        return this.baseRequest(path, 'PUT', body)
    }

    protected _delete<TResponse>(path: string): Promise<TResponse> {
        return this.baseRequest(path, 'DELETE');
    }

    protected _createStore(path: string, id_name: string = 'id') {
        return AspNetData.createStore({
            key: id_name,
            loadUrl: `${this.basePath}/${path}`,
            onBeforeSend(_, ajaxOptions) {
                ajaxOptions.xhrFields = {withCredentials: true};
            }
        })
    }
}