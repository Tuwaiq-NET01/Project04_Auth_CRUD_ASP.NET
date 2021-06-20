import React, { useEffect, useState } from "react";
import { useLocation } from "react-router-dom";
import Editor from "react-medium-editor";
import { useForm } from "react-hook-form";
import ArticleService from "../../services/articles-service";
require("medium-editor/dist/css/medium-editor.css");
require("medium-editor/dist/css/themes/default.css");

const ArticleEditor = (props) => {
  const { state } = useLocation();
  const { actionType } = state;
  const [article, setArticle] = useState({});
  const [body, setBody] = useState("");
  const [title, setTitle] = useState("");
  const [tags, setTags] = useState("");
  const [message, setMessage] = useState("");
  const {
    register,
    handleSubmit,
    setValue,
    formState: { errors },
  } = useForm({ defaultValues: { title: title, tags: tags } });

  useEffect(() => {
    console.log(state);
    if (actionType === "EDIT") {
      let tagsStr = getTagsStirng(state.article.tags);
      console.log(tagsStr);
      setTags(tagsStr);
      setValue("tags", tags);
      setArticle(state.article);
      setBody(state.article.body);
      setTitle(state.article.title);
      setValue("title", title);
    }
  }, [tags, title]);

  const onSubmit = (data) => {
    const articlePost = { title: data.title, body: body };

    const tags = getTagsArray(data.tags);
    let tagsPost = [];
    tags.map((tag) => {
      tagsPost.push({ name: tag });
    });

    if (actionType === "EDIT") {
      ArticleService.editArticle(article.articleId, articlePost).then(
        (data) => {
          console.log(data);
          if (data.status == 200) {
            ArticleService.addArticleTags(article.articleId, tagsPost).then(
              (data) => {
                console.log(data);
                if (data.status !== 200) {
                  setMessage("an error has occured");
                }
                props.history.push("/");
              }
            );
          }
        }
      );
    } else {
      ArticleService.addArticle(articlePost).then((data) => {
        console.log(data);
        let newArticle = { articleId: data.id };
        if (data.status == 201) {
          ArticleService.addArticleTags(data.data.id, tagsPost).then((data) => {
            console.log(data);
            if (data.status !== 200) {
              setMessage("an error has occured");
            }
            props.history.push("/");
          });
        }
      });
    }
  };
  const handleBodyChange = (text, medium) => {
    setBody(text);
    //console.log(medium);
  };

  const getTagsArray = (tags) => {
    return tags.split(",");
  };

  const getTagsStirng = (tagsArray) => {
    return tagsArray
      .map((tag) => {
        return tag.name;
      })
      .join(", ");
  };

  return (
    <div className="m-auto mt-5 w-6/12 md:mt-0 md:col-span-2">
      <form onSubmit={handleSubmit(onSubmit)}>
        <div className="sm:rounded-md">
          <div className="px-4 py-5 bg-white space-y-6 sm:p-6">
            <span>{message}</span>
            <div>
              <label
                htmlFor="title"
                className="block text-sm font-medium text-gray-700"
              >
                Title
              </label>
              <input
                type="text"
                name="title"
                {...register("title", { required: true })}
                className="mt-1 focus:ring-green-500 focus:border-green-500 block w-full shadow-sm sm:text-sm border-gray-300 rounded-md"
              />
              {errors.title && <span>This field is required</span>}
            </div>
            <div className="mt-1 h-13">
              <Editor
                tag="pre"
                text={body}
                onChange={handleBodyChange}
                className="editor-box h-80 p-2 shadow-sm focus:ring-green-500 focus:border-green-500 mt-1 block w-full sm:text-sm border border-gray-300 rounded-md"
                options={{
                  toolbar: { buttons: ["bold", "italic", "underline"] },
                }}
              />
              {errors.body && <span>This field is required</span>}
            </div>
            <div className="col-span-3 sm:col-span-2">
              <label
                for="first_name"
                className="block text-sm font-medium text-gray-700"
              >
                Tags
              </label>
              <small>seperated by commas</small>
              <input
                type="text"
                name="tags"
                {...register("tags", { required: false })}
                className="mt-1 focus:ring-green-500 focus:border-green-500 block w-full shadow-sm sm:text-sm border-gray-300 rounded-md"
              />
            </div>

            <div className="py-3 text-right sm:px-6">
              <button
                type="submit"
                className="inline-flex justify-center py-2 px-4 border border-transparent shadow-sm text-sm font-medium rounded-md text-white bg-green-600 hover:bg-green-700 focus:outline-none focus:ring-2 focus:ring-offset-2 focus:ring-green-500"
              >
                Save
              </button>
            </div>
          </div>
        </div>
      </form>
    </div>
  );
};

export default ArticleEditor;
