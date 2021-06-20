import React, { Component } from 'react';
import { Container } from 'reactstrap';
import { NavMenu } from './NavMenu';
import { layoutStyle } from '../AppConstants';

export class Layout extends Component {
  static displayName = Layout.name;

  render () {
    return (
      <div style={layoutStyle}>
        <NavMenu />
        <Container>
          {this.props.children}
        </Container>
      </div>
    );
  }
}
