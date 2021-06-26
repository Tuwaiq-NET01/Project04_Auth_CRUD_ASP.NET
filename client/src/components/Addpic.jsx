import Storage from './Storage';
import CharNavbar from './CharNavbar'
import React ,{useEffect, useState} from 'react';
import axios from 'axios';
import { Router, Link, navigate } from '@reach/router';
import Authenticatiion from './Auth';

function Addpic(props) {

    if (!Authenticatiion.IsUserLoggedIn()) {

        navigate("/login");
    
        console.log("User is not loged in");
        //redirect to login
      }
    
    

    const [imageFile, setImage]                  = useState(null)  //  done
    const [tourID, setTourId]                    = useState(props.pk)  // 
    const [msg, setMessageSubmit] = useState("") //

    const formData = new FormData()
    formData.append('imageFile', imageFile)
    formData.append('id', tourID)

    const getToken = () => {
        return Storage.get("token")
    };

    
    const handleImage = (e) => {
        e.preventDefault();
        console.log("handle submit")

        axios.put('https://localhost:44364/api/Tours/img/?format=json', formData, {
            headers: {
                "Authorization": `Bearer ${getToken()}`
            }
        }).then((res) => {

            console.log("submitted");

            setMessageSubmit("submitted")

            alert("submitted");


          //  navigate("/dashboard");
        })
            .catch((err) => setMessageSubmit("Not Submitted2")
            )
    }
    return (
        <>




            <CharNavbar />

            <div className="Dbody" >
                <div className="Dcontainer">
                    <div className="Dform">
                        <div className="header">
                            <h1> Would like add a picture!   </h1>
                        </div>
                        <form>
                          
                           
                    <div class="form-group row">
                        <div class="col-sm-10">
                                        <input id="image-uploader" class="form-control-file" type="file" accept="image/*" onChange={(e) => setImage(e.target.files[0])} />
                                    </div>
                            </div>
                            <button className="btn btn-info" id="" type='submit' onClick={handleImage}>submit</button>

                            <p>{msg}</p>
                        </form>
                    </div>
                </div>
            </div>



        </>
    );
}

export default Addpic;