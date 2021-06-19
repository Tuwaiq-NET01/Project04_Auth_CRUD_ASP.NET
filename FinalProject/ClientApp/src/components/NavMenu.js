import React, { Component, useState } from "react";
import {
    Collapse,
    Container,
    Nav,
    Navbar,
    NavbarBrand,
    NavbarToggler,
    NavItem,
    NavLink,
} from "reactstrap";
import { Link } from "react-router-dom";

import logo from "./logo.png"
import logo2 from "./logo2.png"

import "./NavMenu.css";
import axios from "axios";

function NavMenu(props) {
    const [collapsed, setCollapsed] = useState(true);

    let logMenu;
    let favMenu;

    const logout = () => {
        axios
            .post(
                "https://localhost:5001/api/auth/logout",
                {},
                {
                    withCredentials: true,
                }
            )
            .then((res) => {
                console.log(res);
                props.setUser({});
            })
            .catch((err) => console.log(err));
    };

    const toggleNavbar = () => {
        setCollapsed(!collapsed);
    };

    // console.log(props.user)
    if (Object.keys(props.user).length < 1) {
        logMenu = (
            <ul className="navbar-nav flex-grow">
                <NavItem>
                    <NavLink tag={Link} className="text-light" to="/login">
                        Login
                    </NavLink>
                </NavItem>
                <NavItem>
                    <NavLink tag={Link} className="text-light" to="/register">
                        Register
                    </NavLink>
                </NavItem>
            </ul>
        );

        favMenu = null;
    } else {
        logMenu = (
            <ul className="navbar-nav flex-grow">
                <NavItem>
                    <NavLink
                        tag={Link}
                        className="text-light"
                        to="/profile"
                    >
                        {props.user.name}'s Profile
                    </NavLink>
                </NavItem>
                <NavItem>
                    <NavLink
                        tag={Link}
                        className="text-light"
                        to="/"
                        onClick={logout}
                    >
                        Logout
                    </NavLink>
                </NavItem>
            </ul>
        );

        favMenu = (
            <div style={{ display: "flex", float: "left" }}>
                <NavItem>
                    <NavLink
                        tag={Link}
                        className="text-light"
                        to="/favorite-movies"
                    >
                        Favorite Movies
                    </NavLink>
                </NavItem>
                <NavItem>
                    <NavLink tag={Link} className="text-light" to="/favorite-tvshow">
                        Favorite TV Shows
                    </NavLink>
                </NavItem>
            </div>
        );
    }

    return (
        <header className="fade-me">
            <Navbar
                className="navbar-expand-sm navbar-toggleable-sm ng-white  border-bottom box-shadow mb-3"
                light
            >
                <Container>
                    <NavbarBrand tag={Link} to="/">
                        <img src={logo} alt="not" height="50px"/>
                    </NavbarBrand>
                    <NavbarToggler onClick={toggleNavbar} className="mr-2" />
                    <Collapse
                        className="d-sm-inline-flex flex-sm-row-reverse"
                        isOpen={!collapsed}
                        navbar
                    >
                        {logMenu}

                        <Nav className="mr-auto" navbar>
                            <NavItem>
                                <NavLink
                                    tag={Link}
                                    className="text-light"
                                    to="/"
                                >
                                    Home
                                </NavLink>
                            </NavItem>
                            <NavItem>
                                <NavLink
                                    tag={Link}
                                    className="text-light"
                                    to="/movies"
                                >
                                    Movies
                                </NavLink>
                            </NavItem>
                            <NavItem>
                                <NavLink
                                    tag={Link}
                                    className="text-light"
                                    to="/tv-shows"
                                >
                                    TV Shows
                                </NavLink>
                            </NavItem>
                            {favMenu}
                        </Nav>
                    </Collapse>
                </Container>
            </Navbar>
        </header>
    );
}

export default NavMenu;
