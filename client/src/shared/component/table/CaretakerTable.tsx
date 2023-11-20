import React from 'react'
import { Table, Button } from "react-bootstrap";
import { CaretakerListType, CaretakerType } from '../../lib/types';

type CaretakerTableType = {
    caretakerList : CaretakerListType
}

const CaretakerTable = ({ caretakerList } : CaretakerTableType) => {

    const handleCaretakerOnEdit = (caretaker : CaretakerType) => {

    }
    const handleCaretakerOnDelete = (caretaker : CaretakerType) => {
        
    }
    return (
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
    )
}

export default CaretakerTable