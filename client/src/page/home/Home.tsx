import { useState, useContext, useEffect } from 'react'
import { Button } from 'react-bootstrap'
import { AnimalListType } from '../../shared/lib/types'
import AnimalTable from '../../shared/component/table/AnimalTable'
import TicketModal from '../../shared/component/modal/TicketModal'
import CaretakerTable from '../../shared/component/table/CaretakerTable'
import NavHome from '../../shared/component/nav/NavHome'
import { AuthContext } from '../../context/AuthProvider'

const Home = () => {
    const [toggleModal, setToggleModal] = useState<boolean>(false);
    const [onDisplayChange, setOnDisplayChange] = useState<string>('animal');
    const { user }  = useContext(AuthContext);
    const [isLoggedIn, setIsLoggedIn] = useState<boolean>(false);

    useEffect(() => {
        if(user.username && user.password) {
            setIsLoggedIn(true);
        }
    },[user])
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
                <CaretakerTable/>
            ) : (
                <>
                </>
            )
    );

    return (
        <>
            {
                isLoggedIn ? (
                    <>
                        <NavHome handleOnDisplayChange={handleOnDisplayChange} handleBuyTicket={handleBuyTicket}/>
                        { displayTable }
                        <TicketModal toggleModal={toggleModal} handleModalHide={() => setToggleModal(false)}/>
                    </>
                ) : 
                <div>
                    Unauthorized!
                </div>
            }
          
        </>
    )
}

export default Home