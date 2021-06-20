import React from "react";
import { BrowserRouter as Router, Route, Switch } from "react-router-dom";
import AuthenticatedRoute from "./components/auth/AuthenticatedRoute";

import Login from "./components/Login";
import SignUp from "./components/SignUp";
import Home from "./components/Home";
import Navbar from "./components/Navbar";
import Profile from "./components/profile/Profile";
import ArticlePage from "./components/articles/ArticlePage";
import ArticleEditor from "./components/articles/ArticleEditor";
import EditProfile from "./components/profile/EditProfile.js";

const App = () => {
  return (
    <>
      <Router>
        <Navbar />
        <Switch>
          <Route exact path="/" component={Home} />
          <Route path="/login" component={Login} />
          <Route path="/signup" component={SignUp} />
          <Route path="/profile" component={Profile} />
          <Route exact path="/articles/:articleId" component={ArticlePage} />
          <Route
            exact
            path="/home/tags/:tagId"
            render={(props) => <Home {...props} />}
          />
          <AuthenticatedRoute
            exact
            path="/articles/new"
            component={ArticleEditor}
          />

          <AuthenticatedRoute
            exact
            path="/articles/:articleId/edit"
            component={ArticleEditor}
          />

          <AuthenticatedRoute
            exact
            path="/profile/edit"
            component={EditProfile}
          />
        </Switch>
      </Router>
    </>
  );
};

export default App;
