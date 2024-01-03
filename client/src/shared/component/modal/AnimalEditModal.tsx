import { Modal, ModalBody, ModalHeader, Form, Button, Stack } from "react-bootstrap"
import { Animal } from "../../lib/types"
import { useState, useEffect } from "react"
import { species , safari, initAnimal, dataAnimalConvert, dataEnclosureConvert } from "../../../util/util"
import usePut from "../../../hook/usePut"

type AnimalEditModalType = {
    toggleEditModal : boolean,
    handleModalHide : () => void,
    animal : Animal
    triggerReFetching : () => void
}
type AnimalTypeConverted = {
    id : string
    name : string,
    species : number,
    dateOfBirth : string,
    caretakerId : string,
    enclosure : number
}
const initAnimalConverted : AnimalTypeConverted = {
    id : "",
    name : "",
    species : -1,
    dateOfBirth : "",
    caretakerId : "",
    enclosure : -1
}
const AnimalEditModal = ({ toggleEditModal, handleModalHide, animal, triggerReFetching } : AnimalEditModalType) => {
    const [editedAnimal, setEditedAnimal] = useState<Animal>(animal);
    const [animalToSend, setAnimalToSend] = useState<AnimalTypeConverted>(initAnimalConverted);
    const [errMsg, setErrMsg] = useState<string>('');
    const [state, putData] = usePut({ url : `/animal/${editedAnimal.id}`, body :  animalToSend });

    useEffect(() => {
        setEditedAnimal(animal);
    },[animal])

    const handleEditAnimalSubmit = () => {
        convertSpeciesAndEnclosureFromStringToNumber(editedAnimal);
        const validateAnimalName = validator()
        console.log(animalToSend)
        if(validateAnimalName) {
            const updateData = async () => {
                await putData();
                triggerReFetching()
                handleModalHide();
            }
            updateData()
        } 
    }
    const handleModalHideAndDataClear = () => {
        setEditedAnimal(initAnimal);
        setErrMsg('')
        handleModalHide();
    }
    const convertSpeciesAndEnclosureFromStringToNumber = (editAnimal : Animal) => {
        animalToSend.id = editAnimal.id
        animalToSend.name = editAnimal.name
        animalToSend.dateOfBirth = editAnimal.dateOfBirth;
        const reversedDataAnimalConvert : any= Object.fromEntries(Object.entries(dataAnimalConvert).map(([key,value]) => [value,key]))
        animalToSend.species = parseInt(reversedDataAnimalConvert[editAnimal.species]);
        const reversedDataEnclosureConvert = Object.fromEntries(Object.entries(dataEnclosureConvert).map(([key,value]) => [value,key]))
        animalToSend.enclosure = parseInt(reversedDataEnclosureConvert[editAnimal.enclosure]);
        animalToSend.caretakerId = editAnimal.caretakerId;
        setAnimalToSend(animalToSend);
    }
    const validator = () => {
        if(!editedAnimal.name) {
            setErrMsg("Animal name cannot be empty!")
            return false
        }
        if(editedAnimal.name === animal.name && 
            editedAnimal.enclosure === animal.enclosure && 
            editedAnimal.species === animal.species) {
            setErrMsg("You need to apply some changes!")
            return false
        }
        return true
    }
    return (
        <Modal show={toggleEditModal} onHide={handleModalHideAndDataClear} id="modal-edit-animal">
            <ModalHeader>
                Edit Animal
            </ModalHeader>
            <ModalBody>
                <Form>
                    <Form.Group className="mb-3">
                        <Form.Label htmlFor='nameLabel' label='email'>
                            Name
                        </Form.Label>
                        <Form.Control
                            id='nameLabel-Animal'
                            type="text"
                            placeholder='Name'
                            value={editedAnimal.name}
                            onChange={(e) => setEditedAnimal({ ...editedAnimal, name : e.target.value})}
                        />
                    </Form.Group>
                    <Form.Group className="mb-3">
                        <Form.Label htmlFor="animalEditSafari">
                            Safari
                        </Form.Label>
                        <Form.Select
                            id="animalEditSafari"
                            value={editedAnimal.enclosure}
                            onChange={(e) => setEditedAnimal({...editedAnimal, enclosure : e.target.value})}
                        >
                            {
                                safari.map((s, i) => (
                                    <option key={s} value={s}>{s}</option>
                                ))
                            }
                        </Form.Select>
                    </Form.Group>
                    <Form.Group className="mb-3">
                        <Form.Label htmlFor="animalEditSpecie">
                            Species
                        </Form.Label>
                        <Form.Select
                            id="animalEditSpecie"
                            value={editedAnimal.species}
                            onChange={(e) => setEditedAnimal({...editedAnimal, species : e.target.value})}
                        >
                            {
                                species.map((s, i) => (
                                    <option key={s} value={s}>{s}</option>
                                ))
                            }
                        </Form.Select>
                    </Form.Group>
                    {
                        errMsg ? <div id='edit-Animal-errMsg'>
                            { errMsg }
                        </div> : null
                    }
                    <Stack direction="horizontal" gap={2} className='justify-content-center'>
                        <Button onClick={handleEditAnimalSubmit} id="animal-edit-submit">
                            Submit
                        </Button>
                        <Button onClick={handleModalHideAndDataClear} variant="outline-primary">
                            Cancel
                        </Button>
                    </Stack>
                </Form>
            </ModalBody>
        </Modal>
    )
}

export default AnimalEditModal