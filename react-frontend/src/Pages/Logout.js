import axios from 'axios'
import React, {useState, useEffect} from 'react'
import { Redirect } from 'react-router'

export default function Logout() {
    const [loggedout, setLoggedout] = useState(false)

    const handleLogout = async (e) => {
        await axios.post('http://localhost:5000/api/auth/logout', {},
        {
        withCredentials : true
        })
        .then(res => {
            console.log(res);
            setLoggedout(true);
            localStorage.clear();
        })
        .catch(err => console.log(err));
    }

    if(loggedout) {
        return <Redirect to="/Login" />
      }

    return (
        <div>
            <h1 className="my-5">Are you sure you want to log out?</h1>
            <button type="button" className="btn btn-primary btn-lg" onClick={handleLogout}>Yes proceed with loggin out</button>
        </div>
    )
}
