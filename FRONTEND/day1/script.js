function isDuplicateEmail(email) {
  const studentsDataJson = localStorage.getItem("studentsData");
  if (studentsDataJson) {
    const studentsData = JSON.parse(studentsDataJson);
    return studentsData.some((student) => student.email === email);
  }
  return false;
}

function handleSubmit(event) {
  event.preventDefault();
  const email = document.getElementById("email").value; // Move this line here to get the email value
  if (isDuplicateEmail(email)) {
    alert("Duplicate email! Please use a different email.");
    return;
  }

  const firstName = document.getElementById("fname").value;
  const lastName = document.getElementById("lname").value;
  const address = document.getElementById("address").value;
  const university = document.getElementById("university").value;
  const studyArea = document.getElementById("studyarea").value;
  const gender = document.querySelector('input[name="gender"]:checked').value;

  const formData = {
    email: email,
    firstName: firstName,
    lastName: lastName,
    address: address,
    university: university,
    studyArea: studyArea,
    gender: gender,
  };

  const existingDataJson = localStorage.getItem("studentsData");
  let existingData = [];

  if (existingDataJson) {
    existingData = JSON.parse(existingDataJson);
  }

  existingData.push(formData);

  const updatedDataJson = JSON.stringify(existingData);

  localStorage.setItem("studentsData", updatedDataJson);

  alert("Student data saved to local storage!");

  document.getElementById("studentform").reset();

  displayAllStudents();
}

document.addEventListener("DOMContentLoaded", () => {
  console.log("DOM is loaded.");
  const form = document.getElementById("studentform");
  console.log(form); // Check if the form is found
  if (form) {
    form.addEventListener("submit", handleSubmit); // Attach the handleSubmit function to the form submit event
  }
});

// Function to display all students in the table
function displayAllStudents() {
  // Get the student data from local storage
  const studentsDataJson = localStorage.getItem("studentsData");
  const tableBody = document.getElementById("studentsBody");
  tableBody.innerHTML = ""; // Clear the existing table data

  if (studentsDataJson) {
    const studentsData = JSON.parse(studentsDataJson);

    // Loop through the student data and populate the table
    for (const student of studentsData) {
      const row = document.createElement("tr");
      row.innerHTML = `
          <td>${student.email}</td>
          <td>${student.firstName}</td>
          <td>${student.lastName}</td>
          <td>${student.address}</td>
          <td>${student.university}</td>
          <td>${student.studyArea}</td>
          <td>${student.gender === "m" ? "Male" : "Female"}</td>
        `;
      tableBody.appendChild(row);
    }
  }
}

function clearTable() {
  const confirmClear = window.confirm(
    "Are you sure you want to clear all the records?"
  );
  if (confirmClear) {
    const tableBody = document.getElementById("studentsBody");
    tableBody.innerHTML = "";
    localStorage.removeItem("studentsData");
  }
  const tableBody = document.getElementById("studentsBody");

  tableBody.innerHTML = "";

  localStorage.removeItem("studentsData");
}

const clearButton = document.getElementById("clearButton");
if (clearButton) {
  clearButton.addEventListener("click", clearTable);
}

function findStudentByEmail(email) {
  const studentsDataJson = localStorage.getItem("studentsData");

  if (studentsDataJson) {
    const studentsData = JSON.parse(studentsDataJson);
    const studentData = studentsData.find((student) => student.email === email);

    if (studentData) {
      const formData = {
        email: studentData.email,
        firstName: studentData.firstName,
        lastName: studentData.lastName,
        address: studentData.address,
        university: studentData.university,
        studyArea: studentData.studyArea,
        gender: studentData.gender,
      };

      // Populate the form with student data
      for (const key in formData) {
        document.getElementById(key).value = formData[key];
      }
    } else {
      alert("Student data not found for the entered email.");
    }
  } else {
    alert("No student data found. Add some students first.");
  }
}
document.addEventListener("DOMContentLoaded", displayAllStudents);
// Event listener for "Find Student" button click
const findStudentButton = document.getElementById("findStudentButton");
if (findStudentButton) {
  findStudentButton.addEventListener("click", () => {
    const email = document.getElementById("email").value;
    findStudentByEmail(email);
  });
}

const editProfileButton = document.getElementById("editProfileButton");
const editFormDiv = document.querySelector(".edit-form");

if (editProfileButton) {
  editProfileButton.addEventListener("click", () => {
    editFormDiv.style.display = "block"; // Display the edit form

    const email = document.getElementById("email").value;
    findStudentByEmail(email);

    document.getElementById("editForm").addEventListener("submit", (event) => {
      event.preventDefault();

      const updatedFormData = {
        email: document.getElementById("editEmail").value,
        firstName: document.getElementById("editFirstName").value,
        lastName: document.getElementById("editLastName").value,
        address: document.getElementById("editAddress").value,
        university: document.getElementById("editUniversity").value,
        studyArea: document.getElementById("editStudyArea").value,
        gender: document.querySelector('input[name="editGender"]:checked')
          .value,
      };
      debugger;
      // Update the data in local storage based on the email
      updateStudentData(updatedFormData.email, updatedFormData);

      // Hide the edit form and display all students with updated data
      editFormDiv.style.display = "none";
      displayAllStudents();
    });

    // Cancel button for the edit form
    document.getElementById("editCancel").addEventListener("click", () => {
      editFormDiv.style.display = "none"; // Hide the edit form
    });
  });
}

// Function to update student data in local storage based on email
function updateStudentData(email, updatedData) {
  const studentsDataJson = localStorage.getItem("studentsData");
  if (studentsDataJson) {
    const studentsData = JSON.parse(studentsDataJson);
    const index = studentsData.findIndex((student) => student.email === email);
    debugger;
    if (index !== -1) {
      studentsData[index] = updatedData;
      const updatedDataJson = JSON.stringify(studentsData);
      localStorage.setItem("studentsData", updatedDataJson);
    }
  }
}
