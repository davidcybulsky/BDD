import React from 'react'
import { useState } from 'react';
import { Table, Button } from "react-bootstrap";
import { CaretakerListType, CaretakerType } from '../../lib/types';
import CaretakerEditModal from '../modal/CaretakerEditModal';
import { initCaretaker, initCaretakerList } from '../../../util/util';

type CaretakerTableType = {
    caretakerList : CaretakerListType
}

const CaretakerTable = () => {
    // const { data , loading, error } = useFetch("/test");
    const [editedCaretaker, setEditedCaretaker] = useState<CaretakerType>(initCaretaker);
    const [toggleEditModal, setEditModal] = useState<boolean>(false);
    const [caretakerList, setCaretakerList] = useState(initCaretakerList);

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
                    <th>Name</th>
                    <th>Surename</th>
                    <th>Edit</th>
                    <th>Delete</th>
                </tr>
            </thead>
            <tbody>
                {
                    caretakerList.map((caretaker : any, index : any) => (
                        <tr>
                            {
                                (Object.keys(caretaker) as Array<keyof any>).map((key : any) => (
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