import React, { useState, useEffect, useContext } from "react";
import { Link } from "react-router-dom";
import { AuthContext } from "../auth/AuthContext";
import ArticlePreview from "../articles/ArticlePreview";

const Profile = () => {
  const { user } = useContext(AuthContext);
  const [profile, setProfile] = useState({});

  useEffect(() => {
    setProfile(user);
  }, []);

  return (
    <div className="w-11/12">
      <div className="flex justify-center pb-10">
        <div className="ml-10">
          <div className="flex items-center">
            <h2 className="block leading-relaxed font-light text-gray-700 text-3xl">
              {profile.displayName}
            </h2>

            {profile.username === profile.username ? (
              <Link
                to="/profile/edit"
                className="cursor-pointer ml-2 p-1 border-transparent text-gray-700 rounded-full hover:text-blue-600 focus:outline-none focus:text-gray-600"
              >
                <svg
                  className="h-8 w-8"
                  fill="none"
                  strokeLinecap="round"
                  strokeLinejoin="round"
                  strokeWidth="1.5"
                  stroke="currentColor"
                  viewBox="0 0 24 24"
                >
                  <path d="M10.325 4.317c.426-1.756 2.924-1.756 3.35 0a1.724 1.724 0 002.573 1.066c1.543-.94 3.31.826 2.37 2.37a1.724 1.724 0 001.065 2.572c1.756.426 1.756 2.924 0 3.35a1.724 1.724 0 00-1.066 2.573c.94 1.543-.826 3.31-2.37 2.37a1.724 1.724 0 00-2.572 1.065c-.426 1.756-2.924 1.756-3.35 0a1.724 1.724 0 00-2.573-1.066c-1.543.94-3.31-.826-2.37-2.37a1.724 1.724 0 00-1.065-2.572c-1.756-.426-1.756-2.924 0-3.35a1.724 1.724 0 001.066-2.573c-.94-1.543.826-3.31 2.37-2.37.996.608 2.296.07 2.572-1.065z" />
                  <path d="M15 12a3 3 0 11-6 0 3 3 0 016 0z" />
                </svg>
              </Link>
            ) : null}
          </div>
          <div className="">
            <p className="text-base font-light">{profile.username}</p>
            <span className="text-base">{profile.bio}</span>
          </div>
        </div>
      </div>
      <div className="border-b border-gray-300"></div>
      <div className="mt-5 my-0 mx-auto">
        {profile.articles
          ? profile.articles.map((article) => {
              return <ArticlePreview article={article} />;
            })
          : "No articles"}
      </div>
    </div>
  );
};

export default Profile;
