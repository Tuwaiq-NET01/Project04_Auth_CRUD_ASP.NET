import React from 'react'
import { useState, useEffect } from 'react';
import axios from 'axios';
import {Redirect} from 'react-router-dom';

export default function Login() {
  const [email, setEmail] = useState('');
  const [password, setPassword] = useState('');
  const [loggedin, setLoggedin] = useState(false)

  const handleEmail = (e) => {
    setEmail(e.target.value);
  }

  const handlePassword = (e) => {
    setPassword(e.target.value);
  }

  const submitData = async (e) => {
    e.preventDefault();
    let result;

    await axios.post('http://localhost:5000/api/auth/login', 
    {
      email : email,
      password : password},
    {
      withCredentials : true
    })
      .then(res => result = res)
      .catch(err => console.log(err));

    if(result !== null) {
      await axios.get('http://localhost:5000/api/auth/user', {
        withCredentials : true
      })
        .then(res => {
          localStorage.setItem('ASKid', res.data.id);
          localStorage.setItem('ASKusername', res.data.username);
          localStorage.setItem('ASKemail', res.data.email);
          localStorage.setItem('ASKgender', res.data.gender);

          setLoggedin(true);
        })
        .catch(err => console.log(err));
    }
  }

  if(loggedin) {
    return <Redirect to="/" />
  }

    return (
      <div className="container-fluid mt-5 d-flex justify-content-center align-item-center">
          <div className="form-signin align-item-center">
              <form onSubmit={submitData} >
                <h1 className="h3 mb-3 fw-normal">Please sign in</h1>

                <div className="form-floating">
                  <label htmlFor="floatingInput">Email address</label>
                  <input type="email" className="form-control" id="floatingInput" placeholder="name@example.com" onChange={handleEmail} />
                </div>

                <div className="form-floating">
                  <label htmlFor="floatingPassword">Password</label>
                  <input type="password" className="form-control" id="floatingPassword" placeholder="Password" onChange={handlePassword} />
                </div>
                <br />
                <button className="w-100 btn btn-lg btn-primary" type="submit">Sign in</button>
              </form>
            </div>
      </div>
    )
}
