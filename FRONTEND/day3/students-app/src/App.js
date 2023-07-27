import React from "react";
import Nav from "./components/Nav";
import Home from "./Home";
import Profile from "./Profile";
import "./App.css";
import { BrowserRouter as Router, Route, Routes } from "react-router-dom";
import InternshipList from "./InternshipList";

const App = () => {
  return (
    <Router>
      <div className="App">
        <Nav />
        <Routes>
          <Route path="/" element={<Home />} />
          <Route path="/profile" element={<Profile />} />
          <Route path="/internships" element={<InternshipList />} />
        </Routes>
      </div>
    </Router>
  );
};

export default App;
