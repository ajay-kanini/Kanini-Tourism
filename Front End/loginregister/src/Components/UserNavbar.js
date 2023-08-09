import React, { useState, useEffect } from "react";
import { Navbar, Nav, NavDropdown } from "react-bootstrap";
import {Link, useNavigate} from "react-router-dom";
import Logo from '../Assets/logo-removebg-preview.png';
function UserNavbar()
{
    const navigate = useNavigate();
    const homePage= () =>{
       navigate("/");
    }
    const bookingPage= () =>{
        navigate("/userBooking");
     }
     const clearStorage= () =>{
        localStorage.clear();
        navigate("/login");
      }
    return(
        <div className="vendorNavbar">
          <div className="navBar">
            <Navbar className="custom-navbar" expand="lg">
            <img src={Logo} style={{margin:"10px"}}/>
                <Navbar.Brand href="#">Book Your Hotel</Navbar.Brand>
                <Navbar.Toggle aria-controls="basic-navbar-nav" />
                <Navbar.Collapse id="basic-navbar-nav">
                    <Nav className="mr-auto">
                    <Nav.Link onClick={homePage}>Home</Nav.Link>
                    <Nav.Link onClick={bookingPage}>Your Bookings</Nav.Link> 
                    <Nav.Link onClick={clearStorage} >Log Out</Nav.Link>
                    </Nav>
                    <h1 className="navbar-heading">Hotel Details</h1>
                </Navbar.Collapse>
            </Navbar>
            </div>
        </div>
    );
}

export default UserNavbar;