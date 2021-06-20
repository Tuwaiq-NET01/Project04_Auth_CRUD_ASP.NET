import React, { createContext, useState, useEffect } from "react";
import AuthService from "../../services/auth-service";

export const AuthContext = createContext(null);

const AuthProvider = ({ children }) => {
  const [user, setUser] = useState(null);
  const [isAuthenticated, setIsAuthenticated] = useState(false);
  const [isLoaded, setIsLoaded] = useState(false);

  useEffect(() => {
    console.log("auth context");
    AuthService.isAuthenticated().then((data) => {
      console.log(data);
      setUser({
        username: data.username,
        displayName: data.displayName,
        bio: data.bio,
        imageUrl: "",
        articles: data.articles,
      });
      setIsAuthenticated(data.isAuthenticated);
      setIsLoaded(true);
    });
  }, [isAuthenticated]);

  return (
    <div>
      {!isLoaded ? (
        <div className="fixed top-0 right-0 h-screen w-screen z-50 flex justify-center items-center">
          <div className="loader ease-linear rounded-full border-2 border-t-2 border-gray-200 h-14 w-14"></div>
        </div>
      ) : (
        <AuthContext.Provider
          value={{ user, setUser, isAuthenticated, setIsAuthenticated }}
        >
          {children}
        </AuthContext.Provider>
      )}
    </div>
  );
};

export default AuthProvider;
