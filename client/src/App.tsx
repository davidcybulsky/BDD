// import 'bootstrap/dist/css/bootstrap.min.css'
import { Container } from 'react-bootstrap';
import { Button } from 'react-bootstrap';
import Home from './page/home/Home';
import axios from './api/axios';
// import "bootstrap/dist/css/bootstrap.min.css";
function App() {


  return (
    <Container>
      {/* <Login/> */}
      {/* <Register/> */}
      <Home/>
    </Container>
  )
}

export default App;
