import React, { useReducer } from 'react'
import axios from '../api/axios'
type usePostType = {
    url : string 
}
const initState = {
    onLoading : false,
    isSuccesful : false,
    error : ""
}
const ACTIONS = {
    API_REQUEST: "api_request",
    DELETE_DATA: "delete_data",
    ERROR: "error"
}

const reducer = (state : any, action : any) => {
    switch(action.type) {
        case(ACTIONS.API_REQUEST): {
            return { ...state, onLoading : false};
        }
        case(ACTIONS.DELETE_DATA): {
            return { ...state, isSuccesful : true};
        }
        case(ACTIONS.ERROR): {
            return { ...state, error : action.payload };
            }
        default:
            return state;
    }
}


const useDelete = ( url  : string) => {
    const [state,dispatch] = useReducer( reducer, initState);
    const deleteData = async (url2 : string) => {
        console.log(url2);
        dispatch({ type: ACTIONS.API_REQUEST })
        await axios.delete(url2)
            .then((res) => {
                dispatch({ type: ACTIONS.DELETE_DATA })
            })
            .catch((err) => {
                dispatch({ type: ACTIONS.ERROR })
            })
    }
    return [state,deleteData];
}
export default useDelete