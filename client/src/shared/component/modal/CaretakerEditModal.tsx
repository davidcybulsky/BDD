import React, { useEffect, useState } from 'react'
import { Modal, ModalBody, ModalHeader, Form, Stack, Button } from 'react-bootstrap'
import { CaretakerType } from '../../lib/types'
import { initCaretaker } from '../../../util/util'

type CaretakerEditModalType = {
    toggleEditModal : boolean,
    handleModalHide : () => void,
    caretaker : CaretakerType
}

const CaretakerEditModal = ({ toggleEditModal, handleModalHide, caretaker} : CaretakerEditModalType) => {
    const [editedCaretaker, setEditedCaretaker] = useState<CaretakerType>(initCaretaker);

    useEffect(() => {
        setEditedCaretaker(caretaker);
    },[caretaker])

    const handleSubmitEditCaretaker = () => {
        
    }
    const handleModalHideAndClearData = () => {
        setEditedCaretaker(initCaretaker);
        handleModalHide()
    }
    return (
        <Modal show={toggleEditModal} onHide={handleModalHide}>
            <ModalHeader>
                Edit caretaker
            </ModalHeader>
            <ModalBody>
                <Form>
                    <Form.Group className="mb-3">
                            <Form.Label htmlFor='caretakerNameLabel'>
                                Name
                            </Form.Label>
                            <Form.Control
                                id='caretakerNameLabel'
                                type="text"
                                placeholder='Name'
                                value={caretaker.name}
                                onChange={(e) => setEditedCaretaker({ ...editedCaretaker, name : e.target.value})}
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
                                value={caretaker.surename}
                                onChange={(e) => setEditedCaretaker({ ...editedCaretaker, surename : e.target.value})}
                            />
                    </Form.Group>
                    <Stack direction='horizontal' gap={2} className='justify-content-center'>
                        <Button type='submit' onClick={handleSubmitEditCaretaker}>
                            Submit
                        </Button>
                        <Button onClick={handleModalHideAndClearData}>
                            Cancel
                        </Button>
                    </Stack>
                </Form>
            </ModalBody>
        </Modal>
    )
}

export default CaretakerEditModal