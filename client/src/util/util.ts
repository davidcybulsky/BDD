import { AnimalListType, TicketDataType, UserType, Animal } from "../shared/lib/types"

export const initAnimal : Animal = {
    id : -1,
    name : "",
    specie : "",
    caretaker : "",
    enclosure : ""
}

export const initUser : UserType = {
    email : '',
    login : '',
    password: ''
}

export const initTicketData : TicketDataType = {
    date : '',
    safari : ''
}

export const animalList : AnimalListType = [
    {
        id : 1,
        name : "Miś",
        specie : "MIS",
        caretaker : "Łukasz",
        enclosure : "NORTH"
    }, 
    {
        id : 2,
        name : "Wilk Max",
        specie : "WILK",
        caretaker : "Marcin",
        enclosure : "SOUTH"
    }
]