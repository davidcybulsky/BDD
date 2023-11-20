import { useState} from 'react'
import { Button } from 'react-bootstrap'
import { AnimalListType } from '../../shared/lib/types'
import AnimalTable from '../../shared/component/table/AnimalTable'
import { animalList } from '../../util/util'
import TicketModal from './ticketmodal/TicketModal'

const Home = () => {
    const animals = animalList;
    const [toggleModal, setToggleModal] = useState<boolean>(false);
    const handleBuyTicket = () => {
        setToggleModal(true);
    }
    return (
        <>
            <AnimalTable animalList={animals} isAdmin={true}/>
            <Button onClick={handleBuyTicket}>Buy ticket</Button>
            <TicketModal toggleModal={toggleModal} handleModalHide={() => setToggleModal(false)}/>
        </>
    )
}

export default Home