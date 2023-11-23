import React, { useEffect, useReducer } from 'react'
import axios from '../api/axios'
// type useFetchType = {
//     url : string
// }

const ACTIONS = {
    API_REQUEST: "api_request",
    FETCH_DATA: "fetch_data",
    ERROR: "error"
}

type initStateType = {
    onLoading : boolean,
    data : any,
    error : any
}

const initState : initStateType = {
    onLoading : false,
    data : [],
    error : null
}

const reducer = (state : any, action : any) => {
    switch(action.type) {
        case(ACTIONS.API_REQUEST): {
            return { ...state, data: [], loading: true }
        }
        case(ACTIONS.FETCH_DATA): {
            return { ...state, data : action.payload, loading: false}
        }
        case(ACTIONS.ERROR): {
            return { ...state, data: [], error: action.payload }
        }
        default:
            return state;
    }
}

const useFetch = ( url  : string) => {
    const [state,dispatch] = useReducer(reducer, initState);

    const fetchData = async () => {
        dispatch({ type : ACTIONS.API_REQUEST })
        await axios.get(url)
            .then((res) => {
                dispatch({ type : ACTIONS.FETCH_DATA, payload: res.data })
            })
            .catch((err) => {
                dispatch({ type : ACTIONS.FETCH_DATA, payload: err.error })
            })
        return state;
    }

    return [state, fetchData]
}

export default useFetch