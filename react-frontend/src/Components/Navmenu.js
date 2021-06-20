import React, { Component } from 'react'
import { Link } from 'react-router-dom';
import './Navmenu.css'

export default class Navmenu extends Component {
    constructor(props) {
        super(props);

        this.state = {
            student: localStorage.getItem('ASKusername'),
            loggedIn : localStorage.getItem('ASKid') === null ? false : true
        }
    }

    render() {
        return (
            <nav className="navbar navbar-expand-lg navbar-light bg-primary">
                <div className="container d-flex justify-content-around">
                    <div className="w-50 d-flex">
                        <Link className="navbar-brand text-light" to="/">AskAcademy</Link>
                    </div>
                    <div className="collapse navbar-collapse d-flex justify-content-end" id="navbarNavAltMarkup">
                        <div className="navbar-nav">
                            {/* <Link className="nav-link text-light" to="/Courses">Available Courses</Link> */}
                            <Link className="nav-link text-light" to="/Learning">My Learning</Link>
                            {
                                this.state.loggedIn 
                                ?
                                <Link className="nav-link text-light" to="/User">{this.state.student}</Link>
                                :
                                <Link className="nav-link text-light" to="/Register">Register</Link>
                            }
                            {
                                this.state.loggedIn 
                                ?
                                <Link className="nav-link text-light" to="/Logout">Logout</Link>
                                :
                                <Link className="nav-link text-light" to="/Login">Login</Link>
                            }
                        </div>
                    </div>
                </div>
            </nav>
        )
    }
}