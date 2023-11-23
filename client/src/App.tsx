import Home from './page/home/Home';
import Register from './page/register/Register';
import Login from './page/login/Login';
import { RouterProvider, createBrowserRouter } from "react-router-dom"
import AuthProvider from './context/AuthProvider';

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
    <AuthProvider>
      <RouterProvider router={routes}/>
    </AuthProvider>
  )
}

export default App;
