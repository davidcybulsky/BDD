import React from 'react'
import { Form, FormGroup, Button, FloatingLabel, Container, Row, Col } from 'react-bootstrap'

type LoginGroupType = {
    login : string, 
    handleLoginChange :  (event : React.ChangeEvent<HTMLInputElement>) => void  
}

const LoginGroup = ({ login, handleLoginChange} : LoginGroupType) => {


    return (
        <FormGroup className='col-md-6 mx-auto'>
            <FloatingLabel
                controlId='loginLabel'
                label='login'
            >
                <Form.Control 
                    id="loginLabel"
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