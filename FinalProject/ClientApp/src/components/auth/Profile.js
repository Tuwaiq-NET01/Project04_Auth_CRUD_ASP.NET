import React, { useEffect, useState } from "react";
import { Redirect } from "react-router-dom";

function Profile(props) {
    const [user, setUser] = useState({});

    // useEffect(() => {
    //     setUser(props.user)
    //
    //     return () => {};
    //
    // }, []);

    if (!props.user.profile) {
        console.log("NULL");
    }

    return (
        <div className="container fade-me">
            <div className="main-body">
                <nav
                    aria-label="breadcrumb"
                    className="main-breadcrumb"
                    
                >
                    <ol className="breadcrumb" style={{ backgroundColor: "#191919" }}>
                        <h2>Profile</h2>
                    </ol>
                </nav>

                <div className="row gutters-sm" >
                    <div className="col-md-4 mb-3">
                        <div className="card">
                            <div className="card-body" style={{ backgroundColor: "#191919" }}>
                                <div className="d-flex flex-column align-items-center text-center">
                                    <img
                                        src="https://bootdey.com/img/Content/avatar/avatar7.png"
                                        alt="Admin"
                                        className="rounded-circle"
                                        width="150"
                                    />
                                    <div className="mt-3">
                                        <h4>{props.user.name}</h4>
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
                                        <h6 className="mb-0">Full Name</h6>
                                    </div>
                                    <div className="col-sm-8 text-secondary">
                                        {props.user.name}
                                    </div>
                                </div>
                                <hr />
                                <div className="row">
                                    <div className="col-sm-4">
                                        <h6 className="mb-0">Email</h6>
                                    </div>
                                    <div className="col-sm-8 text-secondary">
                                        {props.user.email}
                                    </div>
                                </div>
                                <hr />
                                <div className="row">
                                    <div className="col-sm-4">
                                        <h6 className="mb-0">Role</h6>
                                    </div>
                                    <div className="col-sm-8 text-secondary">
                                        {props.user.id == 1 ? "Admin" : "User"}
                                    </div>
                                </div>
                                <hr />
                                <div className="row">
                                    <div className="col-sm-4">
                                        <h6 className="mb-0">Joined At</h6>
                                    </div>
                                    <div className="col-sm-8 text-secondary">
                                        {props.user.profile &&
                                        props.user.profile.joinedDateTime
                                            ? props.user.profile.joinedDateTime.split(
                                                  "T"
                                              )[0]
                                            : ""}
                                    </div>
                                </div>
                                <hr />
                                <div className="row">
                                    <div className="col-sm-4">
                                        <h6 className="mb-0">
                                            # of Movies Added
                                        </h6>
                                    </div>
                                    <div className="col-sm-8 text-secondary">
                                        {props.user.profile &&
                                        props.user.profile.movie != null
                                            ? props.user.profile.movie.length
                                            : 0}
                                    </div>
                                </div>
                                <hr />
                                <div className="row">
                                    <div className="col-sm-4">
                                        <h6 className="mb-0">
                                            # of Tv Shows Added
                                        </h6>
                                    </div>
                                    <div className="col-sm-8 text-secondary">
                                        {props.user.profile &&
                                        props.user.profile.tvShow != null
                                            ? props.user.profile.tvShow.length
                                            : 0}
                                    </div>
                                </div>
                                <hr />
                                <div className="row">
                                    <div className="col-sm-4">
                                        <h6 className="mb-0">
                                            # of Favorite Movies
                                        </h6>
                                    </div>
                                    <div className="col-sm-8 text-secondary">
                                        {props.user.profile &&
                                        props.user.profile.favoriteMovie != null
                                            ? props.user.profile.favoriteMovie
                                                  .length
                                            : 0}
                                    </div>
                                </div>
                                <hr />
                                <div className="row">
                                    <div className="col-sm-4">
                                        <h6 className="mb-0">
                                            # of Favorite Tv Shows
                                        </h6>
                                    </div>
                                    <div className="col-sm-8 text-secondary">
                                        {props.user.profile &&
                                        props.user.profile.favoriteTvShow !=
                                            null
                                            ? props.user.profile.favoriteTvShow
                                                  .length
                                            : 0}
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

export default Profile;
