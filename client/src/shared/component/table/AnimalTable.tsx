import { useState, useRef }  from 'react'
import { Button, Table } from 'react-bootstrap'
import { Animal, AnimalTableType } from '../../lib/types'
import AnimalEditModal from '../modal/AnimalEditModal';
import { initAnimal } from '../../../util/util';

const AnimalTable = ( { animalList, isAdmin } : AnimalTableType) => {
    const [toggleEditModal, setEditModal] = useState<boolean>(false);
    const [editAnimal, setEditAnimal] = useState<Animal>(initAnimal);

    const handleAnimalOnEdit = (animal : Animal) => {
        setEditModal(true);
        setEditAnimal(animal);
    }
    const handleAnimalOnDelete = (animal : Animal) => {
        //strzal do backa DELETE
    }

    return (
    <>
        <Table>
            <thead>
                <tr>
                    <th>Id</th>
                    <th>Name</th>
                    <th>Specie</th>
                    <th>Caretaker</th>
                    <th>Enclosure</th>
                    {
                        isAdmin && (
                            <>
                                <th>
                                    Edit
                                </th>
                                <th>
                                    Delete
                                </th>
                            </>
                        )
                    }
                </tr>
            </thead>
            <tbody>
                    {
                        animalList.map((animal : Animal, index : number) => (
                            <tr key={index}>
                                {
                                    (Object.keys(animal) as Array<keyof Animal>).map((key : keyof Animal) => (
                                        <>
                                            <td key={key + animal.id}>{animal[key]}</td>
        
                                        </>
                                    ))
                                }
                                {
                                isAdmin && (
                                    <>
                                        <td>
                                            <Button onClick={() => handleAnimalOnEdit(animal)}>
                                                Edit
                                            </Button>
                                        </td>
                                        <td>
                                            <Button onClick={() => handleAnimalOnDelete(animal)}>
                                                Delete
                                            </Button>
                                        </td>
                                    </>
                                    )
                                }
                            </tr>
                        ))
                    }

            </tbody>
        </Table>
        <AnimalEditModal toggleEditModal={toggleEditModal} handleModalHide={() => setEditModal(false)} animal={editAnimal}/>
    </>
    )
}

export default AnimalTable