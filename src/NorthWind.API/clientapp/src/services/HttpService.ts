type MethodType = 'GET' | 'POST' | 'PUT' | 'DELETE';
type ContentType = 'application/json'

export default abstract class HttpService {
	private basePath: string = 'api/'

	protected constructor(basePath: string) {
		this.basePath += basePath
	}

	protected baseRequest<TBody, TResponse>(path: string, methodType: MethodType, contentType: ContentType, body: TBody | null = null): Promise<TResponse> {
		const requestInit: RequestInit = {
			credentials: 'include',
			method: methodType,
			headers: {
				'Content-type': contentType
			},
		}

		if (methodType === 'POST' || methodType === 'PUT') {
			requestInit.body = JSON.stringify(body);
		}
		
		const request = fetch(path, requestInit)
			.then(response => response.json())
			.then(response => response as TBody);
	}
	


}