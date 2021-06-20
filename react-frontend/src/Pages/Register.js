import axios from 'axios';
import React, {useState, useEffect} from 'react';
import { Redirect } from 'react-router';

export default function Register() {
    const [username, setUsername] = useState('')
    const [email, setEmail] = useState('');
    const [repeatEmail, setRepeatEmail] = useState('');
    const [password, setPassword] = useState('');
    const [gender, setGender] = useState('');

    const [registered, setRegistered] = useState(false);
    
    const submitData = async (e) => {
        if(email === repeatEmail) {
            await axios.post('http://localhost:5000/api//authregister', {
                username,
                email,
                password,
                gender
            })
                .then(res => 
                    {
                        setRegistered(true);
                    })
                .catch(err => console.log(err));
        }

        e.preventDefault();
    }

    if(registered) {
        return <Redirect to="/Login" />
    }

    return (
        <div className="container-fluid my-5 d-flex justify-content-center align-item-center">
          <div className="form-signin align-item-center">
              <form onSubmit={submitData} >
                <h1 className="h3 mb-3 fw-normal">Register Form</h1>

                <div className="form-floating">
                  <label htmlFor="floatingInput">User Name</label>
                  <input type="text" className="form-control" placeholder="username" onChange={(e) => setUsername(e.target.value)} />
                </div>

                <div className="form-floating">
                  <label htmlFor="floatingInput">Email address</label>
                  <input type="email" className="form-control" placeholder="name@example.com" onChange={(e) => setEmail(e.target.value)} />
                </div>

                <div className="form-floating">
                  <label htmlFor="floatingInput">Repeat Email address</label>
                  <input type="email" className="form-control" placeholder="name@example.com" onChange={(e) => setRepeatEmail(e.target.value)} />
                </div>

                <div className="form-floating">
                  <label htmlFor="floatingPassword">Password</label>
                  <input type="password" className="form-control" placeholder="Password" onChange={(e) => setPassword(e.target.value)} />
                </div>

                <div className="form-floating my-2">
                    <label className="mr-5">Select your gender</label>
                    <select onChange={(e) => setGender(e.target.value)}>
                        <option defaultValue="">-</option>
                        <option defaultValue="male">male</option>
                        <option defaultValue="female">female</option>
                    </select>
                </div>
                
                <button className="w-100 btn btn-lg btn-primary" type="submit">Register</button>
              </form>
            </div>
      </div>
    )
}
