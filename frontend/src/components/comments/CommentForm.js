import React, { useState } from "react";
import { useForm } from "react-hook-form";
import ArticleService from "../../services/articles-service";

const CommentForm = ({ articleId }) => {
  const {
    register,
    handleSubmit,
    formState: { errors },
  } = useForm();

  const onSubmit = (data) => {
    ArticleService.addArticleComment(articleId, data).then((res) => {
      console.log(res);
    });
  };

  return (
    <div>
      <div className="flex items-center justify-center shadow-sm border w-full mx-auto my-8">
        <form
          className="bg-white rounded-lg px-4 pt-2"
          onSubmit={handleSubmit(onSubmit)}
        >
          <div className="flex flex-wrap -mx-3 mb-6">
            <h2 className="px-4 pt-3 pb-2 text-gray-800 text-lg">
              Add a new comment
            </h2>
            <div className="w-full md:w-full px-3 mb-2 mt-2">
              <textarea
                className="bg-gray-100 rounded border border-gray-200 leading-normal resize-none w-full h-20 py-2 px-3 font-normal placeholder-gray-400 focus:outline-none focus:bg-white"
                name="body"
                placeholder="Type Your Comment"
                {...register("body", { required: true })}
              ></textarea>
            </div>
            <div className="w-full flex items-start md:w-full px-3">
              <div className="flex items-start w-1/2 text-gray-700 px-2 mr-auto">
                <p className="text-xs md:text-sm pt-px">
                  {errors.body && <span>This field is required</span>}
                </p>
              </div>
              <div className="-mr-1">
                <input
                  type="submit"
                  className="bg-white text-gray-700 font-medium py-1 px-4 border border-gray-400 rounded-lg tracking-wide mr-1 hover:bg-gray-100"
                  value="Post Comment"
                />
              </div>
            </div>
          </div>
        </form>
      </div>
    </div>
  );
};

export default CommentForm;
