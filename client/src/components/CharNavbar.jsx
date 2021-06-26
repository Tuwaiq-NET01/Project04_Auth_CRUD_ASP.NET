import React, { useState } from 'react';
import * as FaIcons from 'react-icons/fa';
import * as AiIcons from 'react-icons/ai';
import { SidebarData } from './SidebarData';
import './Navbar.css';
import { IconContext } from 'react-icons';
import { Router, Link, navigate } from '@reach/router';
import Storage from './Storage';

function CharNavbar() {
  const [sidebar, setSidebar] = useState(false);

  const showSidebar = () => setSidebar(!sidebar);
  function logout() {
    Storage.remove("token");
    navigate("/login");
  }
  return (
    <>
      <IconContext.Provider value={{ color: '#fff' }}>
        <div className='Charnavbar'>
          <Link to='#' className='CNmenu-bars'>
            <FaIcons.FaBars onClick={showSidebar} />
          </Link>
        </div>
        <nav className={sidebar ? 'CNnav-menu active' : 'CNnav-menu'}>
          <ul className='nav-menu-items CNnav-menu-items' onClick={showSidebar}>
            <li className='navbar-toggle CNnavbar-toggle'>
              <Link to='#' className='menu-bars'>
                <AiIcons.AiOutlineClose />
              </Link>
            </li>
            {SidebarData.map((item, index) => {
              return (
                <li key={index} className={item.cName}>

{(() => {
        if (item.title == "Log Out") {
          return (
            <button onClick = {logout}  className ="btn shadow-none text-light ">
            {item.icon}
            <span className ="CNspan">{item.title}</span>
          </button>
          )
       
        } else {
          return (
            <Link to={item.path}>
                    {item.icon}
                    <span className ="CNspan">{item.title}</span>
                  </Link>
          )
        }
      })()}
                 
                </li>
              );
            })}
          </ul>
        </nav>
      </IconContext.Provider>
    </>
  );
}

export default CharNavbar;