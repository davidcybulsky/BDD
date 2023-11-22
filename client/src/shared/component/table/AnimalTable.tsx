import { useState, useEffect }  from 'react'
import { Button, Table } from 'react-bootstrap'
import { Animal } from '../../lib/types'
import AnimalEditModal from '../modal/AnimalEditModal';
import { initAnimal } from '../../../util/util';
import { animalList } from '../../../util/util';
import useFetch from '../../../hook/useFetch';
type AnimalTableType = {
    // animalList : AnimalListType,
    isAdmin : boolean
}
const AnimalTable = ( { isAdmin } : AnimalTableType) => {
    const animals = animalList;
    const [state, fetch] = useFetch("/test");
    // const [animalList, setAnimalList] = useState<Animal>(initAnimal);
    const [toggleEditModal, setEditModal] = useState<boolean>(false);
    const [editAnimal, setEditAnimal] = useState<Animal>(initAnimal);
    const [checker, setChecker] = useState<string>("siema");

    useEffect(() => {
        const getData = async () => {
            const res = await fetch();
        }
        getData()
    },[])
    useEffect(() => {
        if(state.data) {
            setChecker(state.data);
        }
    },[state])

    const handleAnimalOnEdit = (animal : Animal) => {
        setEditAnimal(animal);
        setEditModal(true);
    }
    const handleAnimalOnDelete = (animal : Animal) => {
        //strzal do backa DELETE
    }

    return (
    <>
        { checker }
        <Table>
            <thead>
                <tr>
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
        <AnimalEditModal 
            toggleEditModal={toggleEditModal}
            handleModalHide={() => setEditModal(false)}
            animal={editAnimal}
        />
    </>
    )
}

export default AnimalTable