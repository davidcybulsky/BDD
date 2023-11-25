import { AnimalListType, TicketDataType, UserType, Animal, CaretakerType, CaretakerListType} from "../shared/lib/types"
import { UserTypeCnt } from "../context/AuthProvider"
export const initCaretaker : CaretakerType = {
    id : "",
    firstName : "",
    lastName : ""  
}
export const initCaretakerList : CaretakerListType = [{
    id : "",
    firstName : "",
    lastName : ""  
}]
export const initAnimal : Animal = {
    id : "",
    name : "",
    species : "",
    caretakerId : "",
    dateOfBirth : "",
    enclosure : ""
}
export const initAnimalList : AnimalListType = [{
    id : "",
    name : "",
    species : "",
    caretakerId : "",
    dateOfBirth : "",
    enclosure : ""
}]
export const initUser : UserTypeCnt = {
    username : '',
    password: '',
    email : ''
}

export const initTicketData : TicketDataType = {
    date : '',
    safari : ''
}


// export const animalList : AnimalListType = [
//     {
//         id : 1,
//         name : "Miś",
//         specie : "BISON",
//         caretaker : "Janusz Kowalski",
//         enclosure : "NORTHERN"
//     }, 
//     {
//         id : 2,
//         name : "Wilk Max",
//         specie : "WOLF",
//         caretaker : "Michał Nowak",
//         enclosure : "SOUTHERN"
//     }
// ]
export const safari = ["NORTHERN", "SOUTHERN", "EASTERN", "WESTERN"];
export const species = ["DUCK", "BISON", "WOLF", "EAGLE","MOOSE"];
// export const caretakers = [
//     {
//         "id" : 1,
//         "name" : "Janusz",
//         "surename" : "Kowalski",
//     },
//     {
//         "id" : 2,
//         "name" : "Michał",
//         "surename" : "Nowak"
//     }
// ]