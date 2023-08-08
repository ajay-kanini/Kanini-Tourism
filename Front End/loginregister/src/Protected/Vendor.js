import { Navigate } from "react-router-dom";

function Vendor({role, children }) {
    
    if(localStorage.getItem('role')!= null && localStorage.getItem('role') === "Vendor")
    {
        return children;
    }
    return <Navigate to="/"/>

}

export default Vendor;