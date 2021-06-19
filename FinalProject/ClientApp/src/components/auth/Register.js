import React, {useState} from 'react';
import axios from "axios";
import { Redirect } from 'react-router-dom';

function Register(props) {

    const [name, setName] = useState("");
    const [email, setEmail] = useState("");
    const [password, setPassword] = useState("");
    const [redirect, setRedirect] = useState(false);
    
    const submit = (e) => {
        e.preventDefault();
        
        axios.post("https://localhost:5001/api/auth/register", {
            name,
            email,
            password
        }).then(res => {
            setRedirect(true)
        }).catch(err => console.log(err))
        
    }
    
    if (redirect){
        return <Redirect to="/login"/>
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
                                <h1>Register</h1>
                                <p className="text-muted" style={{ marginBottom: "50px"}}>
                                    {" "}
                                    Please enter your Name, Email and password!
                                </p>
                                <input
                                    type="email"
                                    name=""
                                    placeholder="Email"
                                    required
                                    onChange={(e) => setEmail(e.target.value)}
                                />
                                <input
                                    type="text"
                                    name=""
                                    placeholder="Full Name"
                                    required
                                    onChange={(e) => setName(e.target.value)}
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
                                <input type="submit" name="" value="Register" />
                            </form>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    );
}

export default Register;