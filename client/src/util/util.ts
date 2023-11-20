import { AnimalListType, TicketDataType, UserType } from "../shared/lib/types"

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