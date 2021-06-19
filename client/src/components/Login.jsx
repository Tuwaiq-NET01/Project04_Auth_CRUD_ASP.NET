import axios from 'axios';
import React, { useState, useEffect } from 'react';
import { Link, navigate } from '@reach/router';
import Storage from './Storage';

const Login = () => {


	const [logemail, setLog] = useState("");
	const [logPass, setLogPass] = useState("");
	//	const [emailError, setemailError]            = useState([]);
	//  const [passError, setPassError]              = useState([]);


	const handleLogin = (e) => {

		e.preventDefault();

		window.localStorage.clear();

		const addinfo =

		{
			"email": logemail,
			"password": logPass
		}

		axios
			.post('https://localhost:44364/api/Auth/token', addinfo)
			.then((res) => {
				console.log(addinfo)
				navigate("/dashboard");
				// Storage.clear();
				Storage.set("token", res.data.token);
				// console.log("token:", Storage.get("token"))


			})
			.catch((error) => {
				console.error(error);
				//	setemailError(error.response.data.email);
				//	setPassError(error.response.data.password);	
			});

	};




	return (
		<div className="lopage">
			<div className="logbody">

				<div class="login-wrapper">
					<form action="" class="form">
						<img src="./img/avatar.png" alt="" />
						<h2>Login</h2>
						<div class="input-group">
							<input id="pass" type="text" id="loginUser" onChange={(e) => setLog(e.target.value)} value={logemail} />
							<label for="loginUser">Email</label>

						</div>


						<div class="input-group">
							<input id="pass" type="password" id="loginPassword" data-type="password" onChange={(e) => setLogPass(e.target.value)} value={logPass} />

							<label for="loginPassword">Password</label>
						</div>
						<div className="btnflex">
							<input type="submit" value="Login" class="submit-btn" onClick={handleLogin} />
							<Link className="buttonflex" to="/register" >Sign up</Link>

						</div>

						{/* <p> {emailError}</p>
	  <p> { passError}</p> */}
						{/* <a href="#forgot-pw" class="forgot-pw">Forgot Password?</a> */}
					</form>


				</div>

			</div>
		</div>

	);
};

export default Login;



{/* <div className="container">
<div className="jumbotron">
  <h1>Wish List</h1>
</div> */}