enum MethodType {
  GET = 'GET',
  POST = 'POST',
  PUT = 'PUT',
  DELETE = 'DELETE'
}

export abstract class Service {

  public async getTest(): Promise<Response> {
    return await fetch('api/Test', {
      method: 'GET',
      mode: 'cors',
      credentials: 'include',
      headers: {
        'Content-Type': 'application/json'
      }
    })
  }

  public async request(path: string, body: any, type: MethodType): Promise<Response> {
    return await fetch('api' + path, {
      method: type,
      mode: 'cors',
      credentials: 'include',
      headers: {
        'Content-Type': 'application/json'
      },
      body: body
    })
  }

  public async get(path: string = ''): Promise<Response> {
    return await this.request(path, null, MethodType.GET);
  }

  public async post<T>(path: string = '', body: T): Promise<Response> {
    return await this.request(path, body, MethodType.POST);
  }

  public async put<T>(path: string = '', body: T): Promise<Response> {
    return await this.request(path, body, MethodType.PUT);
  }

  public async delete(path: string = ''): Promise<Response> {
    return await this.request(path, null, MethodType.PUT);
  }

}
