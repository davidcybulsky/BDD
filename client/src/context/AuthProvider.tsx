import React, { ReactNode, useState, createContext } from 'react'

type AuthProviderPropsType = {
    children : ReactNode
}
type UserType = {
    id : string, 
    username : string,
    email : string,
    password : string,
    isAdmin : boolean
}
type ContextType = {
    user : UserType,
    login : (user : UserType) => void,
    logout : () => void
}

const initUser : UserType = {
    id : '',
    username : '',
    email : '',
    password : '',
    isAdmin : false
}

const AuthContext = createContext<ContextType>({
    user : initUser,
    login : () => undefined,
    logout : () => undefined
});

const AuthProvider = ({ children } : AuthProviderPropsType) => {
    const [user, setUser] = useState<UserType>(initUser);
    
    const login = (user : UserType) => {
        if(user != initUser) {
            localStorage.setItem('user', JSON.stringify(user));
            setUser(user);
        }
    }

    const logout = () => {
        localStorage.removeItem('user');
        setUser(initUser);
    }
    return (
        <AuthContext.Provider value= {{ user, login, logout }}>
            { children }
        </AuthContext.Provider>
    )
}

export default AuthProvider