import React ,{useEffect, useState} from 'react';
import './details.css';
import axios from 'axios';
import { Router, Link, navigate } from '@reach/router';
import Authenticatiion from './Auth';
import Storage from './Storage';
import CharNavbar from './CharNavbar'
  
  
const AddTour = (props) => {

    
  if (!Authenticatiion.IsUserLoggedIn()) {

    navigate("/login");

    console.log("User is not loged in");
    //redirect to login
  }



    const [place, setPlace]                      = useState("")  //  done    
    const [description, setDescription]          = useState("")  //  done
    const [adultPrice, setAdultPrice]            = useState("")  //  done
    const [childPrice, setChildPrice]            = useState("")  //  done
    const [pickupLocation, setPickupLocation]    = useState("")  //  done
    const [returnsAt, setReturnsAt]              = useState("")  //  done
    const [departsAt, setDepartsAt]              = useState("")  //  done  
 //   const [image, setImage]                      = useState("")  //  done
    const [imageFile, setImage] = useState(null)  //  done

    const [tourGuide, setTourGuide]              = useState(false)  //      
    const [transport, setTransport]              = useState(false)  //     
    const [entiranceFees, setEntiranceFees]      = useState(false)  //    
    const [pickUpAndDrop, setPickUpAndDrop]      = useState(false)  //    
    const [food, setFood]                        = useState(false)  //     
    // const [tourId, setTourId]                    = useState(props.pk)  // 
    const [msg, setMessageSubmit]                = useState ("") //
    const [tourID, setTourId]                     = useState ("") //





    const formData = new FormData()
    formData.append('imageFile', imageFile)
    formData.append('id', tourID)



    const getToken = () =>{
        return Storage.get("token")
    };
    
    async function  handleSubmit (e)  {
        e.preventDefault();
        console.log("handle submit")
        // setjwtStr(Storage.get("token"))
        // const config = {
        //     headers: { Authorization: `Bearer ${jwtStr}` }
        // };
        const addPlce=
        {

            "place": place,
            "description": description,
            "adultPrice": adultPrice,
            "childPrice": childPrice,
            "pickupLocation": pickupLocation,
            "returnsAt": returnsAt,
            "departsAt": departsAt,
        
          
            "included": {
           
              "tourGuide": tourGuide,
              "transport": transport,
              "entiranceFees": entiranceFees,
              "pickUpAndDrop": pickUpAndDrop,
              "food": food
          
          
             
            }}
          
           
            
       
           axios
          .post('https://localhost:44364/api/Tours/?format=json',addPlce, 
          {headers: {
            "Authorization": `Bearer ${getToken()}`
        }}). then ((res) => {
          setMessageSubmit("submitted")
            setTourId(res.data.tourId)
            formData.append('id', res.data.tourId)
         console.log("the  id", res.data.tourId)
     
         navigate(`/addpic/${res.data.tourId}`);

        } )
        
            .catch((err) => console.log(err) )


               

             


           

    }



const handleImage =()=>{

    axios.put('https://localhost:44364/api/Tours/img/?format=json',formData, {headers: {
        "Authorization": `Bearer ${getToken()}`
    }}).then((res) => {
        
        
        console.log("submitted2");
        
        setMessageSubmit("submitted2")
    
        navigate("/dashboard");
    })

        
        .catch((err) =>  setMessageSubmit("Not Submitted2")
    )



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
                    <form   onSubmit = {handleSubmit}>
                <div className="inputcontainer">
                    <div class="form-group row">
                        <label for="" class="col-sm-2 col-form-label">place</label>
                        <div class="col-sm-10">
                            <input type="text" class="form-control" id="" onChange = {(e)=>setPlace(e.target.value)}  required />
                        </div>
                    </div>
                
                    <div class="form-group row">
                        <label for="" class="col-sm-2 col-form-label">description</label>
                        <div class="col-sm-10">
                            <textarea  rows="4" class="form-control" cols="30" onChange = {(e)=>setDescription(e.target.value)}  required ></textarea>
                        </div>
                    </div>

                    <div class="form-group row">
                        <label for="" class="col-sm-2 col-form-label"> adult price</label>
                        <div class="col-sm-10">
                            <input type="number" class="form-control" id="" onChange = {(e)=>setAdultPrice(e.target.value)}  required />
                    </div>
                    </div>

                    <div class="form-group row">
                        <label for="" class="col-sm-2 col-form-label"> child price</label>
                        <div class="col-sm-10">
                            <input type="number" class="form-control" id="" onChange = {(e)=>setChildPrice(e.target.value)}  required />
                    </div>
                    </div>

                    
                    <div class="form-group row">
                        <label for="" class="col-sm-2 col-form-label"> Departs</label>
                        <div class="col-sm-10">
                            <input type="datetime-local" class="form-control" id="" onChange = {(e)=>setDepartsAt(e.target.value)}  required />
                    </div>


                    </div>
                    <div class="form-group row">
                        <label for="" class="col-sm-2 col-form-label"> Returns</label>
                        <div class="col-sm-10">
                            <input type="datetime-local" class="form-control" id="" onChange = {(e)=>setReturnsAt(e.target.value)} required />
                    </div>
                    </div>

                    {/* <div class="form-group row">
                        <label for="" class="col-sm-2 col-form-label"> Image</label>
                        <div class="col-sm-10">
                            <input type="text" class="form-control" id="" onChange = {(e)=>setImage(e.target.value)}  />
                    </div>
                    </div> */}
                    <div class="form-group row">
                        <label for="" class="col-sm-2 col-form-label"> Pickup Location</label>
                        <div class="col-sm-10">
                            <input type="text" class="form-control" id="" onChange = {(e)=>setPickupLocation(e.target.value)} required />
                    </div>
                    </div>


                 

              

                    <div class="">
                        <label for="" class="col-sm-2 col-form-label"> Tour Guide </label>
                     <div class="form-check form-check-inline">
                        <input class="form-check-input" type="radio" name="inlineRadioOptions" id="inlineRadio1" onChange = {(e)=>setTourGuide(true)}  />
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
                   
                
                <button className="btn mb-4  btn-lg btn-block" id = "Charbtn" type='submit' >Next</button>

                <div class="form-group row">
                                    <div class="col-sm-10">
                                    {/* <input id="image-uploader" class="form-control-file" type="file" accept="image/*" onChange={(e) => setImage(e.target.files[0])}/> */}
                                    </div>
                    </div>
                    {/* <button className="btn mb-4  btn-lg btn-block" id = "Charbtn" type='submit' onClick = {handleImage}>submit</button> */}

            </div>

            <p>{msg}</p>
            </form>
            </div>
            </div>
        </div> 
        </>
    );
};

export default AddTour;