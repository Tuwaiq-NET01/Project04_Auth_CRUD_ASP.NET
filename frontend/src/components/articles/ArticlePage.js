import React, { useState, useEffect, useContext } from "react";
import { Link } from "react-router-dom";
import { matchPath } from "react-router-dom";
import { AuthContext } from "../auth/AuthContext";
import ArticleService from "../../services/articles-service";
import CommentForm from "../comments/CommentForm";
import Comment from "../comments/Comment";

const ArticlePage = (props) => {
  const [article, setArticle] = useState({});
  const [date, setDate] = useState("");
  const [comments, setComments] = useState([]);
  const { user, isAuthenticated } = useContext(AuthContext);

  useEffect(() => {
    let params = getParams(props.location.pathname);
    const id = parseInt(params.articleId);
    ArticleService.getArticleById(id).then((res) => {
      setArticle(res.data);
      let date = new Date(res.data.createdAt);
      setDate(
        `${date.getDate()} ${date.toLocaleString("default", {
          month: "short",
        })} ${date.getFullYear()}`
      );
      ArticleService.getArticleComments(id).then((res) => {
        console.log(res);
        setComments(res.data);
      });
    });
  }, [comments]);

  const getParams = (pathname) => {
    const matchTag = matchPath(pathname, {
      path: `/articles/:articleId`,
    });
    return (matchTag && matchTag.params) || {};
  };

  const handleArticleDelete = () => {
    ArticleService.deleteArticle(article.articleId).then((data) => {
      console.log(data);
      if (data.status === 204) {
        props.history.push("/");
      }
    });
  };

  return (
    <div className="w-full md:w-3/5 mx-auto">
      <div className="font-noto py-8">
        <div className="w-full text-gray-800 text-4xl px-5 font-bold leading-none mb-3">
          {article.title}
        </div>
        <span className="w-full text-gray-600 font-thin italic px-5">
          By <strong className="text-gray-700">{article.author}</strong>
          <span className="px-3 text-gray-400">•</span>
          {date}
        </span>
      </div>
      <div className="w-full text-gray-600 text-normal mx-5">
        <div dangerouslySetInnerHTML={{ __html: article.body }}></div>
      </div>
      <div className="mx-5 my-3 text-sm">
        {article.tags
          ? article.tags.map((tag, index) => {
              return (
                <span
                  key={index}
                  className="text-sm font-light bg-gray-100 py-1 px-2 mx-1.5 rounded text-gray-500 align-middle"
                >
                  {tag.name}
                </span>
              );
            })
          : null}{" "}
        {isAuthenticated && user.username === article.author ? (
          <div className=" float-right">
            <Link
              to={{
                pathname: `/articles/${article.articleId}/edit`,
                state: { article: article, actionType: "EDIT" },
              }}
            >
              <button
                className="whitespace-no-wrap mr-5 inline-flex items-center justify-center px-3 py-2 border border-green-700 
                    rounded-md text-green-700 hover:bg-green-700 hover:text-white focus:outline-none focus:border-green-700 focus:shadow-outline-green active:bg-blue-700"
              >
                Edit
              </button>
            </Link>
            <button
              className="whitespace-no-wrap inline-flex items-center justify-center px-3 py-2 border border-red-700 
                    rounded-md text-red-700 hover:bg-red-700 hover:text-white focus:outline-none focus:border-red-700 focus:shadow-outline-green active:bg-blue-700"
              onClick={handleArticleDelete}
            >
              Delete
            </button>
          </div>
        ) : (
          ""
        )}
        <div className="h-9 border-b mb-7"></div>
        <div>
          {comments.map((comment, index) => {
            return <Comment key={index} comment={comment} />;
          })}
          {isAuthenticated ? (
            <CommentForm articleId={article.articleId} />
          ) : null}
        </div>
      </div>
    </div>
  );
};

export default ArticlePage;
