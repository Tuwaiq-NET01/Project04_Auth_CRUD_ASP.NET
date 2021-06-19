import React, {useEffect, useState} from 'react';
import axios from "axios";

function FavoriteMovies(props) {
    const [favMovieList, setFavMovieList] = useState([]);
    const [user, setUser] = useState({});
    const [loading, setLoading] = useState(true);


    useEffect(() => {
        getList()
        getProfile()
        return () => {

        };
    },[]);

    const getList = () => {
        axios.get("https://localhost:5001/api/FavoriteMovies", {
            withCredentials: true
        })
            .then(res => {
                setLoading(false)
                console.log(res.data)
                setFavMovieList(res.data)
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


    const renderFavMoviesTable = (favMovieList) => {
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
                {user.profile && user.profile.favoriteMovie? 
                favMovieList.map((favMovie, index) =>
                    <tr key={index+1}>
                        <td className="align-middle">{index+1}</td>
                        <td className="align-middle">{favMovie.movie.title}</td>
                        <td className="align-middle">{favMovie.movie.date}</td>
                        <td className="align-middle">{favMovie.movie.summary}</td>
                        <td className="align-middle">{favMovie.movie.rating}</td>
                        <td className="align-middle"><img src={favMovie.movie.poster} height="200px" alt="not supported"/></td>
                        <td className="align-middle">
                            <button onClick={() => deleteFromFav(favMovie.movie.id)} className="btn btn-danger">Delete</button>
                        </td>
                    </tr>
                ) : null }
                </tbody>
            </table>
        );
    }

    let contents = loading
        ? <p><em>Loading...</em></p>
        : renderFavMoviesTable(favMovieList);

    return (
        <div className="fade-me">
            <h1 id="tabelLabel" style={{textAlign: "center", marginBottom: "60px"}}>Favorite Movies List</h1>
            {contents}
        </div>
    );
}

export default FavoriteMovies;