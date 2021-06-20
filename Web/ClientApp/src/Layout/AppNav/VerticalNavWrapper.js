import React, { Component, Fragment } from "react";
import { withRouter } from "react-router-dom";

import MetisMenu from "react-metismenu";

import {
  // MainNav,
  GlobalServices,
  AdministrativeNav,
  PersonalNav,
  MiscNav,
} from "./NavItems";

class Nav extends Component {
  state = {};

  render() {
    return (
      <Fragment>
        <h5 className="app-sidebar__heading">Global Services</h5>
        <MetisMenu
          content={GlobalServices}
          activeLinkFromLocation
          className="vertical-nav-menu"
          iconNamePrefix=""
          classNameStateIcon="pe-7s-angle-down"
        />
        {/* <h5 className="app-sidebar__heading">Personalized Services</h5>
        <MetisMenu
          content={PersonalNav}
          activeLinkFromLocation
          className="vertical-nav-menu"
          iconNamePrefix=""
          classNameStateIcon="pe-7s-angle-down"
        /> */}
        <h5 className="app-sidebar__heading">Administrative Services</h5>
        <MetisMenu
          content={AdministrativeNav}
          activeLinkFromLocation
          className="vertical-nav-menu"
          iconNamePrefix=""
          classNameStateIcon="pe-7s-angle-down"
        />
        <h5 className="app-sidebar__heading">Vuln View</h5>
        <MetisMenu
          content={MiscNav}
          activeLinkFromLocation
          className="vertical-nav-menu"
          iconNamePrefix=""
          classNameStateIcon="pe-7s-angle-down"
        />
      </Fragment>
    );
  }

  isPathActive(path) {
    return this.props.location.pathname.startsWith(path);
  }
}

export default withRouter(Nav);
