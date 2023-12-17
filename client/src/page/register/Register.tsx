import { useState, useContext } from 'react'
import { Form, FormGroup, Button, FloatingLabel, Container, Row, Col, Stack } from 'react-bootstrap'
import { initUser } from '../../util/util'
import { UserType } from '../../shared/lib/types'
import LoginGroup from '../../shared/component/formcomponent/login/LoginGroup'
import PasswordGroup from '../../shared/component/formcomponent/login/PasswordGroup'
import EmailGroup from '../../shared/component/formcomponent/login/EmailGroup'
import "./register.css"
import useFetch from '../../hook/useFetch'
import usePost from '../../hook/usePost'
import { useNavigate } from 'react-router-dom'
import { AuthContext } from '../../context/AuthProvider'
import { UserTypeCnt } from '../../context/AuthProvider'
const Register = () => {
  const [user ,setUser] = useState<UserTypeCnt>(initUser);
  const [errMsg, setErrMsg] = useState<string>('');
  const { login ,logout, ...rest  } = useContext(AuthContext);
  const navigate = useNavigate();
  const [state,post] = usePost({ 
        url : '/user/register',
        body : user 
  });

  const handleEmailChange = (event : React.ChangeEvent<HTMLInputElement>) => {
    setUser({...user, email : event.target.value})
  }
  const handleLoginChange = (event : React.ChangeEvent<HTMLInputElement>) => {
      setUser({...user, username : event.target.value})
  }
  const handlePasswordChange = (event : React.ChangeEvent<HTMLInputElement>) => {
      setUser({...user, password : event.target.value});
  }
  const handleOnRegister = () => {
    const isValidated = validate()
    if(isValidated) {
        post()
            .then(() => {
                console.log(state)
                login(user);
            })
        navigate('/app')
    }
  }
  const validate = () => {
        if(user && user.email && user.password && user.username) {
            if(!user.email.includes("@")) {
                setErrMsg("Email must contain '@' !")
                return false
            }
            if(user.password.length <= 5) {
                setErrMsg("Password must contain at least 6 characters")
                return false;
            }
            return true;
        } else {
            setErrMsg("Values cannot be empty!")
            return false;
        }
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
                    <LoginGroup handleLoginChange={handleLoginChange} login={user.username!} id="login-register-input"/>
                </Row>
                <Row className='mb-4'>
                    <PasswordGroup handlePasswordChange={handlePasswordChange} password={user.password} id="password-register-input"/>
                </Row>
                {
                    errMsg != '' ? (
                        <div id='errMsg-Register'>
                        { errMsg }
                        </div>
                    ) : null
                }
                    <Stack direction='horizontal' gap={2} className='justify-content-center'>
                        <Button onClick={handleOnRegister} id="">
                            Register
                        </Button>
                    </Stack>
            </Form>
        </Container>
    </div>
      )
  }

export default Register