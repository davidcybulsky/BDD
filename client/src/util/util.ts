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
export const dataAnimalConvert : { [key : string] : string } = {
    "0" : "DUCK",
    "1" : "BISON",
    "2" : "WOLF",
    "3" : "EAGLE",
    "4" : "MOOSE"
}
export const dataEnclosureConvert : { [key : string] : string} = {
    "0" : "NORTHERN",
    "1" : "SOUTHERN",
    "2" : "EASTERN",
    "3" : "WESTERN"
}

export const safari = ["NORTHERN", "SOUTHERN", "EASTERN", "WESTERN"];
export const species = ["DUCK", "BISON", "WOLF", "EAGLE","MOOSE"];
