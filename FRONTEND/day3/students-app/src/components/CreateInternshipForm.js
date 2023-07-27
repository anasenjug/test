import React, { useState } from "react";
import axios from "axios";
import { HttpHeader } from "./HttpHeader";

const CreateInternshipForm = () => {
  const [formData, setFormData] = useState({
    studyAreaId: "",
    companyId: "",
    name: "",
    description: "",
    address: "",
    startDate: "",
    endDate: "",
  });

  const handleChange = (event) => {
    const { name, value } = event.target;
    setFormData((prevState) => ({ ...prevState, [name]: value }));
  };

  const handleSubmit = async (event) => {
    event.preventDefault();

    const internshipData = {
      StudyAreaId: formData.studyAreaId,
      CompanyId: formData.companyId,
      Name: formData.name,
      Description: formData.description,
      Address: formData.address,
      StartDate: formData.startDate,
      EndDate: formData.endDate,
    };

    try {
      const response = await axios.post(
        "https://localhost:44332/api/Internship",
        internshipData,
        {
          headers: HttpHeader.get(),
        }
      );
      console.log("New internship created:", response.data);
    } catch (error) {
      console.error("Error creating new internship:", error.message);
    }
  };

  return (
    <div>
      <form onSubmit={handleSubmit}>
        <label>
          Study Area ID:
          <input
            type="text"
            name="studyAreaId"
            value={formData.studyAreaId}
            onChange={handleChange}
          />
        </label>
        <br />
        <label>
          Company ID:
          <input
            type="text"
            name="companyId"
            value={formData.companyId}
            onChange={handleChange}
          />
        </label>
        <br />
        <label>
          Name:
          <input
            type="text"
            name="name"
            value={formData.name}
            onChange={handleChange}
          />
        </label>
        <br />
        <label>
          Description:
          <input
            type="text"
            name="description"
            value={formData.description}
            onChange={handleChange}
          />
        </label>
        <br />
        <label>
          Address:
          <input
            type="text"
            name="address"
            value={formData.address}
            onChange={handleChange}
          />
        </label>

        <br />
        <label>
          Start Date:
          <input
            type="datetime"
            name="startDate"
            value={formData.startDate}
            onChange={handleChange}
          />
        </label>
        <br />
        <label>
          End Date:
          <input
            type="datetime"
            name="endDate"
            value={formData.endDate}
            onChange={handleChange}
          />
        </label>
        <br />
        <button type="submit">Create Internship</button>
      </form>
    </div>
  );
};

export default CreateInternshipForm;
