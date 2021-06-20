import React from "react";
import { Route, Redirect } from "react-router-dom";
import { AuthContext } from "./AuthContext";

const AuthenticatedRoute = ({ component: Component, ...rest }) => {
  return (
    <AuthContext.Consumer>
      {(auth) => (
        <Route
          {...rest}
          render={(props) =>
            auth.isAuthenticated === true ? (
              <Component {...props} />
            ) : (
              <Redirect to="/login" />
            )
          }
        />
      )}
    </AuthContext.Consumer>
  );
};
export default AuthenticatedRoute;
