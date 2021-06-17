import React, { useState, useEffect } from 'react'
import axios from 'axios'
import {
    BrowserRouter as Router,
    Switch,
    Route,
    Link
} from "react-router-dom";
export default function CelebrityInformation(props) {

    const [CelebrityInfo, setCelebrityInfo] = useState({})
    useEffect(() => {

        axios({
            method: "get",
            url: "https://localhost:5001/api/Celebrities/" + props.match.params.id
        }).then((response) => {
            //this.setState({ questions: [...response.data] })
            setCelebrityInfo(response.data)
            console.log("props", props);
        }).catch((e) => {
            console.log("error", e);
        })

    }, [])

    const handleData = (e) => {



    }

    return (

        <div>
            <h1>{CelebrityInfo.name}</h1>
            <video height="500xp" src={CelebrityInfo.introductionVideo} controls></video>
            <br />

            {/* <Link to={{
                pathname: `/blog/${post.id}`,
                query: {
                    title: post.title,
                    content: post.content,
                    comments: JSON.stringify(post.comments)
                }
            }}>Read More...</Link> */}
                 
            <button  >  <Link to={{ pathname: `/Celebrities/${CelebrityInfo.id}/Book`,query: { CelebrityInfo:CelebrityInfo } }}  >Request video</Link>  </button>
        </div>
    )
}
