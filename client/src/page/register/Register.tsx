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
    post()
        .then(() => {
            console.log(state)
            login(user);
        })
    navigate('/app')
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
                    <LoginGroup handleLoginChange={handleLoginChange} login={user.username!}/>
                </Row>
                <Row className='mb-4'>
                    <PasswordGroup handlePasswordChange={handlePasswordChange} password={user.password}/>
                </Row>
                    <Stack direction='horizontal' gap={2} className='justify-content-center'>
                        <Button onClick={handleOnRegister}>
                            Register
                        </Button>
                    </Stack>
            </Form>
        </Container>
    </div>
      )
  }

export default Register