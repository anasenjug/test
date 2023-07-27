import React from "react";
import { Link } from "react-router-dom";

const Nav = () => {
  const navStyle = {
    color: "whitesmoke",
  };

  return (
    <div className="Nav">
      <nav>
        <h3>Navbar</h3>
        <ul className="nav-links">
          <Link style={navStyle} to="/">
            <li>Home</li>
          </Link>

          <Link style={navStyle} to="/profile">
            <li>Profile</li>
          </Link>

          <Link style={navStyle} to="/internships">
            <li>Internships</li>
          </Link>
        </ul>
      </nav>
    </div>
  );
};

export default Nav;
