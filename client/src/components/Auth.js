import Storage from "./Storage";
import jwt_decode from "jwt-decode";

const Authenticatiion = (function () {
    function IsUserLoggedIn() {
        //	return JSON.parse(myStorage.getItem(name));
        var token = Storage.get("token");
        if (!token) return false;

        var decoded = jwt_decode(token);
        

        return true;
    }


    return {
        IsUserLoggedIn

    };
})();

export default Authenticatiion;
