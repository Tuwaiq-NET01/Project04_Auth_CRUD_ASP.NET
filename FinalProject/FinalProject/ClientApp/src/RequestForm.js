import React, { useState, useEffect } from 'react'
import axios from 'axios'
import { Button } from 'bootstrap'
import Header from './components/Header'
export default function RequestForm(props) {
// import '../custom.css'

    const [From, setFrom] = useState('')
    const [To, setTo] = useState('')
    const [RequestDetails, setRequestDetails] = useState('')
    const [AllowToShare, setAllowToShare] = useState(true)
    //const [state, setstate] = useState(initialState)

    const [CelebrityInfo, setCelebrityInfo] = useState({})
    useEffect(() => {

        axios({
            method: "get",
            url: "https://localhost:5001/api/Celebrities/" + props.match.params.id
        }).then((response) => {
            //this.setState({ questions: [...response.data] })
            setCelebrityInfo(response.data)

        }).catch((e) => {
            console.log("error", e);
        })

    }, [])



    const FromhandleOnChange = (e) => {
        setFrom(e.target.value)
        console.log(e.target.value);
    }

    const TohandleOnChange = (e) => {
        setTo(e.target.value)
        console.log(e.target.value);
    }

    const RequestDetailshandleOnChange = (e) => {
        setRequestDetails(e.target.value)
        console.log(e.target.value);
    }
    const Formsubmit = (e) => {
        e.preventDefault();
        if (From.trim() != "" && To.trim() != "" && RequestDetails.trim() != "") {
            console.log("Wow");
            var e = document.getElementById("ddlViewBy");
            var strUser = e.value;
            console.log(strUser);
            if (strUser)
                setAllowToShare(strUser)
            else
                setAllowToShare(strUser)


            axios({
                method: 'post',
                url: 'https://localhost:5001/api/FanReqeustCelebrity/',
                data: {
                    From: From,
                    To: To,
                    RequstDec:RequestDetails,
                    AllowPubiling:AllowToShare,
                    CelebrityId:CelebrityInfo.id,
                    FanId:1,
                    ReqeustState:"In Progress"
                }
            });

        }
        else {
            console.log("Moew");
        }
    }

    return (
        <div>
            <Header  />
            <div className="container text-center mt-5">
            <img height="100px" id="ImgCic" src={CelebrityInfo.img} alt={CelebrityInfo.name} />
            <h3> Requset {CelebrityInfo.name} for personal video your family, friends  </h3>
            {/* <h1>{props.CelebrityInfo}</h1> */}
            <form>
                <label>
                    From
                    <br />
                    <input type="text" onChange={FromhandleOnChange} />
                </label>
                <br />

                <label>
                    To
                    <br />
                    <input type="text" onChange={TohandleOnChange} />
                </label>

                <br />
                <label>
                    write your request
                 <br />
                    <input type="text" onChange={RequestDetailshandleOnChange} />
                </label>

                <br />
                <label>
                    Share with everyone
                 <br />
                    <select id="ddlViewBy">
                        <option value="ture">
                            Yes
                       </option>
                        <option value="false">
                            No
                       </option>
                    </select>
                </label>

                <br />
                <label>
                    payment method
                 <br />
                    <input type="text" />
                </label>


                <br />

            </form>
            <button onClick={Formsubmit}  >submit</button>

            </div>
        </div>
    )
}
