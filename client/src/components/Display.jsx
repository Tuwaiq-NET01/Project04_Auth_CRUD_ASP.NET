import React, { useState,useEffect } from 'react';
import { Router, Link, navigate } from '@reach/router';
import axios from 'axios';

function Display(props) {



  const [allBookings, setAllBookings] = useState([]);

  useEffect(() => {
 
    getAll();
},[ ]);


const getAll = () => {
     
  console.log("handle submit")

  axios.get(`https://localhost:44364/api/TourBookings/${props.pk}`)
    .then((res) => {
      console.log(res.data)
      setAllBookings(res.data)
    })
    .catch((error) => {
      console.error(error)
    })
   
}




const deleteBooking  = (tourId) => {
  console.log("handle delete")
  axios.delete(`https://localhost:44364/api/Bookings/${tourId}/`)
    .then((res) => {
      window.location.reload( );
  
    })
    .catch((error) => {
      console.error(error)
    })   
}



const approve  = (tourId) => {
  console.log("handle approve")
  axios.put(`https://localhost:44364/api/Bookings/aprove/${tourId}/`)
    .then((res) => {
      window.location.reload( );
  
    })
    .catch((error) => {
      console.error(error)
    })   
}

  return (
    <div>
      
<nav class="navbar blue navbar-expand-md  ">
  
  <div class="navbar-collapse collapse" id="navbar4">
      <ul class="navbar-nav">
       
          <li className="nav-item"><Link className ="nav-link pr-3 nav-item-home" to="/">Home </Link></li> 
   
          <li className="nav-item"><Link className ="nav-link pr-3 nav-item-home" to="/addTour">Add a new tour </Link></li>
          {/* <li className="nav-item"><Link className ="nav-link pr-3 nav-item-home" to="/test">test </Link></li> */}
          <li className="nav-item"><Link className ="nav-link pr-3 nav-item-home" to="/Dashboard">Dashboard </Link></li>

      </ul>
  </div>
</nav>







<div className="container">
      {/* <CharNavbar />  */}

        <table className="table table-striped" >
      <tbody>
        <tr className="bg-dark text-light">
        <th>Booking</th>
        <th>Actions</th>
        <th></th>

        </tr>
        {allBookings.map((b,i)=>{
  return(    
<tr >
<td>{b.firstName}  {b.lastName}   {b.total}</td>
<td>
<button className="btn btn-outline-danger btn-sm"  onClick={()=>deleteBooking(b.id)} >Cancel </button>
</td> 


{/* &nbsp;

&nbsp; */}
{/* {b.status === true && <p> pickUp and Drop yes </p>} */}

<td>

{b.status ? <p className="">approved</p> : <button className="btn btn-outline-success btn-sm"  onClick={()=>approve(b.id)} >Approve </button>
}
</td>

</tr>
  )
})
}    
      </tbody>
    </table>

      </div>

    </div>
  );
}

export default Display;