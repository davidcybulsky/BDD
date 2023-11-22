import { Modal, ModalBody, ModalHeader, Form, Button, Stack } from "react-bootstrap"
import { Animal } from "../../lib/types"
import { useState, useEffect } from "react"
import { species, caretakers, safari, initAnimal } from "../../../util/util"
import usePut from "../../../hook/usePut"

type AnimalEditModalType = {
    toggleEditModal : boolean,
    handleModalHide : () => void,
    animal : Animal
}

const AnimalEditModal = ({ toggleEditModal, handleModalHide, animal} : AnimalEditModalType) => {
    const [editedAnimal, setEditedAnimal] = useState<Animal>(animal);
    const [state, putData] = usePut({ url : '/text', body :  editedAnimal });

    useEffect(() => {
        setEditedAnimal(animal);
    },[animal])

    const handleEditAnimalSubmit = () => {
        console.log(editedAnimal);
        // putData();
    }
    const handleModalHideAndDataClear = () => {
        setEditedAnimal(initAnimal);
        handleModalHide();
    }
    
    return (
        <Modal show={toggleEditModal} onHide={handleModalHideAndDataClear}>
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
                            id='nameLabel'
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
                            value={editedAnimal.specie}
                            onChange={(e) => setEditedAnimal({...editedAnimal, specie : e.target.value})}
                        >
                            {
                                species.map((s, i) => (
                                    <option key={s} value={s}>{s}</option>
                                ))
                            }
                        </Form.Select>
                    </Form.Group>
                    <Form.Group className="mb-3">
                        <Form.Label htmlFor="animalEditCaretaker">
                            Caretaker
                        </Form.Label>
                        <Form.Select
                            id="animalEditCaretaker"
                            value={editedAnimal.caretaker}
                            onChange={(e) => setEditedAnimal({...editedAnimal, caretaker : e.target.value})}
                        >
                            {
                                caretakers.map((s, i) => (
                                    <option key={s.name} value={`${s.name}` + `${ s.surename}`}>{s.name} {s.surename}</option>
                                ))
                            }
                        </Form.Select>
                    </Form.Group>
                    <Stack direction="horizontal" gap={2} className='justify-content-center'>
                        <Button onClick={handleEditAnimalSubmit}>
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