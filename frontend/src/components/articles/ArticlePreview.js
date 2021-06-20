import React from "react";
import { Link, NavLink } from "react-router-dom";

const ArticlePreview = ({ article }) => {
  console.log(article);
  const formatDate = (longDate) => {
    let date = new Date(longDate);
    return `${date.getDate()} ${date.toLocaleString("default", {
      month: "short",
    })} ${date.getFullYear()}`;
  };
  return (
    <div class="max-w-4xl my-4 shadow-sm">
      <div class="md:flex md:mx-auto h-64">
        <div class="relative w-full md:w-11/12 px-4 py-4 bg-white rounded-lg">
          <div class="flex items-center justify-between">
            <h2 class="font-noto text-xl text-gray-800 font-medium ">
              <Link
                to={{
                  pathname: `/articles/${article.articleId}`,
                  props: article,
                }}
              >
                {article.title}
              </Link>
            </h2>
            <p class="text-gray-400 font-light tracking-wider">
              {formatDate(article.createdAt)}
            </p>
          </div>
          <p className="text-gray-400 font-noto font-light pt-2">
            {article.author}
          </p>
          {/* Lorem, ipsum dolor sit amet consectetur Amet veritatis ipsam
            reiciendis numquam tempore commodi ipsa suscipit laboriosam, sit
            earum at sequ adipisicing elit. Amet veritatis ipsam reiciendis
            numquam tempore commodi ipsa suscipit laboriosam, sit earum at
            sequi. */}
          <p
            class="text-sm text-gray-700 mt-4"
            dangerouslySetInnerHTML={{
              __html: article.body.trim().substring(0, 210),
            }}
          ></p>

          <div class="absolute bottom-4 mt-4 top-auto">
            <Link
              className="bg-white  font-noto text-green-700"
              to={{
                pathname: `/articles/${article.articleId}`,
                props: article,
              }}
            >
              Read More
            </Link>
          </div>
        </div>
      </div>
    </div>
  );
};

export default ArticlePreview;
