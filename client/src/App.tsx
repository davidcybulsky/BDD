import 'bootstrap/dist/css/bootstrap.min.css'
import Register from './page/register/Register';
import { Container } from 'react-bootstrap';
import Home from './page/home/Home';
import Login from './page/login/Login';
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
