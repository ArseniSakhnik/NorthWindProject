type methodType = 'GET' | 'POST' | 'PUT' | 'DELETE'

export abstract class HttpContext {
    protected url: string = 'api'


    protected constructor(controller: string) {
        this.url += controller
    }

    public async _get(path: string) : Promise<Response> {
        const url = this.url += path
        const request = HttpContext.getRequestInit('GET')
        return await fetch(url, request)
    }

    public async _post(path: string, body?: object) : Promise<Response> {
        const url = this.url += path
        const request = HttpContext.getRequestInit('POST')
        if (body) {
            request.body = JSON.stringify(body)
        }
        return await fetch(url, request)
    }

    public async _put(path: string, body?: object) : Promise<Response> {
        const url = this.url += path
        const request = HttpContext.getRequestInit('PUT')
        if (body) {
            request.body = JSON.stringify(body)
        }
        return await fetch(url, request)
    }

    public async _delete(path: string, body?: object) : Promise<Response> {
        const url = this.url += path
        const request = HttpContext.getRequestInit('DELETE')
        if (body) {
            request.body = JSON.stringify(body)
        }
        return await fetch(url, request)
    }

    private static getRequestInit(methodType: methodType): RequestInit {
        return {
            method: methodType,
            credentials: 'include',
            headers: {
                'Accept': 'application/json, text/plain, */*',
                'Content-Type': 'application/json'
            },
        }
    }
}