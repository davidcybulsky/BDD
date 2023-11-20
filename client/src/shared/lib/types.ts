export type UserType = {
    email? : string | undefined,
    login : string,
    password : string
}
export type Animal = {
    id : number
    name : string,
    specie : string,
    caretaker : string,
    enclosure : string
}
export type AnimalListType = {
    id : number
    name : string,
    specie : string,
    caretaker : string,
    enclosure : string
}[]
export type AnimalTableType = {
    animalList : AnimalListType,
    isAdmin : boolean
}
export type TicketDataType = {
    date : string,
    safari : string
}