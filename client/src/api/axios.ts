import axios from "axios";

export default axios.create({
    baseURL: "http://localhost:5067",
    headers : {
        "Content-Type" : "application/json"
    }
})