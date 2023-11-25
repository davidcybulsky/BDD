import { useState, useEffect }  from 'react'
import { Button, Table, Spinner } from 'react-bootstrap'
import { Animal, AnimalListType } from '../../lib/types'
import AnimalEditModal from '../modal/AnimalEditModal';
import { initAnimal, initAnimalList } from '../../../util/util';
import useFetch from '../../../hook/useFetch';
import useDelete from '../../../hook/useDelete';
import { dataAnimalConvert, dataEnclosureConvert } from '../../../util/util';
type AnimalTableType = {
    // animalList : AnimalListType,
    isAdmin : boolean
}

const AnimalTable = ( { isAdmin } : AnimalTableType) => {
    const [stateAnimal, fetchAnimal] = useFetch("/animal");
    const [animalIdToDelete, setAnimalIdToDelete] = useState<string>('');
    const [_ , deleteData] = useDelete(`/animal/${animalIdToDelete}`)
    const [animalList, setAnimalList] = useState<AnimalListType>(initAnimalList);
    const [toggleEditModal, setEditModal] = useState<boolean>(false);
    const [editAnimal, setEditAnimal] = useState<Animal>(initAnimal);
    const [reFetch, setReFetch] = useState(false);

    useEffect(() => {
        fetchAnimal()
    },[reFetch])

    useEffect(() => {
        if(stateAnimal.data) {
            const convertedAnimal = convertEnclosureFromNumberToString(stateAnimal.data)
            setAnimalList(convertSpeciesFromNumberToString(convertedAnimal))
        }
    },[stateAnimal])

    const handleAnimalOnEdit = (animal : Animal) => {
        setEditAnimal(animal);
        setEditModal(true);
    }
    const handleAnimalOnDelete = (animal : Animal) => {
        deleteData(`/animal/${animal.id}`);
        triggerReFetching();
    }
    const convertSpeciesFromNumberToString = (animals : AnimalListType) => {
        const animalToConvert = [...animals];
        const convertedAnimal = animalToConvert.map((animal : Animal) => {
            animal.species = dataAnimalConvert[animal.species];
            return animal
        })
        return convertedAnimal;
    }
    const convertEnclosureFromNumberToString = (animals : AnimalListType) => {
        const animalToConvert = [...animals];
        const convertedAnimal = animalToConvert.map((animal : Animal) => {
            animal.enclosure = dataEnclosureConvert[animal.enclosure];
            return animal
        })
        return convertedAnimal;
    }
    const triggerReFetching = () => {
        setTimeout(() => {
            setReFetch(!reFetch);
        },1)
    }
    return (
    <>
        <Table>
            <thead>
                <tr>
                    <th>Name</th>
                    <th>Species</th>
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
                                            {
                                                key !== 'id' ? key !== "dateOfBirth" ? 
                                                key !== "caretakerId" ? <td>{animal[key]}</td> 
                                                : null : null : null
                                            }
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
            triggerReFetching={triggerReFetching}
        />
    </>
    )
}

export default AnimalTable