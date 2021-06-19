import React, { useState, useEffect } from "react";
import axios from "axios";
import { Redirect } from "react-router-dom";
import "./auth.css";

function Login(props) {
    const [resUser, setResUser] = useState({});
    const [email, setEmail] = useState("");
    const [password, setPassword] = useState("");
    const [redirect, setRedirect] = useState(false);

    useEffect(() => {
        return () => {
            console.log(resUser);
            props.setUser(resUser);
        };
    }, [redirect]);

    const submit = (e) => {
        e.preventDefault();

        axios
            .post(
                "https://localhost:5001/api/auth/login",
                {
                    email,
                    password,
                },
                {
                    withCredentials: true,
                }
            )
            .then((res) => {
                setResUser(res.data.user);
                setRedirect(true);
            })
            .catch((err) => console.log(err));
    };

    if (redirect) {
        return <Redirect to="/" />;
    }

    return (
        <div className="fade-me">
            <div
                className="container"
                style={{ marginLeft: "30px", borderRadius: "15px" }}
            >
                <div className="row">
                    <div className="col-md-6">
                        <div className="card" style={{ borderRadius: "15px" }}>
                            <form onSubmit={submit} className="box">
                                <h1>Login</h1>
                                <p className="text-muted">
                                    {" "}
                                    Please enter your Email and password!
                                </p>
                                <input
                                    type="email"
                                    name=""
                                    placeholder="Email"
                                    required
                                    onChange={(e) => setEmail(e.target.value)}
                                />
                                <input
                                    type="password"
                                    name=""
                                    placeholder="Password"
                                    required
                                    onChange={(e) =>
                                        setPassword(e.target.value)
                                    }
                                />
                                <a className="forgot text-muted" href="#">
                                    Forgot password?
                                </a>
                                <input type="submit" name="" value="Login" />
                            </form>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    );
}

export default Login;
