export type RequestCallDto = {
    id: number
    name: string
    phoneNumber: string
    comment: string
    created: string
}

export type RequestCallAndPageDto = {
    pagesCount: number,
    requestCalls: RequestCallDto[]
}