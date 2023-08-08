import React, { useState, useEffect } from "react";
import { Navbar, Nav, NavDropdown } from "react-bootstrap";
import { Link, useNavigate } from "react-router-dom";

function VendorNavbar()
{
    const navigate = useNavigate();

    const goToLogin = () =>{
        navigate("/");
    }
   
    const vendorHotelPage = () =>{
        navigate("/vendorHotelPage");
    }

    const vendorRoomPage = () =>{
        navigate("/vendorRoomPage");
    }
    return(
        <div className="vendorNavbar">
          <div className="navBar">
            <Navbar className="custom-navbar" expand="lg">
                <Navbar.Brand >Book Your Hotel</Navbar.Brand>
                <Navbar.Toggle aria-controls="basic-navbar-nav" />
                <Navbar.Collapse id="basic-navbar-nav">
                    <Nav className="mr-auto">
                    <Nav.Link  onClick={goToLogin}>Home</Nav.Link>
                    <Nav.Link  onClick={vendorHotelPage}>Add Hotels</Nav.Link>
                    <Nav.Link  onClick={vendorRoomPage}>Add Rooms</Nav.Link>
                    </Nav>
                    <h1 className="navbar-heading">Add Your Details</h1>
                </Navbar.Collapse>
            </Navbar>
            </div>
        </div>
    );
}

export default VendorNavbar;