import React from 'react'
import { Form, FormGroup, Button, FloatingLabel, Container, Row, Col } from 'react-bootstrap'

type LoginGroupType = {
    login : string | undefined, 
    handleLoginChange :  (event : React.ChangeEvent<HTMLInputElement>) => void,
    id : string
}

const LoginGroup = ({ login, handleLoginChange, id} : LoginGroupType) => {


    return (
        <FormGroup className='col-md-6 mx-auto'>
            <FloatingLabel
                label='login'
            >
                <Form.Control 
                     id={id}
                    type="text"
                    placeholder='Enter login'
                    value={login}
                    onChange={handleLoginChange}
                />
            </FloatingLabel>
        </FormGroup>
    )
}

export default LoginGroup