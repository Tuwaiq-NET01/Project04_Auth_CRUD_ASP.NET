import React, { useState, useEffect } from "react";
import { NavLink } from "react-router-dom";
import TagsService from "../../services/tags-service";

const TagsList = () => {
  const [tags, setTags] = useState([]);
  useEffect(() => {
    TagsService.getTags().then((data) => {
      console.log(data);
      setTags(data);
    });
  }, []);

  return (
    <div className="px-8 max-w-sm">
      <h1 className="font-noto text-md font-normal text-gray-400 mb-4">Tags</h1>
      <div className="flex flex-col max-w-sm px-8 py-6 mx-auto bg-white rounded-lg shadow-sm">
        <div className="flex justify-between flex-wrap">
          {tags.map((tag) => {
            return (
              <div
                key={tag.tagId}
                className="bg-gray-100 text-xs text-gray-500 rounded px-2 py-1 mr-2 my-1"
              >
                <NavLink
                  className="btn btn-info"
                  activeClassName="text-green-400  font-bold "
                  to={`/home/tags/${tag.tagId}`}
                >
                  {tag.name}
                </NavLink>
              </div>
            );
          })}
        </div>
      </div>
    </div>
  );
};

export default TagsList;
