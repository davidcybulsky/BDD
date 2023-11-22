// import 'bootstrap/dist/css/bootstrap.min.css'
import { Container } from 'react-bootstrap';
import { Button } from 'react-bootstrap';
import Home from './page/home/Home';
import Register from './page/register/Register';
import axios from './api/axios';
import Login from './page/login/Login';
import { RouterProvider, createBrowserRouter } from "react-router-dom"
import AnimalTable from './shared/component/table/AnimalTable';

function App() {

  const routes = createBrowserRouter([
    {
      path: "/login",
      element:  (
        <Login/>
      )
    },
    {
      path: "/register",
      element:  (
        <Register/>
      )
    },
    {
      path: "/",
      element : (
        <Home/>
      )
    }

  ])

  return (
    <RouterProvider router={routes}/>
  )
}

export default App;
