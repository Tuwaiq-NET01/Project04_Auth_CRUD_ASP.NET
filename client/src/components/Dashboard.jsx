import React, { useState, useEffect } from 'react';
// import CharNavbar from './CharNavbar';
import axios from 'axios';
import { Router, Link, navigate } from '@reach/router';
import Authenticatiion from './Auth';
import Storage from './Storage';
import CharNavbar from './CharNavbar'
const Dashboard = () => {


  if (!Authenticatiion.IsUserLoggedIn()) {

    navigate("/login");

    console.log("User is not loged in");
    //redirect to login
  }
  const [allTours, setallTours] = useState([])
  const [jwtStr, setjwtStr]     = useState('');
  const [config, setConfig]     =  useState();
  useEffect(() => {
  
   console.log(Storage.get("token"))

    getTours();
  }, []);
  


  function logout() {
    Storage.remove("token");
    navigate("/login");
  }

  const getToken = () =>{
    return Storage.get("token")
};

  const getTours = () => {

    console.log("handle fetching data")
    axios.get('https://localhost:44364/api/Tours', {
           
      headers: {
          "Authorization": `Bearer ${getToken()}`
      }})
      .then((res) => {
        console.log(res.data)
        setallTours(res.data)
      })
      .catch((error) => {
        console.error(error)
      })
  }


  const deleteTour = (tourId) => {
    console.log("handle delete")
    axios.delete(`https://localhost:44364/api/Tours/${tourId}/`, {
           
      headers: {
          "Authorization": `Bearer ${getToken()}`
      }})
      .then((res) => {
        window.location.reload();

      })
      .catch((error) => {
        console.error(error)
      })
  }
  return (
    <>

 


      <CharNavbar /> 


      <div className="container">
      <div class="row">
    <div class="col">
    </div>
    
    <div class="col-10">
   
  
        <table className="table table-striped" >
          <tbody>
            <tr className="bg-dark text-light">
              <th>Tour</th>
              <th>Actions</th>
            </tr>
            {allTours.map((tour, i) => {
              return (
                <tr >
                  <td>{tour.place}</td>
                  <td>
                    <button className="btn btn-outline-danger btn-sm" onClick={() => deleteTour(tour.tourId)} >Cancel </button>
                    &nbsp;
                    {/* <Link to={"/" } className="btn btn-sm btn-outline-success">Disply</Link> */}
                    <Link to={`/update/${tour.tourId}`} className="btn btn-outline-success btn-sm"   >  Update  </Link>
                    <Link to={`/display/${tour.tourId}`} className="btn btn-outline-warning btn-sm"    >  Display  </Link>


                  </td>
                </tr>
              )
            })
            }
          </tbody>
        </table>
        </div>
  </div>
      </div>


    </>

  );
};







export default Dashboard