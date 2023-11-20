import React, { useState } from 'react'
import 'bootstrap/dist/css/bootstrap.min.css';
import { Form, FormGroup, Button, FloatingLabel, Container, Row, Col } from 'react-bootstrap'
import { initUser } from '../../util/util'
import { UserType } from '../../shared/lib/types';
import LoginGroup from '../../shared/component/formcomponent/LoginGroup'
import PasswordGroup from '../../shared/component/formcomponent/PasswordGroup'
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
                            <text>Login</text>
                        </Col>
                    </Row>
                    <Row className="mb-4">
                        <LoginGroup handleLoginChange={handleLoginChange} login={user.login}/>
                    </Row>
                    <Row className='mb-4'>
                        <PasswordGroup handlePasswordChange={handlePasswordChange} password={user.password}/>
                    </Row>
                    <Row>
                        <Col>
                            <Button type="submit" onClick={handleOnUserLogin} className='ml-auto'>
                                Login
                            </Button>
                        </Col>
                        <Col>
                            <Button type="submit" onClick={handleOnAdminLogin}>
                                Login as Admin
                            </Button>
                        </Col>
                    </Row>
                </Form>
            </Container>
        </div>
    )
}

export default Login