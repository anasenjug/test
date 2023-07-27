import React from "react";
import GetInternshipById from "./components/GetInternshipById";
import DeleteInternship from "./components/DeleteInternship";

const Profile = () => {
  return (
    <div className="Profile">
      <h1>Profile page</h1>
      <GetInternshipById />
      <DeleteInternship />
    </div>
  );
};

export default Profile;
