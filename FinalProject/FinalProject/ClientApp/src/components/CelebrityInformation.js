import React, { useState, useEffect } from 'react'
import axios from 'axios'
import {
    BrowserRouter as Router,
    Switch,
    Route,
    Link
} from "react-router-dom";
import Header from './Header';
export default function CelebrityInformation(props) {

    const [CelebrityInfo, setCelebrityInfo] = useState({})
    useEffect(() => {

        axios({
            method: "get",
            url: "https://localhost:5001/api/Celebrities/" + props.match.params.id
        }).then((response) => {
            //this.setState({ questions: [...response.data] })
            setCelebrityInfo(response.data)
            console.log("props", response.data);
        }).catch((e) => {
            console.log("error", e);
        })

    }, [])

    const handleData = (e) => {



    }

    return (
        
        <div>
            <Header  />
        <div className=" mb-3 text-center " style={{maxWidth: 80 + '%'}} id="c-card">
  <div className="row g-0 ">
    <div className="col-md-4">
    <video height="500xp" width="300px" src={CelebrityInfo.introductionVideo} controls></video>
    </div>
    <div className="col-md-8">
      <div className="card-body">
        <h5 className="card-title">{CelebrityInfo.name}</h5>
        <p className="card-text">{CelebrityInfo.description}</p>
        <p className="card-text"><small class="text-muted">Last updated 3 mins ago</small></p>
        <button  className="btn btn-dark">  <Link to={{ pathname: `/Celebrities/${CelebrityInfo.id}/Book`,query: { CelebrityInfo:CelebrityInfo } }}  >Request video</Link>  </button>
      </div>
    </div>
  </div>
</div>
        </div>
    )
}
