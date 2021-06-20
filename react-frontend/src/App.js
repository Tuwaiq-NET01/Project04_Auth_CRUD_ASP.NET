import './App.css';
import { useState, useEffect } from 'react';
import axios from 'axios';
import { BrowserRouter, Switch, Route, Redirect } from 'react-router-dom';
import Navmenu from './Components/Navmenu';
import FeedPage from './Pages/FeedPage';
import Register from './Pages/Register';
import Login from './Pages/Login';
import Courses from './Pages/AvailableCourses';
import Learning from './Pages/MyLearning';
import StudentInfo from './Pages/StudentInfo';
import Logout from './Pages/Logout';

export default function App() {
  return (
    <BrowserRouter>
      <div>
        <Navmenu />
        <div className="App">
          <Switch>
          {/* <Route exact path="/">
            <FeedPage />
          </Route> */}
          <Route exact path="/">
            <Courses />
          </Route>
          <Route exact path="/Learning">
            <Learning />
          </Route>
          <Route exact path="/User">
            <StudentInfo />
          </Route>
          <Route exact path="/Register">
            <Register />
          </Route>
          <Route exact path="/Login">
            <Login />
          </Route>
          <Route exact path="/Logout">
            <Logout />
          </Route>
        </Switch>
        </div>
      </div>
    </BrowserRouter>
  );
}