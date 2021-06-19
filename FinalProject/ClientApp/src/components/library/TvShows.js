import React, {useEffect, useState} from 'react';
import axios from "axios";
import {useHistory} from "react-router-dom";
import EditTvShow from "./Edit/EditTvShow";

function TvShows(props) {
    const [tvShowList, setTvShowList] = useState([]);
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
        axios.get("https://localhost:5001/api/tvshows", {
            withCredentials: true
        })
            .then(res => {
                setLoading(false)
                setTvShowList(res.data.list)
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
        axios.post(`https://localhost:5001/api/favoritetvshows/${id}`, {}, {
            withCredentials: true
        })
            .then(res => {
                console.log(res);
                getList();
                getProfile()
            }).catch(err => console.log(err));
    }

    const deleteFromFav = (id) => {
        axios.delete(`https://localhost:5001/api/favoritetvshows/${id}`, {
            withCredentials: true
        })
            .then(res => {
                console.log(res);
                getList();
                getProfile();
            })
            .catch(err => console.log(err));
    }
    
    const editTvShow = (id) => {
        history.push(`/edit-tvshow/${id}`, { id: id })
    }

    const infoTvShow = (id) => {
        history.push(`/tvshow-info/${id}`, { id: id })
    }

    const redirect = (num) => {
        if(num === 1){
            history.push("/add-new-tvshow");
        } else {
            history.push("/search-tvshow");
        }
    }

    if (Object.keys(user).length > 0) {
        addAndSearch = (
            <div>
                <button onClick={()=>redirect(1)} className="btn btn-success " style={{marginTop: "30px", marginBottom: "10px",}}>Add New TV Show</button>
                <button onClick={()=>redirect(2)} className="btn btn-success " style={{marginTop: "30px", marginBottom: "10px", marginLeft: "15px"}}>Search from Outside</button>
            </div>
        );
    } else {
        addAndSearch = null;
    }


    const renderTvShowListTable = (tvShowList) => {
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
                {tvShowList.map((tvShow, index) =>
                    <tr key={index+1}>
                        <td className="align-middle">{index+1}</td>
                        <td className="align-middle">{tvShow.title}</td>
                        <td className="align-middle">{tvShow.date}</td>
                        <td className="align-middle">{tvShow.summary}</td>
                        <td className="align-middle">{tvShow.rating}</td>
                        <td className="align-middle"><img src={tvShow.poster} height="200px" alt="not supported"/></td>
                        <td className="align-middle">
                            <button onClick={() => infoTvShow(tvShow.id)} className="btn btn-info myBtn" style={{marginBottom: "20px"}}>Info</button>
                            {user.name ? <div>
                                {(user.profile.tvShow !== null && user.profile.tvShow.find(tv => tv.id == tvShow.id)) || user.profile.id == 1
                                ? <button onClick={() => editTvShow(tvShow.id)} className="btn btn-light myBtn" style={{marginBottom: "20px"}}>Edit</button> : null }
                                {user.profile.favoriteTvShow !== null && user.profile.favoriteTvShow.find(fav => fav.tvShowId == tvShow.id)
                                    ? <button onClick={() => deleteFromFav(tvShow.id)}
                                              className="btn btn-danger myBtn">Delete From Favorite</button>
                                    // : <button onClick={() => addToFav(movie.id)} className="btn btn-primary">Add</button>
                                    : <button onClick={() => addToFav(tvShow.id)} className="btn btn-primary myBtn">Add To Favorite</button>
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
        : renderTvShowListTable(tvShowList);

    return (
        <div className="fade-me">
            <h1 id="tabelLabel" style={{textAlign: "center"}}>TV Shows List</h1>
            {addAndSearch}
            {contents}
        </div>
    );
}

export default TvShows;