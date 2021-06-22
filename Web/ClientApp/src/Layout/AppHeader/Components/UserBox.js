import React, { Fragment } from "react";
import { LoginMenu } from '../../../components/api-authorization/LoginMenu';

import {
  DropdownToggle,
  DropdownMenu,
  Nav,
  Button,
  Link,
  NavItem,
  NavLink,
  UncontrolledButtonDropdown,
} from "reactstrap";

import { toast, Bounce } from "react-toastify";

import { faCalendarAlt, faAngleDown } from "@fortawesome/free-solid-svg-icons";

import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";

import avatar1 from "../../../assets/utils/images/avatars/1.jpg";

class UserBox extends React.Component {
  constructor(props) {
    super(props);

  }


  render() {
    return (
      <Fragment>
        <div className="header-btn-lg pr-0">
          <div className="widget-content p-0">
            {
              // <div className="widget-content-wrapper">
              //   <div className="widget-content-left">
              //     <UncontrolledButtonDropdown>
              //       <DropdownToggle color="link" className="p-0">
              //         <img
              //           width={42}
              //           className="rounded-circle"
              //           src={avatar1}
              //           alt=""
              //         />
              //         <FontAwesomeIcon
              //           className="ml-2 opacity-8"
              //           icon={faAngleDown}
              //         />
              //       </DropdownToggle>
              //       <DropdownMenu right className="rm-pointers dropdown-menu-lg">
              //         <Nav vertical>
              //           <NavItem className="nav-item-header">My Account</NavItem>
              //           <NavItem>
              //             <NavLink>
              //               Settings
              //             </NavLink>
              //           </NavItem>
              //           <NavItem>
              //             <NavLink>Logout</NavLink>
              //           </NavItem>
              //         </Nav>
              //       </DropdownMenu>
              //     </UncontrolledButtonDropdown>
              //   </div>
              //   <div className="widget-content-left  ml-3 header-user-info">
              //     <div className="widget-heading">Abdulrahman Al-Maneea</div>
              //     <div className="widget-subheading">Administrative Account</div>
              //   </div>
              // </div>
            }
            <LoginMenu />
          </div>
        </div>
      </Fragment>
    );
  }
}

export default UserBox;
