import React, { useState } from 'react'
// import 'bootstrap/dist/css/bootstrap.min.css';
import { Form, FormGroup, Button, FloatingLabel, Container, Row, Col, Stack } from 'react-bootstrap'
import { initUser } from '../../util/util'
import { UserType } from '../../shared/lib/types';
import LoginGroup from '../../shared/component/formcomponent/login/LoginGroup'
import PasswordGroup from '../../shared/component/formcomponent/login/PasswordGroup'
import "./login.css"

const Login = () => {
    const [user ,setUser] = useState<UserType>(initUser);
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
        <div className="loginForm_master">
            <Container className='login_container'>
                <Form>
                    <Row className='mb-4'>
                        <Col className='col-md-6 mx-auto'>
                            <h1>Login</h1>
                        </Col>
                    </Row>
                    <Row className="mb-4">
                        <LoginGroup handleLoginChange={handleLoginChange} login={user.login}/>
                    </Row>
                    <Row className='mb-4'>
                        <PasswordGroup handlePasswordChange={handlePasswordChange} password={user.password}/>
                    </Row>
                    <Row>
                        <Stack direction='horizontal' gap={2} className='justify-content-center'>
                            <Button type="submit" onClick={handleOnUserLogin} className='ml-auto'>
                                Login
                            </Button>
                            <Button type="submit" onClick={handleOnAdminLogin}>
                                Register 
                            </Button>
                        </Stack>
                    </Row>
                </Form>
            </Container>
        </div>
    )
}

export default Login