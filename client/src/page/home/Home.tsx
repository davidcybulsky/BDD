import { useState} from 'react'
import { Button } from 'react-bootstrap'
import { AnimalListType } from '../../shared/lib/types'
import AnimalTable from '../../shared/component/table/AnimalTable'
import { animalList, caretakers } from '../../util/util'
import TicketModal from '../../shared/component/modal/TicketModal'
import CaretakerTable from '../../shared/component/table/CaretakerTable'
import NavHome from '../../shared/component/nav/NavHome'

const Home = () => {
    const animals = animalList;
    const caretakerList = caretakers; 
    const [toggleModal, setToggleModal] = useState<boolean>(false);
    const handleBuyTicket = () => {
        setToggleModal(true);
    }
    return (
        <>
            <NavHome/>
            <CaretakerTable caretakerList={caretakerList}/>
            {/* <AnimalTable animalList={animals} isAdmin={true}/> */}
            <Button onClick={handleBuyTicket}>Buy ticket</Button>
            <TicketModal toggleModal={toggleModal} handleModalHide={() => setToggleModal(false)}/>
        </>
    )
}

export default Home