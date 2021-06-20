import "./App.css";
import { BrowserRouter as Router, Route, Link } from "react-router-dom";
import Home from "./Home";
import Register from "./user/Register";
import Login from "./user/Login";
import axios from "axios";
import React, { Component } from "react";
import { decode } from "jsonwebtoken";
import { Alert } from "react-bootstrap";
import Contact from "./Contact";
import MembersList from "./members/MembersList";
import CoachesList from "./coaches/CoachesList";
import TypesList from "./typess/TypesList";
import StoryList from "./story/StoryList";
import TournamentsList from "./tournaments/TournamentsList";

import Profile from "./user/Profile";
import 'bootstrap/dist/css/bootstrap.min.css';

export default class App extends Component {
  state = {
    isAuth: false,
    user: null,
    users: [],
    message: null,
    successMessage: null,
  };

  // excute automaticlly
  componentDidMount() {
    // save token in local storage
    let token = localStorage.getItem("token");
    // decode token if not null and save it into user
    if (token != null) {
      let user = decode(token);

      // allow user login after decode the token
      if (user) {
        this.setState({
          isAuth: true,
          user: user,
        });

      // not allow user login and remove token
      } else if (!user) {
        localStorage.removeItem("token");
        this.setState({
          isAuth: false,
        });
      }
    }
  }
  // add user in database by axios and give you massage if success or failure
  registerHandler = (user) => {
    axios
      .post("authManagement/register", user)
      .then((response) => {
        console.log(response);

        if (response.data.message == "User registered successfully") {
        this.setState({
          successMessage: "Welcome to the RSDC website and thanks for signing up!"
        });
            } 
        else{
        this.setState({
          message: response.data.message,
        });
      }
      })
      .catch((error) => {
        console.log(error);
        this.setState({
          message: "Error Occured. Please try again later!!!",
        });
      });

      //remove the alert message after 3 seconds
      setTimeout(() => {
        this.setState({
          message: false,
          successMessage:false
        });
      }, 3000);
  };

    // login user by axios and give you massage if success or failure
  loginHandler = (user) => {
    axios
      .post("authManagement/login", user)
      .then((response) => {
        console.log(response);
        console.log(response.data.token);
    // save token in local storage 
        if (response.data.token != null) {
          localStorage.setItem("token", response.data.token);
          let user = decode(response.data.token);

          this.setState({
            isAuth: true,
            user: user,
            successMessage: "User log in successfully",
          });
        } else {
          this.setState({
            isAuth: false,
            user: null,
            message: "Incorrect username or password",
          });
        }
      })
      .catch((error) => {
        console.log(error);
        this.setState({
          isAuth: false,
          message: "Error Occured. Please try again later!!!",
        });
      });

      //remove the alert message after 3 seconds
      setTimeout(() => {
        this.setState({
          message: false,
          successMessage:false
        });
      }, 3000);
  };

  // logout if user click logout link and give you message if success
  onLogoutHandler = () => {
    axios.post("authManagement/login")

    // remove token
    localStorage.removeItem("token");
    this.setState({
      isAuth: false,
      user: null,
      successMessage: "User logout successfully"
    });

    //remove the alert message after 3 seconds
    setTimeout(() => {
      this.setState({
        successMessage:false
      });
    }, 3000);
  };


  render() {
    const { isAuth } = this.state;

        // allert to view the message 
    const message = this.state.message ? (
      <Alert variant="danger">{this.state.message}</Alert>
    ) : null;

    const successMessage = this.state.successMessage ? (
      <Alert variant="success">{this.state.successMessage}</Alert>
    ) : null;

    return (
      <Router>
        <nav>
          {/* change nav bar link if login */}
          {isAuth ? (
            <div>
              <Link className="left" to="/home">RSDC</Link>{"  "}
              <Link className="left" to="/members">Members</Link> {"  "}
              <Link className="left" to="/coaches">Coaches</Link> {"  "}
              <Link className="left" to="/types">Types</Link> {"  "}
              <Link className="left" to="/story">Story</Link> {"  "}
              <Link className="left" to="/tournaments">Tournaments</Link> {"  "}

              <Link className="right" to="/logout" onClick={this.onLogoutHandler}>Logout</Link>{" "}
              <Link className="right" to="/contact">Contact Us</Link> {"  "}
              <Link className="right" to="/profile">Profile</Link> {"  "}
              
            </div>
          ) : (
            <div>
              <Link className="left" to="/home">RSDC</Link>{"  "}
              <Link className="right" to="/register">Register</Link> {"  "}
              <Link className="right" to="/login">Login</Link> {"  "}  
              <Link className="right" to="/contact">Contact Us</Link> {"  "}

            </div>
          )}
                 {/* show information here */}
                {message} {successMessage}

        </nav>
        
        <div>
               {/* show information of link into route */}
        <Route path="/home" component={() => <Home />} ></Route>
        <Route path="/register" component={() => <Register register={this.registerHandler} />} ></Route>
        <Route path="/contact" component={() => <Contact />} ></Route>
        <Route path="/logout" component={() => <Home />} ></Route>
        <Route path="/profile" component={() => <Profile  email={this.state.user.sub} />} ></Route>
        <Route path="/members" component={() => <MembersList email={this.state.user.sub} />} ></Route>
        <Route path="/coaches" component={() => <CoachesList email={this.state.user.sub} />} ></Route>
        <Route path="/types" component={() => <TypesList email={this.state.user.sub} />} ></Route>
        <Route path="/story" component={() => <StoryList email={this.state.user.sub} />} ></Route>
        <Route path="/tournaments" component={() => <TournamentsList email={this.state.user.sub} />} ></Route>

          <Route
            path="/login"
            component={() =>
              isAuth ?
               <div><h2>Welcome{" "}{this.state.user.sub}{" "}to the Red Sea Diving Center website</h2>
               </div> 
               
              : <Login login={this.loginHandler} />
            }
          ></Route>
        </div>
        <div className="footer">
           <p>@ Copy right for Tech Shadow(Adel Kalu) 2021</p>
         </div>
      </Router>
    );
  }
}
