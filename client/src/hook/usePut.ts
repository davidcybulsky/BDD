import React, { useReducer } from 'react'
import axios from '../api/axios'
type usePostType = {
    url : string, 
    body : any 
}
const initState = {
    onLoading : false,
    isSuccesful : false,
    error : ""
}
const ACTIONS = {
    API_REQUEST: "api_request",
    PUT_DATA: "put_data",
    ERROR: "error"
}

const reducer = (state : any, action : any) => {
    switch(action.type) {
        case(ACTIONS.API_REQUEST): {
            return { ...state, onLoading : false};
        }
        case(ACTIONS.PUT_DATA): {
            return { ...state, isSuccesful : true};
        }
        case(ACTIONS.ERROR): {
            return { ...state, error : action.payload };
            }
        default:
            return state;
    }
}


const usePut = ({ url , body} : usePostType) => {
    const [state,dispatch] = useReducer( reducer, initState);
    const putData = async () => {
        dispatch({ type: ACTIONS.API_REQUEST })
        await axios.put(url,body)
            .then((res) => {
                dispatch({ type: ACTIONS.PUT_DATA })
            })
            .catch((err) => {
                dispatch({ type: ACTIONS.ERROR })
            })
    }
    return [state,putData];
}
export default usePut