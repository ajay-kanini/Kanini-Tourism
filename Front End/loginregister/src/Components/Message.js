import React from 'react';
import { Navbar, Nav, NavDropdown } from "react-bootstrap";
import {Link, useNavigate} from 'react-router-dom';
import Logo from '../Assets/logo-removebg-preview.png';
function Message() {
  const navigate = useNavigate();
  const homeNavigation= () =>{
    navigate("/");
  }
  const clearStorage= () =>{
    localStorage.clear();
    navigate("/login");
  }
  return (
      <div>
        <Navbar className="custom-navbar" expand="lg">
        <Navbar.Brand href="#">Book Your Hotel</Navbar.Brand>
        <Navbar.Toggle aria-controls="basic-navbar-nav" />
        <Navbar.Collapse id="basic-navbar-nav">
            <Nav className="mr-auto">
            <Nav.Link  onClick={homeNavigation}  >Home</Nav.Link>
            <Nav.Link onClick={clearStorage} >Log Out</Nav.Link>
            </Nav>
            <h1 className="navbar-heading">Vendor Details</h1>
        </Navbar.Collapse>
      </Navbar>
    
      <div className='notify'>
        <p>Please wait till you get authorized!!!</p>
      </div>
      </div>
  );
}

export default Message;
