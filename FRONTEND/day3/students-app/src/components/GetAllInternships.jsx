import React, { useEffect, useState } from "react";
import axios from "axios";
import Internship from "./Internship";

const GetAllInternships = () => {
  const [internships, setInternships] = useState([]);

  useEffect(() => {
    axios
      .get("https://localhost:44332/api/Internship")
      .then((response) => {
        const internshipsData = response.data;
        const internships = internshipsData["Data"].map((data) => {
          return new Internship(
            data.StudyAreaId,
            data.StudyArea.Name,
            data.CompanyId,
            data.Company.Name,
            data.Company.Website,
            data.Company.Address,
            data.Name,
            data.Description,
            data.Address,
            data.StartDate,
            data.EndDate
          );
        });
        setInternships(internships);
      })
      .catch((error) => {
        console.error("Error fetching internships:", error);
      });
  }, []);

  return (
    <div>
      <h1>List of Internships</h1>
      <ul>
        {internships.map((internship) => (
          <li key={internship.studyAreaId}>
            <h2>{internship.name}</h2>
            <p>{internship.description}</p>
            <p>Study Area: {internship.studyAreaName}</p>
            <p>Company Name: {internship.companyName}</p>
            <p>Address: {internship.address}</p>
            <p>Start Date: {internship.startDate.toLocaleString()}</p>
            <p>End Date: {internship.endDate.toLocaleString()}</p>
          </li>
        ))}
      </ul>
    </div>
  );
};

export default GetAllInternships;
