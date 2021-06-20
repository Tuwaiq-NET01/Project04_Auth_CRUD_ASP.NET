import React, { Component } from 'react';
import { Collapse, Container, Navbar, NavbarBrand, NavbarToggler, NavItem, NavLink } from 'reactstrap';
import { Link } from 'react-router-dom';
import { LoginMenu } from './api-authorization/LoginMenu';
import './NavMenu.css';
import { navMenu } from "../AppConstants";

export class NavMenu extends Component {
  static displayName = NavMenu.name;

  constructor (props) {
    super(props);

    this.toggleNavbar = this.toggleNavbar.bind(this);
    this.state = {
      collapsed: true
    };
  }

  toggleNavbar () {
    this.setState({
      collapsed: !this.state.collapsed
    });
  }

  render () {
    return (
      <header>
        <Navbar className={navMenu.className} dark={navMenu.brand == "dark"} light={navMenu.brand != "dark"}>
          <Container>
            <NavbarBrand tag={Link} to="/">TuwaiqCVMaker</NavbarBrand>
            <NavbarToggler onClick={this.toggleNavbar} className="mr-2" />
            <Collapse className="d-sm-inline-flex flex-sm-row-reverse" isOpen={!this.state.collapsed} navbar>
              <ul className="navbar-nav flex-grow">
                <NavItem>
                  <NavLink tag={Link} className={navMenu.navLink.className} to="/">Home</NavLink>
                </NavItem>
                <NavItem>
                  <NavLink tag={Link} className={navMenu.navLink.className} to="/resumes">Resumes</NavLink>
                </NavItem>
                <NavItem>
                  <NavLink tag={Link} className={navMenu.navLink.className} to="/editor">Editor</NavLink>
                </NavItem>
                <LoginMenu>
                </LoginMenu>
              </ul>
            </Collapse>
          </Container>
        </Navbar>
      </header>
    );
  }
}
