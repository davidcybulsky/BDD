import { useState} from 'react'
import { Button } from 'react-bootstrap'
import { AnimalListType } from '../../shared/lib/types'
import AnimalTable from '../../shared/component/table/AnimalTable'
import { animalList } from '../../util/util'
import TicketModal from './ticketmodal/TicketModal'

const Home = () => {
    const animals = animalList;
    const [toggleBuyTicketModal, setToggleBuyTicketModal] = useState<boolean>(false);
    const handleBuyTicket = () => {
        setToggleBuyTicketModal(true);
    }
    return (
        <>
            <AnimalTable animalList={animals}/>
            <Button onClick={handleBuyTicket}>Buy ticket</Button>
            { 
                toggleBuyTicketModal && (
                    <TicketModal/>
                )

            }
        </>
    )
}

export default Home