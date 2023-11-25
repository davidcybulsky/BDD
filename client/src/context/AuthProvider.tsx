import React, { ReactNode, useState, createContext } from 'react'
type AuthProviderPropsType = {
    children : ReactNode
}

type ContextType = {
    user : UserTypeCnt,
    login : (user : UserTypeCnt) => void,
    logout : () => void
}
export type UserTypeCnt = {
    username? : string | undefined,
    email : string,
    password : string 
}

const initUser : UserTypeCnt = {
    username : '',
    email : '',
    password : ''
}

export const AuthContext = createContext<ContextType>({
    user : initUser,
    login : () => undefined,
    logout : () => undefined
});

const AuthProvider = ({ children } : AuthProviderPropsType) => {
    const [user, setUser] = useState<UserTypeCnt>(initUser);
    
    const login = (user : UserTypeCnt) => {
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