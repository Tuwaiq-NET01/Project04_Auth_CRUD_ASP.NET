import React, { Component } from 'react';
import { Container } from 'reactstrap';
import NavMenu from './NavMenu';

function Layout(props) {

    return (
      <div>
        <NavMenu user={props.user} setUser={props.setUser}/>
        <Container>
          {props.children}
        </Container>
      </div>
    );
}
export default Layout;