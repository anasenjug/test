import React from "react";
import axios from "axios";
import Button from "./Button";
import { HttpHeader } from "./HttpHeader";

const DeleteInternship = () => {
  const [internshipId, setInternshipId] = React.useState("");
  const [deleteMessage, setDeleteMessage] = React.useState("");

  const handleIdChange = (event) => {
    setInternshipId(event.target.value);
  };

  const handleDelete = () => {
    if (internshipId) {
      axios
        .delete(`https://localhost:44332/api/Internship/${internshipId}`, {
          headers: HttpHeader.get(),
        })
        .then(() => {
          setDeleteMessage("Internship deleted successfully.");
        })
        .catch((error) => {
          console.error("Error deleting the Internship:", error);
          setDeleteMessage("Error deleting the Internship.");
        });
    }
  };

  return (
    <div>
      <h1>Delete Internship by Id</h1>
      <label htmlFor="internshipId">Enter Internship ID:</label>
      <input
        type="text"
        id="internshipId"
        value={internshipId}
        onChange={handleIdChange}
      />
      <Button onClick={handleDelete}>Delete Internship</Button>
      {deleteMessage && <p>{deleteMessage}</p>}
    </div>
  );
};

export default DeleteInternship;
