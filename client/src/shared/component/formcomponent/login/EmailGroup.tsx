import React from 'react'
import { Form, FloatingLabel, FormGroup } from 'react-bootstrap'

type EmailGroupType = {
    email : string | undefined, 
    handleEmailChange : (event : React.ChangeEvent<HTMLInputElement>) => void
}

const EmailGroup = ({ handleEmailChange, email } : EmailGroupType) => {
    return (
        <FormGroup className='col-md-6 mx-auto'>
            <FloatingLabel
                controlId='emailLabel'
                label='email'
            >
                <Form.Control
                    id='emailLabel'
                    type="email"
                    placeholder='Email'
                    value={email}
                    onChange={handleEmailChange}
                    // style={{ maxWidth: "500px"}}
                />
            </FloatingLabel>
        </FormGroup>
    )
}

export default EmailGroup