import React, {useState} from 'react';
import {useHistory} from 'react-router-dom';

import axios from "axios";

function AddNewTvShow(props) {
    
    const [title, setTitle] = useState("");
    const [date, setDate] = useState("");
    const [summary, setSummary] = useState("");
    const [rating, setRating] = useState(0);
    const [poster, setPoster] = useState("");
    const [loading, setLoading] = useState(true);

    const history = useHistory();

    const titleOnChange = (event) => {
        setTitle(event.target.value)
    }

    const dateOnChange = (event) => {
        setDate(event.target.value);
    }

    const summaryOnChange = (event) => {
        setSummary(event.target.value);
    }

    const ratingOnChange = (event) => {
        let rating = parseInt(event.target.value, 10)
        if (rating > 10 || rating < 1 || isNaN(rating)){
            rating = 5
        }
        setRating(rating)
    }

    const posterOnChange = (event) => {
        setPoster(event.target.value)
    }

    const submit = () => {
        axios.post("https://localhost:5001/api/tvshows", {
            title: title,
            date: date,
            summary: summary,
            rating: rating,
            poster: poster,
        }, {
            withCredentials: true
        }).then(res => {
            console.log(res);
            history.push("/tv-shows");

        }).catch(err => console.log(err));
    }

    return (
        <div className="fade-me">
            <div
                className="card"
                style={{
                    width: "40rem",
                    margin: "0 auto",
                    marginTop: "10em",
                    textAlign: "left",
                    padding: "3em",
                    backgroundColor: "#1c212a"
                }}
            >
                <div className="mb-3">
                    <label htmlFor="title" className="form-label">
                        Title
                    </label>
                    <input
                        type="text"
                        className="form-control"
                        id="title"
                        aria-describedby="titleHelp"
                        onChange={titleOnChange}
                    />
                </div>
                <div className="mb-3">
                    <label htmlFor="date" className="form-label">
                        Date
                    </label>
                    <input
                        type="date"
                        className="form-control"
                        id="date"
                        onChange={dateOnChange}
                    />
                </div>
                <div className="mb-3">
                    <label htmlFor="summary" className="form-label">
                        Summary
                    </label>
                    <textarea
                        rows="3"
                        className="form-control"
                        id="summary"
                        onChange={summaryOnChange}
                    />
                </div>
                <div className="mb-3">
                    <label htmlFor="rating" className="form-label">
                        Rating
                    </label>
                    <input
                        type="number"
                        className="form-control"
                        id="rating"
                        min="1"
                        max="10"
                        onChange={ratingOnChange}
                    />
                </div>
                <div className="mb-3">
                    <label htmlFor="poster" className="form-label">
                        Poster
                    </label>
                    <input
                        type="text"
                        className="form-control"
                        id="poster"
                        onChange={posterOnChange}
                    />
                </div>
                <div className="mb-3 form-check">
                    <input
                        type="checkbox"
                        className="form-check-input"
                        id="exampleCheck1"
                    />
                    <label className="form-check-label" htmlFor="exampleCheck1">
                        Check me out
                    </label>
                </div>
                <button type="submit" onClick={submit} className="btn btn-primary">
                    Submit
                </button>
            </div>
        </div>
    );
}

export default AddNewTvShow;