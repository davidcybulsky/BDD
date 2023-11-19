import { useState } from 'react'
import { Form, FormGroup, Button, FloatingLabel, Container, Row, Col } from 'react-bootstrap'
import { initUser } from '../../util/userUtil'
import { User } from '../../util/userUtil'
import LoginGroup from '../../component/LoginGroup'
import PasswordGroup from '../../component/PasswordGroup'
import EmailGroup from '../../component/EmailGroup'

const Register = () => {
  const [user ,setUser] = useState<User>(initUser);
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
      <Container className='container-md mt-5'>
          <Form>
              <Row className="mb-4">
                <EmailGroup handleEmailChange={handleEmailChange} email={user.email}/>
              </Row>
              <Row className="mb-4">
                  <LoginGroup handleLoginChange={handleLoginChange} login={user.login}/>
              </Row>
              <Row className='mb-4'>
                  <PasswordGroup handlePasswordChange={handlePasswordChange} password={user.password}/>
              </Row>
              <Row>
                  <Col>
                      <Button type="submit" onClick={handleOnUserLogin}>
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
      )
  }

export default Register