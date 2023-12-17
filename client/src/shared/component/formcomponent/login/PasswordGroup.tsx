import React from 'react'
import { Form, FloatingLabel } from 'react-bootstrap'

type PasswordGroupType = {
    password : string,
    handlePasswordChange : (event : React.ChangeEvent<HTMLInputElement>) => void,
    id : string
}

const PasswordGroup = ({ password, handlePasswordChange, id} : PasswordGroupType) => {
  return (
    <Form.Group className='col-md-6 mx-auto'>
        <FloatingLabel
            label='password'
        >
            <Form.Control 
                 id={id}
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