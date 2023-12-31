import Home from './page/home/Home';
import Register from './page/register/Register';
import Login from './page/login/Login';
import { RouterProvider, createBrowserRouter } from "react-router-dom"
import AuthProvider from './context/AuthProvider';
import CaretakerTable from './shared/component/table/CaretakerTable';

function App() {

  const routes = createBrowserRouter([
    {
      path: "/",
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
      path: "/app",
      element : (
        <Home/>
      )
    }
    // {
    //   path: "/caretaker",
    //   element : (
    //     <CaretakerTable/>
    //   )
    // }

  ])

  return (
    <AuthProvider>
      <RouterProvider router={routes}/>
    </AuthProvider>
  )
}

export default App;
