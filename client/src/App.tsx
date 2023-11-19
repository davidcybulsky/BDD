import React from 'react';
import 'bootstrap/dist/css/bootstrap.min.css'
import Login from './page/login/Login';
import Register from './page/register/Register';
import { Container } from 'react-bootstrap';
function App() {


  return (
    <Container>
      <Login/>
      {/* <Register/> */}
    </Container>
  )
}

export default App;
