import React, { useState, useContext } from 'react'
// import 'bootstrap/dist/css/bootstrap.min.css';
import { Form, FormGroup, Button, FloatingLabel, Container, Row, Col, Stack } from 'react-bootstrap'
import { initUser } from '../../util/util'
import { UserType } from '../../shared/lib/types';
import LoginGroup from '../../shared/component/formcomponent/login/LoginGroup'
import PasswordGroup from '../../shared/component/formcomponent/login/PasswordGroup'
import "./login.css"
import { useNavigate } from 'react-router-dom';
import usePost from '../../hook/usePost';
import { AuthContext } from '../../context/AuthProvider';
import { UserTypeCnt } from '../../context/AuthProvider';

const initUserLogin = {
    email : '',
    username : '',
    password : ''
} 

const Login = () => {
    const [userLogin ,setUserLogin] = useState<UserTypeCnt>(initUserLogin);
    const { login } = useContext(AuthContext);
    const [state, post] = usePost({
        url : "/user/login",
        body : userLogin
    });
    const navigate = useNavigate();
    const handleLoginChange = (event : React.ChangeEvent<HTMLInputElement>) => {
        setUserLogin({...userLogin, username : event.target.value})
    }
    const handlePasswordChange = (event : React.ChangeEvent<HTMLInputElement>) => {
        setUserLogin({...userLogin, password : event.target.value});
    }
    const handleOnUserLogin = () => {
        post()
            .then(() => {
                login(userLogin);
                navigate('/app')
            })
    }
    const handleOnRegister = () => {
        navigate('/register')
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
                        <LoginGroup handleLoginChange={handleLoginChange} login={userLogin.username}/>
                    </Row>
                    <Row className='mb-4'>
                        <PasswordGroup handlePasswordChange={handlePasswordChange} password={userLogin.password}/>
                    </Row>
                    <Row>
                        <Stack direction='horizontal' gap={2} className='justify-content-center'>
                            <Button  onClick={handleOnUserLogin} className='ml-auto'>
                                Login
                            </Button>
                            <Button  onClick={handleOnRegister}>
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