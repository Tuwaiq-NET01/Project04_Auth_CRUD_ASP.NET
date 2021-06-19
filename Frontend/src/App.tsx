import * as React from 'react';
import Authintication from './Components/AuthinticationPage/Authintication'
import Home from './Home'
import axios from 'axios'
import {BrowserRouter as Router, Switch, Redirect, Route, Link} from "react-router-dom";

const {useEffect, useState} = React

const App = () => {
    axios.defaults.withCredentials = true
    axios.defaults.baseURL = 'https://induction2030.azurewebsites.net'
    axios.defaults.headers.post['Content-Type'] = 'application/json'
    const [loginstatus,
        setLoginStatus] = React.useState < boolean > (false)

    // useEffect(() => {
    
    //     axios
    //         .get('/api/Auth/user' , {withCredentials: true})
    //         .then(res => {
    //             console.log(res)
    //             setLoginStatus(true)
               
    //         })
    //         .catch(() => console.log("hj"))
    // }, [])
    return ( <Router> {
        !loginstatus
            ? <Authintication setLoginStatus={setLoginStatus}/>
            : <Home/>
    } </Router>
    );
}

export default App;