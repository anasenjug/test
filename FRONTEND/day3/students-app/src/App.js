import React from "react";
import Button from "./components/Button";
import GetAllInternships from "./components/GetAllInternships";
import GetInternshipById from "./components/GetInternshipById";

const App = () => {
  return (
    <div>
      <GetAllInternships />
      <GetInternshipById />
    </div>
  );
};

export default App;
