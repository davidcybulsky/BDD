import { useState} from 'react'
import { Button } from 'react-bootstrap'
import { AnimalListType } from '../../shared/lib/types'
import AnimalTable from '../../shared/component/table/AnimalTable'
import { animalList, caretakers } from '../../util/util'
import TicketModal from '../../shared/component/modal/TicketModal'
import CaretakerTable from '../../shared/component/table/CaretakerTable'
import NavHome from '../../shared/component/nav/NavHome'

const Home = () => {
    const caretakerList = caretakers; 
    const [toggleModal, setToggleModal] = useState<boolean>(false);
    const [onDisplayChange, setOnDisplayChange] = useState<string>('animal');

    const handleBuyTicket = () => {
        setToggleModal(true);
    }
    const handleOnDisplayChange = (navLink : string) => {
        setOnDisplayChange(navLink);
    }

    const displayTable =          
        onDisplayChange === 'animal' ? (
        <AnimalTable isAdmin={true}/> 
        ) :  (
            onDisplayChange === 'caretaker' ? (
                <CaretakerTable caretakerList={caretakerList}/>
            ) : (
                <>
                </>
            )
    );

    return (
        <>
            <NavHome handleOnDisplayChange={handleOnDisplayChange}/>
            { displayTable }
            <Button onClick={handleBuyTicket}>Buy ticket</Button>
            <TicketModal toggleModal={toggleModal} handleModalHide={() => setToggleModal(false)}/>
        </>
    )
}

export default Home