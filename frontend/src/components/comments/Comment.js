import React, { useContext } from "react";
import ArticlesService from "../../services/articles-service";
import { AuthContext } from "../auth/AuthContext";

const Comment = ({ comment }) => {
  const { isAuthenticated } = useContext(AuthContext);
  const handleCommentDelete = () => {
    ArticlesService.deleteArticleComment(comment.commentId).then((data) => {
      console.log(data);
    });
  };

  const formatDate = (longDate) => {
    let date = new Date(longDate);
    return `${date.getDate()} ${date.toLocaleString("default", {
      month: "short",
    })} ${date.getFullYear()}`;
  };

  return (
    <div>
      <div className="flex items-center justify-center w-full mx-auto my-4 border shadow-sm">
        <div className="py-3 w-full md:w-full pl-4 mb-2 mt-2">
          <div className="flex items-center pl-5">
            <img className="h-12 w-12 rounded-full" src="" />
            <div className="ml-2 min-w-full">
              <div className="text-sm ">
                <span className="font-semibold">
                  {comment.author.displayName}
                </span>
              </div>
              <div className="text-gray-500 text-xs ">
                {formatDate(comment.createdAt)}
              </div>
            </div>
          </div>
          <p className="text-gray-800 text-sm mt-2 leading-normal md:leading-relaxed px-12">
            {comment.body}
          </p>
          <div className="float-right text-gray-500 text-xs flex items-center mt-3 pr-4">
            {isAuthenticated && comment.author.username === user.username ? (
              <button onClick={handleCommentDelete}>
                <svg
                  xmlns="http://www.w3.org/2000/svg"
                  className="h-5 w-5 hover:text-red-600"
                  fill="none"
                  viewBox="0 0 24 24"
                  stroke="currentColor"
                >
                  <path
                    strokeLinecap="round"
                    strokeLinejoin="round"
                    strokeWidth={2}
                    d="M19 7l-.867 12.142A2 2 0 0116.138 21H7.862a2 2 0 01-1.995-1.858L5 7m5 4v6m4-6v6m1-10V4a1 1 0 00-1-1h-4a1 1 0 00-1 1v3M4 7h16"
                  />
                </svg>
              </button>
            ) : null}
          </div>
        </div>
      </div>
    </div>
  );
};

export default Comment;
