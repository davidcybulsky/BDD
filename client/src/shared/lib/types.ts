export type UserType = {
    // id : string | undefined
    email? : string | undefined,
    username : string,
    password : string
}
export type Animal = {
    id : string
    name : string,
    species : string,
    dateOfBirth : string,
    caretakerId : string,
    enclosure : string
}
export type AnimalListType = {
    id : string
    name : string,
    species : string,
    dateOfBirth : string,
    caretakerId: string,
    enclosure : string
}[]

export type TicketDataType = {
    date : string,
    safari : string
}
export type CaretakerListType = {
    id : string, 
    firstName : string,
    lastName : string

}[]
export type CaretakerType = {
    id : string, 
    firstName : string,
    lastName : string
}