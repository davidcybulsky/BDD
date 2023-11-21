import React from 'react'
import { NavLink, Nav, Navbar, NavbarBrand } from 'react-bootstrap'

const NavHome = () => {
    return (
        <Navbar bg='dark' data-bs-theme="dark">
            <Nav className='me-auto'>
                <NavLink href='#animal'>Animal</NavLink>
                <NavLink href='#caretaker'>Caretaker</NavLink>
            </Nav>
        </Navbar>
    )
}

export default NavHome