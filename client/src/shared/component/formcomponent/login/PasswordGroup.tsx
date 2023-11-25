import React from 'react'
import { Form, FloatingLabel } from 'react-bootstrap'

type PasswordGroupType = {
    password : string,
    handlePasswordChange : (event : React.ChangeEvent<HTMLInputElement>) => void
}

const PasswordGroup = ({ password, handlePasswordChange} : PasswordGroupType) => {
  return (
    <Form.Group className='col-md-6 mx-auto'>
        <FloatingLabel
            label='password'
        >
            <Form.Control 
                id='passwordLabel'
                type='password' 
                placeholder='password' 
                value={password} 
                onChange={handlePasswordChange}
                // style={{ maxWidth: "500px"}}
            />
        </FloatingLabel>
    </Form.Group> 
  )
}

export default PasswordGroup