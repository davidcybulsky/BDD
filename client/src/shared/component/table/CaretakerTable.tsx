import { useState, useEffect } from 'react';
import { Table, Button } from "react-bootstrap";
import { CaretakerListType, CaretakerType } from '../../lib/types';
import CaretakerEditModal from '../modal/CaretakerEditModal';
import { initCaretaker, initCaretakerList } from '../../../util/util';
import useFetch from '../../../hook/useFetch';
import useDelete from '../../../hook/useDelete';

type CaretakerTableType = {
    caretakerList : CaretakerListType
}

const CaretakerTable = () => {
    const [editedCaretaker, setEditedCaretaker] = useState<CaretakerType>(initCaretaker);
    const [toggleEditModal, setEditModal] = useState<boolean>(false);
    const [caretakerList, setCaretakerList] = useState(initCaretakerList);
    const [state, fetch] = useFetch('/caretaker');
    const [reFetch, setReFetch] = useState<boolean>(false);
    const [_, deleteData] = useDelete(`/caretaker/1`);

    useEffect(() => {
        fetch()
    },[reFetch])

    useEffect(() => {
        if(state.data) {
            const caretakers = state.data;
            caretakers.forEach((caretaker : any) => {
                delete caretaker.animals;
            })
            setCaretakerList(caretakers)
        }  
    },[state])

    const handleCaretakerOnEdit = (caretaker : CaretakerType) => {
        setEditedCaretaker(caretaker)
        setEditModal(true)
    }
    const handleCaretakerOnDelete = (caretaker : CaretakerType) => {
        deleteData(`/caretaker/${caretaker.id}`)
        triggerReFetch()
    }
    const handleModalHide = () => {
        setEditModal(false)
    }
    const triggerReFetch = () => {
        setTimeout(() => {
            setReFetch(!reFetch);
        },0)
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
                    caretakerList.map((caretaker : CaretakerType, index : number) => (
                        <tr>
                            {
                                (Object.keys(caretaker) as Array<keyof CaretakerType>).map((key : keyof CaretakerType) => (
                                    <>
                                        { key !== "id" ?  <td key={key + index}>{caretaker[key]}</td> : null }
                                    </>
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
            caretaker={editedCaretaker}
            triggerReFetch={triggerReFetch}
        />
        </>
    )
}

export default CaretakerTable