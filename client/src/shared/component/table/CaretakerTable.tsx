import React from 'react'
import { useState } from 'react';
import { Table, Button } from "react-bootstrap";
import { CaretakerListType, CaretakerType } from '../../lib/types';
import CaretakerEditModal from '../modal/CaretakerEditModal';
import { initCaretaker } from '../../../util/util';

type CaretakerTableType = {
    caretakerList : CaretakerListType
}

const CaretakerTable = ({ caretakerList } : CaretakerTableType) => {
    const [editedCaretaker, setEditedCaretaker] = useState<CaretakerType>(initCaretaker);
    const [toggleEditModal, setEditModal] = useState<boolean>(false);

    const handleCaretakerOnEdit = (caretaker : CaretakerType) => {
        setEditedCaretaker(caretaker)
        setEditModal(true)
    }
    const handleCaretakerOnDelete = (caretaker : CaretakerType) => {
        
    }
    const handleModalHide = () => {
        setEditModal(false)
    }
    return (
        <>
        <Table>
            <thead>
                <tr>
                    <td>id</td>
                    <td>name</td>
                    <td>surename</td>
                    <td>edit</td>
                    <td>delete</td>
                </tr>
            </thead>
            <tbody>
                {
                    caretakerList.map((caretaker, index) => (
                        <tr>
                            {
                                (Object.keys(caretaker) as Array<keyof CaretakerType>).map((key : keyof CaretakerType) => (
                                    <td key={key}>{caretaker[key]}</td>
                                ))
                            }
                            {
                                <>
                                    <td>
                                        <Button onClick={() => handleCaretakerOnEdit(caretaker)}>
                                            Edit
                                        </Button>
                                    </td>
                                    <td>
                                        <Button onClick={() => handleCaretakerOnDelete(caretaker)}>
                                            Delete
                                        </Button>
                                    </td>
                                </>
                            }
                        </tr>
                    ))
                }
            </tbody>
        </Table>
        <CaretakerEditModal 
            toggleEditModal={toggleEditModal}
            handleModalHide={handleModalHide}
            caretaker={editedCaretaker}/>
        </>
    )
}

export default CaretakerTable