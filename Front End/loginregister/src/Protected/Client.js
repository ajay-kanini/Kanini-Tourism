import { Navigate } from "react-router-dom";

function Client({role, children }) {
    
    if(localStorage.getItem('role')!= null && localStorage.getItem('role') === "Client")
    {
        return children;
    }
    return <Navigate to="/"/>

}

export default Client;