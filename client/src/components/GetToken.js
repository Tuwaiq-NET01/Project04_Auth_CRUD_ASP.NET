import Storage from "./Storage";
import jwt_decode from "jwt-decode";

const GetToken = (
    function token() {

       
        const StoredToken = Storage.get("token")
        return{
           
            headers: {
                "Authorization": `Bearer ${StoredToken}`
            }}

     


    return {
        token

    };
})();

export default GetToken;
