import React ,{useEffect, useState} from 'react';
import './details.css';
import axios from 'axios';
import { Router, Link, navigate } from '@reach/router';
import Storage from './Storage';
import CharNavbar from './CharNavbar'



   
  
const Update = (props) => {

    const [place, setPlace]                      = useState("")  //  done    
    const [description, setDescription]          = useState("")  //  done
    const [adultPrice, setAdultPrice]            = useState("")  //  done
    const [childPrice, setChildPrice]            = useState("")  //  done
    const [pickupLocation, setPickupLocation]    = useState("")  //  done
    const [returnsAt, setReturnsAt]              = useState("")  //  done
    const [departsAt, setDepartsAt]              = useState("")  //  done  
    const [image, setImage]                      = useState("")  //  done


    const [tourGuide, setTourGuide]              = useState("")  //      
    const [transport, setTransport]              = useState("")  //     
    const [entiranceFees, setEntiranceFees]      = useState("")  //    
    const [pickUpAndDrop, setPickUpAndDrop]      = useState("")  //    
    const [food, setFood]                        = useState("")  //     
    const [tourId, setTourId]                    = useState(props.pk)  // 
    const [msg, setMessageSubmit]                = useState ("") //




    useEffect(() => {
        getData()
    },[ ]);
    
    const getToken = () =>{
        return Storage.get("token")
    };

    const getData=()=>{
        axios
        .get(`https://localhost:44364/api/Tours/${tourId}/?format=json`, {headers: {
            "Authorization": `Bearer ${getToken()}`
        }})
        .then((res) => {
       console.log(res.data)
     setPlace(res.data.place)                     
    setDescription(res.data.description)        
    setAdultPrice(res.data.adultPrice)         
    setChildPrice(res.data.childPrice)          
    setPickupLocation(res.data.pickupLocation) 
    setReturnsAt(res.data.returnsAt)          
    setDepartsAt(res.data.departsAt)      
    setImage(res.data.image) 
          })
        .catch((err) => console.error(err));
      }






     
    const handleSubmit = (e) => {
        e.preventDefault();
        console.log("handle submit")
        // setjwtStr(Storage.get("token"))
        // const config = {
        //     headers: { Authorization: `Bearer ${jwtStr}` }
        // };
        const updatedData=
        {

            "place": place,
            "description": description,
            "adultPrice": adultPrice,
            "childPrice": childPrice,
            "pickupLocation": pickupLocation,
            "returnsAt": returnsAt,
            "departsAt": departsAt,
            "image": image,
          
            "included": {
           
              "tourGuide": tourGuide,
              "transport": transport,
              "entiranceFees": entiranceFees,
              "pickUpAndDrop": pickUpAndDrop,
              "food": food
          
          
             
            }
          
           
            
          }
     
         
        
      
        axios
          .put(`https://localhost:44364/api/Tours/${tourId}/?format=json`,updatedData, {headers: {
            "Authorization": `Bearer ${getToken()}`
        }})
          .then((res) => {
          setMessageSubmit(" submitted") } )
            .catch((err) =>  setMessageSubmit("Not Submitted")
            );
    }


    return (
        <>
 <CharNavbar />


           <div className = "Dbody" > 
            <div className = "Dcontainer">
                <div className="Dform">
                    <div className="header">
                    <h1>Welcome!</h1>
                            <p>Please provide the place information below.</p>
                    </div> 
                    <form>
                <div className="inputcontainer">
                    <div class="form-group row">
                        <label for="" class="col-sm-2 col-form-label">place</label>
                        <div class="col-sm-10">
                            <input type="text" class="form-control" id="" onChange = {(e)=>setPlace(e.target.value)}   value={place} />
                        </div>
                    </div>
                
                    <div class="form-group row">
                        <label for="" class="col-sm-2 col-form-label">description</label>
                        <div class="col-sm-10">
                            <textarea  rows="4" class="form-control" cols="30" onChange = {(e)=>setDescription(e.target.value)} value={description} ></textarea>
                        </div>
                    </div>

                    <div class="form-group row">
                        <label for="" class="col-sm-2 col-form-label"> adult price</label>
                        <div class="col-sm-10">
                            <input type="number" class="form-control" id="" onChange = {(e)=>setAdultPrice(e.target.value)}   value={adultPrice} />
                    </div>
                    </div>

                    <div class="form-group row">
                        <label for="" class="col-sm-2 col-form-label"> child price</label>
                        <div class="col-sm-10">
                            <input type="number" class="form-control" id="" onChange = {(e)=>setChildPrice(e.target.value)}   value={childPrice} />
                    </div>
                    </div>

                    
                    <div class="form-group row">
                        <label for="" class="col-sm-2 col-form-label"> Departs</label>
                        <div class="col-sm-10">
                            <input type="datetime-local" class="form-control" id="" onChange = {(e)=>setDepartsAt(e.target.value)}  value={departsAt} />
                    </div>


                    </div>
                    <div class="form-group row">
                        <label for="" class="col-sm-2 col-form-label"> Returns</label>
                        <div class="col-sm-10">
                            <input type="datetime-local" class="form-control" id="" onChange = {(e)=>setReturnsAt(e.target.value)} value={returnsAt} />
                    </div>
                    </div>



                    <div class="form-group row">
                        <label for="" class="col-sm-2 col-form-label"> Image</label>
                        <div class="col-sm-10">
                            <input type="text" class="form-control" id="" onChange = {(e)=>setImage(e.target.value)}  value={image} />
                    </div>
                    </div>
                    <div class="form-group row">
                        <label for="" class="col-sm-2 col-form-label"> Pickup Location</label>
                        <div class="col-sm-10">
                            <input type="text" class="form-control" id="" onChange = {(e)=>setPickupLocation(e.target.value)} value={pickupLocation}  />
                    </div>
                    </div>


                 

              

                    <div class="">
                        <label for="" class="col-sm-2 col-form-label"> Tour Guide </label>
                     <div class="form-check form-check-inline">
                        <input class="form-check-input" type="radio" name="inlineRadioOptions" id="inlineRadio1" onChange = {(e)=>setTourGuide(true)}   />
                        <label class="form-check-label" for="inlineRadio1"> &#9989; </label>
                        </div>
                        <div class="form-check form-check-inline">
                        <input class="form-check-input" type="radio" name="inlineRadioOptions" id="inlineRadio2"  onChange = {(e)=>setTourGuide(false)} />
                        <label class="form-check-label" for="inlineRadio2"> &#10060; </label>
                    </div>
                    </div>


                    
                    <div class="">
                        <label for="" class="col-sm-2 col-form-label"> Transport </label>
                     <div class="form-check form-check-inline">
                        <input class="form-check-input" type="radio" name="Options1" id="inlineRadio1" onChange = {(e)=>setTransport(true)}  />
                        <label class="form-check-label" for="inlineRadio1"> &#9989; </label>
                        </div>
                        <div class="form-check form-check-inline">
                        <input class="form-check-input" type="radio" name="Options1" id="inlineRadio2"  onChange = {(e)=>setTransport(false)} />
                        <label class="form-check-label" for="inlineRadio2"> &#10060; </label>
                    </div>
                    </div>


                    <div class="">
                        <label for="" class="col-sm-2 col-form-label"> Entirance Fees</label>
                     <div class="form-check form-check-inline">
                        <input class="form-check-input" type="radio" name="Options2" id="inlineRadio1" onChange = {(e)=>setEntiranceFees(true)}  />
                        <label class="form-check-label" for="inlineRadio1"> &#9989; </label>
                        </div>
                        <div class="form-check form-check-inline">
                        <input class="form-check-input" type="radio" name="Options2" id="inlineRadio2"  onChange = {(e)=>setEntiranceFees(false)} />
                        <label class="form-check-label" for="inlineRadio2"> &#10060; </label>
                    </div>
                    </div>


                    <div class="">
                        <label for="" class="col-sm-2 col-form-label"> PickUp And Drop</label>
                     <div class="form-check form-check-inline">
                        <input class="form-check-input" type="radio" name="Options3" id="inlineRadio1" onChange = {(e)=>setPickUpAndDrop(true)}  />
                        <label class="form-check-label" for="inlineRadio1"> &#9989; </label>
                        </div>
                        <div class="form-check form-check-inline">
                        <input class="form-check-input" type="radio" name="Options3" id="inlineRadio2"  onChange = {(e)=>setPickUpAndDrop(false)} />
                        <label class="form-check-label" for="inlineRadio2"> &#10060; </label>
                    </div>
                    </div>
                    
                    <div class="">
                        <label for="" class="col-sm-2 col-form-label"> Food</label>
                     <div class="form-check form-check-inline">
                        <input class="form-check-input" type="radio" name="Options4" id="inlineRadio1" onChange = {(e)=>setFood(true)}  />
                        <label class="form-check-label" for="inlineRadio1"> &#9989; </label>
                        </div>
                        <div class="form-check form-check-inline">
                        <input class="form-check-input" type="radio" name="Options4" id="inlineRadio2"  onChange = {(e)=>setFood(false)} />
                        <label class="form-check-label" for="inlineRadio2"> &#10060; </label>
                    </div>
                    </div>
                   
                
                <button className="btn mb-4  btn-lg btn-block" id = "Charbtn" type='submit' onClick = {handleSubmit}>Update</button>
            </div>
            <p>{msg}</p>
            </form>
            </div>
            </div>
        </div> 
        </>
    );
};

export default Update;