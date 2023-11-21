import { useState } from 'react'
import { Form, FormGroup, Button, FloatingLabel, Container, Row, Col, Stack } from 'react-bootstrap'
import { initUser } from '../../util/util'
import { UserType } from '../../shared/lib/types'
import LoginGroup from '../../shared/component/formcomponent/login/LoginGroup'
import PasswordGroup from '../../shared/component/formcomponent/login/PasswordGroup'
import EmailGroup from '../../shared/component/formcomponent/login/EmailGroup'
import "./register.css"

const Register = () => {
  const [user ,setUser] = useState<UserType>(initUser);
  const handleEmailChange = (event : React.ChangeEvent<HTMLInputElement>) => {
    setUser({...user, email : event.target.value})
  }
  const handleLoginChange = (event : React.ChangeEvent<HTMLInputElement>) => {
      setUser({...user, login : event.target.value})
  }
  const handlePasswordChange = (event : React.ChangeEvent<HTMLInputElement>) => {
      setUser({...user, password : event.target.value});
  }
  const handleOnUserLogin = () => {

  }
  const handleOnAdminLogin = () => {

  }
  return (
    <div className='registerForm_master'>
        <Container className='register_container'>
            <Form>
                <Row className='mb-4'>
                    <Col className='col-md-6 mx-auto'>
                        <h1>Register</h1>
                    </Col>
                </Row>
                <Row className="mb-4">
                    <EmailGroup handleEmailChange={handleEmailChange} email={user.email}/>
                </Row>
                <Row className="mb-4">
                    <LoginGroup handleLoginChange={handleLoginChange} login={user.login}/>
                </Row>
                <Row className='mb-4'>
                    <PasswordGroup handlePasswordChange={handlePasswordChange} password={user.password}/>
                </Row>
                    <Stack direction='horizontal' gap={2} className='justify-content-center'>
                        <Button type="submit" onClick={handleOnUserLogin}>
                            Register
                        </Button>
                    </Stack>
            </Form>
        </Container>
    </div>
      )
  }

export default Register