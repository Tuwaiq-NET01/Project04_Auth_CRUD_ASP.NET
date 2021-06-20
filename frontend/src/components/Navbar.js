import React, { useContext, useState } from "react";
import { Link, NavLink } from "react-router-dom";
import { AuthContext } from "./auth/AuthContext";

const Navbar = () => {
  const { isAuthenticated, user } = useContext(AuthContext);
  const [navbarOpen, setNavbarOpen] = useState(false);
  const [profileOpen, setProfileOpen] = useState(false);
  const [avatar, setAvatar] = useState(
    "https://t3.ftcdn.net/jpg/03/46/83/96/360_F_346839683_6nAPzbhpSkIpb8pmAwufkC7c5eD7wYws.jpg"
  );

  const unauthnticatedNavbar = () => {
    return (
      <>
        <div className="relative bg-white">
          <div className="max-w-7xl mx-auto px-4 sm:px-6">
            <div className="px-6 flex justify-between items-center border-b-2 border-gray-100 my-0 py-3 md:justify-start md:space-x-10">
              <div>
                <Link to="/">
                  <div className="flex"></div>
                  <img
                    className="h-8 w-auto sm:h-10"
                    src="/logo192.png"
                    alt="app logo"
                  />
                </Link>
              </div>
              <div className="-mr-2 -my-2 md:hidden">
                <button
                  type="button"
                  className="inline-flex items-center justify-center p-2 rounded-md text-gray-400 hover:text-gray-500 hover:bg-gray-100 focus:outline-none focus:bg-gray-100 focus:text-gray-500"
                >
                  <svg
                    className="h-6 w-6"
                    fillRule="none"
                    viewBox="0 0 24 24"
                    stroke="currentColor"
                  >
                    <path
                      strokeLinecap="round"
                      strokeLinejoin="round"
                      strokeWidth="2"
                      d="M4 6h16M4 12h16M4 18h16"
                    />
                  </svg>
                </button>
              </div>

              <div className="font-noto font-normal hidden md:flex items-center justify-end space-x-8 md:flex-1 lg:w-0">
                <Link to="/login">
                  <div className="whitespace-no-wrap text-gray-500 hover:text-gray-900 focus:outline-none focus:text-gray-900">
                    Log in
                  </div>
                </Link>
                <span className="font-noto font-normal inline-flex rounded-md shadow-sm">
                  <Link to="/signup">
                    <div
                      className="whitespace-no-wrap inline-flex items-center justify-center px-3 py-2 border border-green-700 
                    rounded-md text-green-700 hover:bg-green-700 hover:text-white focus:outline-none focus:border-green-700 focus:shadow-outline-green active:bg-blue-700"
                    >
                      Sign up
                    </div>
                  </Link>
                </span>
              </div>
            </div>
          </div>

          {/* Mobile navbar */}
          <div className="absolute top-0 inset-x-0 p-2 transition transform origin-top-right md:hidden">
            <div className="rounded-lg">
              <div className="rounded-lg bg-white divide-y-2 divide-gray-50">
                <div className="pt-5 pb-6 px-5 space-y-6">
                  <div className="flex items-center justify-between">
                    <div>
                      <img
                        className="h-8 w-auto"
                        src="/logo192.png"
                        alt="app logo"
                      />
                    </div>
                    <div className="-mr-2">
                      <button
                        type="button"
                        className="inline-flex items-center justify-center p-2 rounded-md text-gray-400 hover:text-gray-500 hover:bg-gray-100 focus:outline-none focus:bg-gray-100 focus:text-gray-500"
                        onClick={() => setNavbarOpen(!navbarOpen)}
                      >
                        <svg
                          viewBox="0 0 20 20"
                          fill="currentColor"
                          className="menu w-6 h-6"
                        >
                          <path
                            fillRule="evenodd"
                            d="M3 5a1 1 0 011-1h12a1 1 0 110 2H4a1 1 0 01-1-1zM3 10a1 1 0 011-1h12a1 1 0 110 2H4a1 1 0 01-1-1zM3 15a1 1 0 011-1h12a1 1 0 110 2H4a1 1 0 01-1-1z"
                            clipRule="evenodd"
                          ></path>
                        </svg>
                      </button>
                    </div>
                  </div>
                </div>
                <div
                  className={
                    (navbarOpen ? " flex " : " hidden ") +
                    "py-6 px-5 space-y-6 rounded-b-lg shadow-lg  justify-center"
                  }
                >
                  <div className="space-y-6">
                    <span className="w-full flex rounded-md shadow-sm">
                      <Link
                        to="/signup"
                        className="w-full text-center px-3 py-2 border border-green-700 
                    rounded-md text-green-700 hover:bg-green-700 hover:text-white focus:outline-none focus:border-green-700 focus:shadow-outline-green active:bg-blue-700"
                        onClick={() => setNavbarOpen(!navbarOpen)}
                      >
                        Sign up
                      </Link>
                    </span>
                    <p className="text-center text-base leading-6 font-medium text-gray-500">
                      Existing user?
                      <Link
                        to="/login"
                        className="text-green-600 hover:text-green-500"
                        onClick={() => setNavbarOpen(!navbarOpen)}
                      >
                        {" "}
                        Log in
                      </Link>
                    </p>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
      </>
    );
  };

  const logoutHandler = () => {
    // AuthService.logout().then((data) => {
    //   if (data.success) {
    //     setUser(data.user);
    //     setIsAuthenticated(false);
    //     //redirect to home page
    //   }
    // });
  };

  const authenticatedNavbar = () => {
    return (
      <>
        <div className="relative bg-white">
          <div className="max-w-7xl mx-auto px-4 sm:px-6">
            <div className="px-6 flex justify-between items-center border-b-2 border-gray-100 py-6 md:justify-start md:space-x-10">
              <div>
                <Link to="/">
                  <img
                    className="h-8 w-auto sm:h-10"
                    src="/logo192.png"
                    alt="app logo"
                  />
                </Link>
              </div>
              <div className="-mr-2 -my-2 md:hidden">
                <button
                  type="button"
                  className="inline-flex items-center justify-center p-2 rounded-md text-gray-400 hover:text-gray-500 hover:bg-gray-100 focus:outline-none focus:bg-gray-100 focus:text-gray-500"
                >
                  <svg
                    className="h-6 w-6"
                    fill="none"
                    viewBox="0 0 24 24"
                    stroke="currentColor"
                  >
                    <path
                      strokeLinecap="round"
                      strokeLinejoin="round"
                      strokeWidth="2"
                      d="M4 6h16M4 12h16M4 18h16"
                    />
                  </svg>
                </button>
              </div>

              <div className="hidden md:flex items-center justify-end space-x-8 md:flex-1 lg:w-0">
                <div className="ml-3 relative">
                  <div>
                    <button
                      className="flex text-sm border-2 border-transparent rounded-full focus:outline-none focus:border-white"
                      id="user-menu"
                      aria-label="User menu"
                      aria-haspopup="true"
                      onClick={() => setProfileOpen(!profileOpen)}
                    >
                      <img
                        className="h-8 w-8 rounded-full"
                        src={avatar}
                        alt="User profile image"
                      />
                    </button>
                  </div>

                  <div
                    className={
                      (profileOpen ? " absolute " : " hidden ") +
                      "origin-top-right absolute right-0 mt-2 w-48 rounded-md shadow-lg"
                    }
                  >
                    <Link to="/profile">
                      <div className="py-1 px-4 rounded-md rounded-b-none border-b bg-white shadow-xs hover:bg-gray-50 cursor-pointer">
                        Profile
                      </div>{" "}
                    </Link>
                    <div
                      className="py-1 px-4 rounded-md rounded-t-none bg-white shadow-xs hover:bg-gray-50 cursor-pointer"
                      onClick={logoutHandler}
                    >
                      Log out
                    </div>
                  </div>
                </div>
              </div>
            </div>
          </div>

          {/* Mobile navbar */}
          <div className="absolute top-0 inset-x-0 p-2 transition transform origin-top-right md:hidden">
            <div className="rounded-lg  ">
              <div className="rounded-lg  bg-white divide-y-2 divide-gray-50">
                <div className="pt-5 pb-6 px-5 space-y-6">
                  <div className="flex items-center justify-between">
                    <div>
                      <img
                        className="h-8 w-auto"
                        src="/logo192.png"
                        alt="app logo"
                      />
                    </div>
                    <div className="-mr-2">
                      <button
                        type="button"
                        className="inline-flex items-center justify-center p-2 rounded-md text-gray-400 hover:text-gray-500 hover:bg-gray-100 focus:outline-none focus:bg-gray-100 focus:text-gray-500"
                        onClick={() => setNavbarOpen(!navbarOpen)}
                      >
                        <svg
                          viewBox="0 0 20 20"
                          fill="currentColor"
                          className="menu w-6 h-6"
                        >
                          <path
                            fillRule="evenodd"
                            d="M3 5a1 1 0 011-1h12a1 1 0 110 2H4a1 1 0 01-1-1zM3 10a1 1 0 011-1h12a1 1 0 110 2H4a1 1 0 01-1-1zM3 15a1 1 0 011-1h12a1 1 0 110 2H4a1 1 0 01-1-1z"
                            clipRule="evenodd"
                          ></path>
                        </svg>
                      </button>
                    </div>
                  </div>
                </div>
                <div
                  className={
                    (navbarOpen ? " flex " : " hidden ") +
                    "py-6 px-5 space-y-6 rounded-b-lg shadow-lg  justify-center"
                  }
                >
                  <div className="py-6 px-5 space-y-6">
                    <div className="space-y-6">
                      <span className="w-full flex rounded-md shadow-sm">
                        <Link to="/profile">
                          <div className="py-1 px-4 rounded-md rounded-b-none border-b bg-white shadow-xs hover:bg-gray-50 cursor-pointer">
                            Profile
                          </div>
                        </Link>
                        <div
                          className="py-1 px-4 rounded-md rounded-t-none bg-white shadow-xs hover:bg-gray-50 cursor-pointer"
                          onClick={logoutHandler}
                        >
                          Log out
                        </div>
                      </span>
                    </div>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
      </>
    );
  };

  return (
    <>{isAuthenticated ? authenticatedNavbar() : unauthnticatedNavbar()}</>
  );
};

export default Navbar;
