import React from 'react';
import { Router, Link, navigate } from '@reach/router';

function PartialNav(props) {
    return (
        <>
<nav class="navbar yellow navbar-expand-md navbar-dark ">
  <div class="navbar-collapse collapse" id="navbar4">
      <ul class="navbar-nav">
          <li className="nav-item"><Link className ="nav-link pr-3 nav-item-home" to="/">Home </Link></li> 
      </ul>
  </div>
       </nav>
        </>
    );
}

export default PartialNav;