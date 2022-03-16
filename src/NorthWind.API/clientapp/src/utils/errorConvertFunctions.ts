export function convert403ErrorArrayToMessage(response: any): string {
    const errorMsgArray = Object.values(response.response.data.errors);
    return errorMsgArray.join('. ');
}

export function convert400ErrorArrayToMessage(response: any): string {
    return response.response.data.errorMessage;
}