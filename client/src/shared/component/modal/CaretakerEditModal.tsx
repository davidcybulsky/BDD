import React, { useEffect, useState } from 'react'
import { Modal, ModalBody, ModalHeader, Form, Stack, Button } from 'react-bootstrap'
import { CaretakerType } from '../../lib/types'
import { initCaretaker } from '../../../util/util'
import usePut from '../../../hook/usePut'
type CaretakerEditModalType = {
    toggleEditModal : boolean,
    handleModalHide : () => void,
    caretaker : CaretakerType,
    triggerReFetch : () => void
}

const CaretakerEditModal = ({ toggleEditModal, handleModalHide, caretaker, triggerReFetch} : CaretakerEditModalType) => {
    const [editedCaretaker, setEditedCaretaker] = useState<CaretakerType>(initCaretaker);
    const [errMsg, setErrMsg] = useState<string>('');
    const [_ , putData] = usePut({
        "url" : `/caretaker/${caretaker.id}`,
        "body" : editedCaretaker
    });

    useEffect(() => {
        setEditedCaretaker(caretaker);
    },[caretaker])

    const handleSubmitEditCaretaker = () => {
        const performUpdate = async() => {
            await putData()
            triggerReFetch();
            setErrMsg('')
            handleModalHide();
        }
        const isValidated = validator();
        if(isValidated) {
            performUpdate()
        }
    }
    const handleModalHideAndClearData = () => {
        setEditedCaretaker(initCaretaker);
        setErrMsg('')
        handleModalHide()
    }
    const validator = () => {
        if(!editedCaretaker.firstName && !editedCaretaker.lastName) {
            setErrMsg("Both Name and Surename cannot be empty!")
            return false;
        }
        if(!editedCaretaker.firstName) {
            setErrMsg("Name cannot be empty!")
            return false
        } else if(!editedCaretaker.lastName) {
            setErrMsg("Surename cannot be empty!")
            return false;
        } else {
            return true;
        }
    }
    return (
        <Modal show={toggleEditModal} onHide={handleModalHide} id="modal-edit-caretaker">
            <ModalHeader>
                Edit caretaker
            </ModalHeader>
            <ModalBody>
                <Form>
                    <Form.Group className="mb-3">
                            <Form.Label htmlFor='caretakerNameLabel' label="caretakerNameLabel">
                                Name
                            </Form.Label>
                            <Form.Control
                                id='caretakerNameLabel'
                                type="text"
                                placeholder='Name'
                                value={editedCaretaker.firstName}
                                onChange={(e) => setEditedCaretaker({ ...editedCaretaker, firstName : e.target.value})}
                            />
                    </Form.Group>
                    <Form.Group className="mb-3">
                            <Form.Label htmlFor='caretakerSurenameLabel'>
                                Surename
                            </Form.Label>
                            <Form.Control
                                id='caretakerSurenameLabel'
                                type="text"
                                placeholder='Name'
                                value={editedCaretaker.lastName}
                                onChange={(e) => setEditedCaretaker({ ...editedCaretaker, lastName : e.target.value})}
                            />
                    </Form.Group>
                    {
                        errMsg ? <div id="edit-Caretaker-errMsg">
                            { errMsg }
                        </div> : null
                    }
                    <Stack direction='horizontal' gap={2} className='justify-content-center' >
                        <Button onClick={handleSubmitEditCaretaker} id="editCaretakerSubmit">
                            Submit
                        </Button>
                        <Button onClick={handleModalHideAndClearData} variant='outline-primary'>
                            Cancel
                        </Button>
                    </Stack>
                </Form>
            </ModalBody>
        </Modal>
    )
}

export default CaretakerEditModal