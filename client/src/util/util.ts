import { AnimalListType, TicketDataType, UserType, Animal, CaretakerType } from "../shared/lib/types"

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
export const initCaretaker : CaretakerType = {
    id : -1,
    name : "",
    surename : ""  

}

export const animalList : AnimalListType = [
    {
        id : 1,
        name : "Miś",
        specie : "BISON",
        caretaker : "Janusz Kowalski",
        enclosure : "NORTHERN"
    }, 
    {
        id : 2,
        name : "Wilk Max",
        specie : "WOLF",
        caretaker : "Michał Nowak",
        enclosure : "SOUTHERN"
    }
]
export const safari = ["NORTHERN", "SOUTHERN", "EASTERN", "WESTERN"];
export const species = ["DUCK", "BISON", "WOLF", "EAGLE","MOOSE"];
export const caretakers = [
    {
        "id" : 1,
        "name" : "Janusz",
        "surename" : "Kowalski",
    },
    {
        "id" : 2,
        "name" : "Michał",
        "surename" : "Nowak"
    }
]