import React, {useEffect, useState} from 'react';
import axios from "axios";

function MovieInfo(props) {

    const [movie, setMovie] = useState({});

    useEffect(() => {
        axios.get(`https://localhost:5001/api/movies/${props.location.state.id}`)
            .then(res => {
                const list = res.data;
                setMovie(list);
            }).catch(err => {
            console.log(err)
        })
        return () => {
        }
    }, [])
    
    
    return (
        <div className="container fade-me">
            <div className="main-body">
                <nav
                    aria-label="breadcrumb"
                    className="main-breadcrumb"
    
                >
                    <ol className="breadcrumb" style={{ backgroundColor: "#191919" }}>
                        <h1>{movie? movie.title : null}</h1>
                    </ol>
                </nav>
    
                <div className="row gutters-sm" >
                    <div className="col-md-4 mb-3">
                        <div className="card">
                            <div className="card-body" style={{ backgroundColor: "#191919" }}>
                                <div className="d-flex flex-column align-items-center text-center">
                                    {movie? <img src={movie.poster}/> : null}
                                    <div className="mt-3">
                                        {/*<h4>{props.user.name}</h4>*/}
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div className="col-md-8">
                        <div className="card mb-3">
                            <div className="card-body" style={{ backgroundColor: "#191919" }}>
                                <div className="row">
                                    <div className="col-sm-4">
                                        <h6 className="mb-0">Title</h6>
                                    </div>
                                    <div className="col-sm-8 text-secondary">
                                        {movie? movie.title : null}
                                    </div>
                                </div>
                                <hr />
                                <div className="row">
                                    <div className="col-sm-4">
                                        <h6 className="mb-0">Date</h6>
                                    </div>
                                    <div className="col-sm-8 text-secondary">
                                        {movie? movie.date : null}
                                    </div>
                                </div>
                                <hr />
                                <div className="row">
                                    <div className="col-sm-4">
                                        <h6 className="mb-0">Summary</h6>
                                    </div>
                                    <div className="col-sm-8 text-secondary">
                                        {movie? movie.summary : null}
                                    </div>
                                </div>
                                <hr />
                                <div className="row">
                                    <div className="col-sm-4">
                                        <h6 className="mb-0">Rating</h6>
                                    </div>
                                    <div className="col-sm-8 text-secondary">
                                        {movie? movie.rating : null}
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    );
}

export default MovieInfo;