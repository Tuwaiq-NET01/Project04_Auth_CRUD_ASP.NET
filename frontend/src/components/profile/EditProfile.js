import React from "react";
import { useForm } from "react-hook-form";
import ProfileService from "../../services/profile-service";

const EditProfile = (props) => {
  const {
    register,
    handleSubmit,
    formState: { errors },
  } = useForm();
  const onSubmit = (data) => {
    ProfileService.editProfile(data).then((data) => {
      props.history.push("/profile");
    });
  };

  return (
    <div>
      <div className="m-auto mt-5 w-6/12 md:mt-0 md:col-span-2">
        <form onSubmit={handleSubmit(onSubmit)}>
          <div className="sm:rounded-md">
            <div className="px-4 py-5 bg-white space-y-6 sm:p-6">
              <span>{message}</span>
              <div>
                <label
                  htmlFor="displayName"
                  className="block text-sm font-medium text-gray-700"
                >
                  displayName
                </label>
                <input
                  type="text"
                  name="displayName"
                  {...register("displayName", { required: true })}
                  className="mt-1 focus:ring-green-500 focus:border-green-500 block w-full shadow-sm sm:text-sm border-gray-300 rounded-md"
                />
                {errors.displayName && <span>This field is required</span>}
              </div>
              <div className="col-span-3 sm:col-span-2">
                <label className="block text-sm font-medium text-gray-700">
                  bio
                </label>
                <input
                  type="text"
                  name="bio"
                  {...register("bio", { required: false })}
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
    </div>
  );
};

export default EditProfile;
