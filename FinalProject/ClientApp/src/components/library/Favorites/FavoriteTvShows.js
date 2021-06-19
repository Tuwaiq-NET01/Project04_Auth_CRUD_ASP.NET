import React, {useEffect, useState} from 'react';
import axios from "axios";

function FavoriteTvShows(props) {
    
    const [favTvShowList, setTvShowList] = useState([]);
    const [user, setUser] = useState({});
    const [loading, setLoading] = useState(true);


    useEffect(() => {
        getList()
        getProfile()
        return () => {

        };
    },[]);

    const getList = () => {
        axios.get("https://localhost:5001/api/favoritetvshows", {
            withCredentials: true
        })
            .then(res => {
                setLoading(false)
                console.log(res.data)
                setTvShowList(res.data)
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
        axios.delete(`https://localhost:5001/api/favoritetvshows/${id}`, {
            withCredentials: true,
        })
            .then(res => {
                console.log(res);
                getList();
                getProfile();
            })
            .catch(err => console.log(err));
    }


    const renderFavTvShowTable = (favTvShowList) => {
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
                {favTvShowList.map((favTvShow, index) =>
                    <tr key={index+1}>
                        <td className="align-middle">{index+1}</td>
                        <td className="align-middle">{favTvShow.tvShow.title}</td>
                        <td className="align-middle">{favTvShow.tvShow.date}</td>
                        <td className="align-middle">{favTvShow.tvShow.summary}</td>
                        <td className="align-middle">{favTvShow.tvShow.rating}</td>
                        <td className="align-middle"><img src={favTvShow.tvShow.poster} height="200px" alt="not supported"/></td>
                        <td className="align-middle">
                            <button onClick={() => deleteFromFav(favTvShow.tvShow.id)} className="btn btn-danger">Delete</button>
                        </td>
                    </tr>
                )}
                </tbody>
            </table>
        );
    }

    let contents = loading
        ? <p><em>Loading...</em></p>
        : renderFavTvShowTable(favTvShowList);

    return (
        <div className="fade-me">
            {contents}
        </div>
    );
}

export default FavoriteTvShows;