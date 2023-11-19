export type User = {
    email? : string | undefined,
    login : string,
    password : string
}

export const initUser : User= {
    email : '',
    login : '',
    password: ''
}