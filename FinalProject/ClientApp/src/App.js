import React, {useEffect, useState} from "react";
import { Route } from "react-router-dom";
import Layout from "./components/Layout";
import Home from "./components/Home";

import "./custom.css";
import Login from "./components/auth/Login";
import Register from "./components/auth/Register";
import axios from "axios";
import Movies from "./components/library/Movies";
import TvShows from "./components/library/TvShows";
import FavoriteMovies from "./components/library/Favorites/FavoriteMovies";
import AddNewMovie from "./components/library/AddPages/AddNewMovie";
import AddNewTvShow from "./components/library/AddPages/AddNewTvShow";
import Profile from "./components/auth/Profile";
import FavoriteTvShows from "./components/library/Favorites/FavoriteTvShows";
import SearchMovieOutside from "./components/library/SearchOutside/SearchMovieOutside";
import SearchTvShowOutside from "./components/library/SearchOutside/SearchTvShowOutside";
import EditMovie from "./components/library/Edit/EditMovie";
import EditTvShow from "./components/library/Edit/EditTvShow";
import MovieInfo from "./components/Info/MovieInfo";
import TvShowInfo from "./components/Info/TvShowInfo";

function App() {
    
    const [user, setUser] = useState({});
    
    useEffect(() => {
        getUser()
        
        return () => {};
        
    }, []);
    
    const getUser = () => {
        axios.get("https://localhost:5001/api/auth/user", {
            withCredentials: true,
        })
            .then((res) => {
                console.log(res)
                setUser(res.data)
            })
            .catch((err) => console.log(err));
    }

    return (
        <Layout user={user} setUser={setUser}>
            <Route exact path="/" component={() => <Home user={user}/>} />
            <Route path="/login" component={() => <Login setUser={setUser}/>} />
            <Route path="/register" component={Register} />
            <Route path="/profile" component={() => <Profile user={user} setUser={setUser}/>} />
            <Route path="/movies" component={() => <Movies user={user}/>} />
            <Route path="/tv-shows" component={() => <TvShows user={user}/>} />
            <Route path="/favorite-movies" component={() => <FavoriteMovies user={user}/>} />
            <Route path="/favorite-tvshow" component={() => <FavoriteTvShows user={user}/>} />
            <Route path="/add-new-movie" component={() => <AddNewMovie user={user}/>} />
            <Route path='/edit-movie' component={EditMovie} />
            <Route path="/add-new-tvshow" component={() => <AddNewTvShow user={user}/>} />
            <Route path='/edit-tvshow' component={EditTvShow} />
            <Route path="/search-movie" component={() => <SearchMovieOutside user={user}/>} />
            <Route path="/search-tvshow" component={() => <SearchTvShowOutside user={user}/>} />
            <Route path="/movie-info" component={MovieInfo} />
            <Route path="/tvshow-info" component={TvShowInfo} />
        </Layout>
    );
}
export default App;
