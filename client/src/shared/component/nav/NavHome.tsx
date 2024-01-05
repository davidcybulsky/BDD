import React from 'react'
import { useContext } from "react";
import { NavLink, Nav, Navbar, Button } from 'react-bootstrap'
import { AuthContext } from '../../../context/AuthProvider';
import { useNavigate } from 'react-router-dom';

type NavHomeType = {
    handleOnDisplayChange :(navLink : string) => void,
    handleBuyTicket : () => void,
}

const NavHome = ({ handleOnDisplayChange, handleBuyTicket } : NavHomeType ) => {
    const  { logout } = useContext(AuthContext);
    const navigate = useNavigate();

    const handleOnLogout = () => {
        logout();
        navigate("/")
    }

    return (
        <Navbar bg='dark' data-bs-theme="dark">
            <Nav className='me-auto ms-5'>
                <NavLink id="nav-animal" onClick={() => {handleOnDisplayChange('animal')}}>Animal</NavLink>
                <NavLink id="nav-caretaker" onClick={() => {handleOnDisplayChange('caretaker')}}>Caretaker</NavLink>
            </Nav>
            <Button onClick={handleBuyTicket} className='me-3' id="buyticker-btn">
                Buy ticket
            </Button>
            <Button onClick={handleOnLogout} className='me-5' id='logout-btn'>
                Logout
            </Button>
            
        </Navbar>
    )
}

export default NavHome