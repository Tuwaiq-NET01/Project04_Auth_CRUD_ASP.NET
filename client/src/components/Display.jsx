import React, { useState,useEffect } from 'react';
import { Router, Link, navigate } from '@reach/router';
import axios from 'axios';
import CharNavbar from './CharNavbar'
import Storage from './Storage';

function Display(props) {

  



  const [allBookings, setAllBookings] = useState([]);

  useEffect(() => {
 
    getAll();
},[ ]);

const getToken = () =>{
  return Storage.get("token")
};
const getAll = () => {
     
  console.log("handle submit")

  axios.get(`https://localhost:44364/api/TourBookings/${props.pk}`, {
           
    headers: {
        "Authorization": `Bearer ${getToken()}`
    }})
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



const approve  = (id) => {
  console.log("handle approve")
  axios.put(`https://localhost:44364/api/Bookings/aprove/${id}/`,{
           
    headers: {
        "Authorization": `Bearer ${getToken()}`
    }})
    .then((res) => {
      console.log("aproved")
      window.location.reload( );
  
    })
    .catch((error) => {
      console.error(error)
    })   
}

  return (
    <div>
      
<CharNavbar />







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