import React from 'react'
import { NavLink, Nav, Navbar, Button } from 'react-bootstrap'

type NavHomeType = {
    handleOnDisplayChange :(navLink : string) => void
}

const NavHome = ({ handleOnDisplayChange } : NavHomeType ) => {

    const logout = () => {

    }

    return (
        <Navbar bg='dark' data-bs-theme="dark">
            <Nav className='me-auto ms-5'>
                <NavLink onClick={() => {handleOnDisplayChange('animal')}}>Animal</NavLink>
                <NavLink onClick={() => {handleOnDisplayChange('caretaker')}}>Caretaker</NavLink>
            </Nav>
            <Button onClick={logout} className='me-5'>
                Logout
            </Button>
        </Navbar>
    )
}

export default NavHome