type MethodType = 'GET' | 'POST' | 'PUT' | 'DELETE';
type ContentType = 'application/json'

export default abstract class HttpService {
	private basePath: string = 'api/'

	protected constructor(basePath: string) {
		this.basePath += basePath
	}

	private baseRequest = async <TResponse extends unknown>
	(path: string, methodType: MethodType, body: any = null): Promise<TResponse> => {
		
		const init: RequestInit = {
			method: methodType,
			credentials: 'include',
			headers: {
				'Content-type': 'application/json'
			}
		}

		if (body) {
			init.body = JSON.stringify(body)
		}

		return fetch(this.basePath + '/' + path, init)
			.then(response => {
				return new Promise(async (resolve, reject) => {

					if (response.ok) {
						const hasContent = response.headers.has('Content-type')

						if (!hasContent) {
							resolve(response.status as TResponse)
							return
						}

						const result = await response.json()
						resolve(result)
						return
					}

					const text = await response.text()
					const error = {
						response: {
							data: JSON.parse(text)
						}
					}
					reject(error)
				})
			})
			.catch(e => {
				//ALERT
				throw e;
			}) as Promise<TResponse>
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

	protected _delete<TResponse>(path: string) {
		return this.baseRequest(path, 'DELETE');
	}
}