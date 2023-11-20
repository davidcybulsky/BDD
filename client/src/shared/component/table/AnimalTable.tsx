import React from 'react'
import { Table } from 'react-bootstrap'
import { Animal, AnimalTableType } from '../../lib/types'

const AnimalTable = ( { animalList } : AnimalTableType) => {
    return (
    <Table>
        <thead>
            <tr>
                <th>Id</th>
                <th>Name</th>
                <th>Specie</th>
                <th>Caretaker</th>
                <th>Enclosure</th>
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
                        </tr>
                    ))
                }

        </tbody>
    </Table>
    )
}

export default AnimalTable