import React, { useState } from "react";
import axios from "axios";
import Internship from "./Internship";
import Button from "./Button";
import { HttpHeader } from "./HttpHeader";

const GetInternshipById = () => {
  const [internshipId, setInternshipId] = useState("");
  const [internship, setInternship] = useState(null);

  const handleIdChange = (event) => {
    setInternshipId(event.target.value);
  };

  const handleSubmit = (event) => {
    event.preventDefault();
    if (internshipId) {
      axios
        .get(`https://localhost:44332/api/Internship/${internshipId}`, {
          headers: HttpHeader.get(),
        })
        .then((response) => {
          const internshipData = response.data;
          const internship = new Internship(
            internshipData.StudyAreaId,
            internshipData.StudyArea.Name,
            internshipData.CompanyId,
            internshipData.Company.Name,
            internshipData.Company.Website,
            internshipData.Company.Address,
            internshipData.Name,
            internshipData.Description,
            internshipData.Address,
            internshipData.StartDate,
            internshipData.EndDate
          );
          setInternship(internship);
        })
        .catch((error) => {
          console.error("Error fetching the Internship:", error);
          setInternship(null);
        });
    }
  };

  return (
    <div>
      <h1>Internship by Id</h1>
      <form onSubmit={handleSubmit}>
        <label htmlFor="internshipId">Enter Internship ID:</label>
        <input
          type="text"
          id="internshipId"
          value={internshipId}
          onChange={handleIdChange}
        />
        <Button type="submit">Fetch Internship</Button>
      </form>
      {internship ? (
        <div>
          <h2>{internship.name}</h2>
          <p>{internship.description}</p>
          <p>Study Area: {internship.studyAreaName}</p>
          <p>Company Name: {internship.companyName}</p>
          <p>Address: {internship.address}</p>
          <p>Start Date: {internship.startDate.toLocaleString()}</p>
          <p>End Date: {internship.endDate.toLocaleString()}</p>
        </div>
      ) : (
        <p>No internship found with the provided ID</p>
      )}
    </div>
  );
};

export default GetInternshipById;
