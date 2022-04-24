export type CarInfoModel = {
    indicator: string,
    parameter: string
}

export type Car = {
    id: number,
    path: string,
    title: string
    about: string
    description: string
    carModels: CarInfoModel[]
}