import React, {useEffect, useState} from 'react';
import axios from "axios";
import {Link, useHistory} from "react-router-dom";
import {NavItem, NavLink} from "reactstrap";

function Movies(props) {

    const [movieList, setMovieList] = useState([]);
    const [user, setUser] = useState({});
    const [loading, setLoading] = useState(true);

    const history = useHistory();

    let addAndSearch;
    
    useEffect(() => {
        getList()
        // setUser(props.user)
        getProfile()
        return () => {
            
        };
    },[]);

    const getList = () => {
        axios.get("https://localhost:5001/api/Movies", {
            withCredentials: true
        })
            .then(res => {
                setLoading(false)
                setMovieList(res.data.list)
            })
            .catch(err => console.log(err))
    }
    
    const getProfile = () => {
        axios.get("https://localhost:5001/api/auth/user", {
            withCredentials: true,
        })
            .then((res) => {
                console.log(res)
                setUser(res.data)
            })
            .catch((err) => console.log(err));
    }

    const addToFav = (id) => {
        axios.post(`https://localhost:5001/api/favoritemovies/${id}`, {}, {withCredentials: true})
            .then(res => {
            console.log(res);
            getList();
            getProfile()
        }).catch(err => console.log(err));
    }

    const deleteFromFav = (id) => {
        axios.delete(`https://localhost:5001/api/favoritemovies/${id}`, {
            withCredentials: true,
        })
            .then(res => {
                console.log(res);
                getList();
                getProfile();
            })
            .catch(err => console.log(err));
    }

    const EditMovie = (id) => {
        history.push(`/edit-movie/${id}`, { id: id })
    }
    
    const infoMovie = (id) => {
        history.push(`/movie-info/${id}`, { id: id })
    }

    const redirect = (num) => {
        if(num === 1){
            history.push("/add-new-movie");
        } else {
            history.push("/search-movie");
        }
    }

    if (Object.keys(user).length > 0) {
        addAndSearch = (
            <div>
                <button onClick={()=>redirect(1)} className="btn btn-success " style={{marginTop: "30px", marginBottom: "10px",}}>Add New Movie</button>
                <button onClick={()=>redirect(2)} className="btn btn-success " style={{marginTop: "30px", marginBottom: "10px", marginLeft: "15px"}}>Search from Outside</button>
            </div>
        );
    } else {
        addAndSearch = null;
    }
    

    const renderMoviesTable = (movieList) => {
        return (
            <table className='table table-striped table-hover table-dark' aria-labelledby="tabelLabel">
                <thead>
                <tr>
                    <th>#</th>
                    <th>Title</th>
                    <th>Date</th>
                    <th>Summary</th>
                    <th>Rating</th>
                    <th>Poster</th>
                    <th>Action</th>
                </tr>
                </thead>
                <tbody>
                {movieList.map((movie, index) =>
                    <tr key={index+1}>
                        <td className="align-middle">{index+1}</td>
                        <td className="align-middle">{movie.title}</td>
                        <td className="align-middle">{movie.date}</td>
                        <td className="align-middle">{movie.summary}</td>
                        <td className="align-middle">{movie.rating}</td>
                        <td className="align-middle"><img src={movie.poster} height="200px" alt="not supported"/></td>
                        <td className="align-middle">
                            <button onClick={() => infoMovie(movie.id)} className="btn btn-info myBtn" style={{marginBottom: "20px"}}>Info</button>
                            {user.name ? <div>
                                
                                {(user.profile.movie !== null && user.profile.movie.find(mov => mov.id == movie.id)) || user.profile.id == 1
                                    ? <button onClick={() => EditMovie(movie.id)} className="btn btn-light myBtn" style={{marginBottom: "20px"}}>Edit</button> : null }
                                {user.profile.favoriteMovie !== null && user.profile.favoriteMovie.find(fav => fav.movieId == movie.id)
                                    ? <button onClick={() => deleteFromFav(movie.id)}
                                              className="btn btn-danger myBtn">Delete From Favorite</button>
                                    // : <button onClick={() => addToFav(movie.id)} className="btn btn-primary">Add</button>
                                    : <button onClick={() => addToFav(movie.id)} className="btn btn-primary myBtn">Add To Favorite</button>
                                }
                            </div> : null
                            }

                        </td>
                    </tr>
                )}
                </tbody>
            </table>
        );
    }

    let contents = loading
        ? <p><em>Loading...</em></p>
        : renderMoviesTable(movieList);
        
    return (
        <div className="fade-me">
            <h1 id="tabelLabel" style={{textAlign: "center"}}>Movies List</h1>
            {addAndSearch}
            {contents}
        </div>
    );
}

export default Movies;