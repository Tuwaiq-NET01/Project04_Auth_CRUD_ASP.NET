import axios from 'axios';
import React, {useState, useEffect} from 'react';
import { Link, navigate } from '@reach/router';
import Storage from './Storage';
import PartialNav from './PartialNav';
const Register = () => {

    const [firstname, setFirstName]            = useState(""); 
	const [lastname, setLastName]                = useState("");
    const [email, setEmail]                    = useState("");       
    const [password, setPassword]              = useState("");
    const [username, setUsername]              = useState("");
    const [validations, setError]           = useState(null);
   


    const handleSubmit = (e) => {
        e.preventDefault();
        window.localStorage.clear();
        
       const addUser=
          {
       "firstName": firstname,
       "lastName": lastname,
       "username": username,
       "email": email,
       "password": password
        
          }
        axios
          .post('https://localhost:44364/api/Auth/register/', addUser)
          .then((res) => {
              console.log(addUser)
           //   console.log(addinfo)
              navigate("/dashboard");
              // Storage.clear();
              Storage.set("token", res.data.token);
              // console.log("token:", Storage.get("token"))
  
            } )  .catch(function (error) {
              if (error.response) {
                //console.log(error)
                // Request made and server responded
                
              console.log(error.response.data.errors);
                  setError("Please complete all fields  ")
                

              }  
            });          
      };


    return (
        <>

<nav class="navbar yellow navbar-expand-md navbar-dark ">
  
  <div class="navbar-collapse collapse" id="navbar4">
      <ul class="navbar-nav">
          <li className="nav-item"><Link className ="nav-link pr-3 nav-item-home" to="/">Home </Link></li> 
      </ul>
  </div>
</nav>


         <div className = "lopage">
         <div   className = "logbody">
           <div class="login-wrapper">
    <form action="" class="form">
      <img src="./img/avatar.png" alt="" />
      <h2>Sign up</h2>
      <div class="input-group">
		<input id="pass" type="" id="loginUser" data-type=""  onChange={(e) => setEmail(e.target.value)} value={email}  />
        <label for="loginEmail">Email</label>
      </div>

    
      <div class="input-group">
		<input id="" type="" id="loginUser" data-type=""  onChange={(e) => setUsername(e.target.value)} value={username}  />
        <label for="loginUser">UserName</label>
      </div>




      <div class="input-group">
		<input id="pass" type="password" id="loginPassword" data-type="password"  onChange={(e) => setPassword(e.target.value)} value={password}  />
        <label for="loginPassword">Password</label>
      </div>

      {/* <div class="input-group">
		<input id="pass" type="password" id="loginPassword" data-type="password"  onChange={(e) => setcon(e.target.value)} value={con}  />
        <label for="loginPassword"> Confirm Password</label>
      </div> */}


      <div class="input-group">
		<input id="pass" type="" id="loginUser" data-type=""  onChange={(e) => setFirstName(e.target.value)} value={firstname}  />
        <label for="loginPassword">FirstName</label>
      </div>


      <div class="input-group">
		<input id="pass" type="" id="loginUser" data-type=""  onChange={(e) => setLastName(e.target.value)} value={lastname}  />
        <label for="loginPassword">LastName</label>
      </div>


      <div class="input-group">
      {/* {validationssss..map((error, index) => {
              return (

                <p  key={index} style = {{color: "#f7816d;"}}>  {index}  </p>

                )
              })
              } */}
 </div>
{/* <div>
{errors.map(item => <p key={item.id} name={item.name} > </p>)} 

 </div> */}



	  <div className = "btnflex">
      <input type="submit" value="Siugn up" class="submit-btn"   onClick={handleSubmit} />
	  <Link className="buttonflex" to="/login" >Log in</Link>
	  </div> 
    
    <p  className = "error">  {validations}</p>

      {/* <a href="#forgot-pw" class="forgot-pw">Forgot Password?</a> */}
     </form>
  </div>  
  </div>
  </div>
        </>
    );
};

export default Register;