import React, { useState, useEffect } from "react";
import { Navbar, Nav, NavDropdown } from "react-bootstrap";

function VendorNavbar()
{
    return(
        <div className="vendorNavbar">
          <div className="navBar">
            <Navbar className="custom-navbar" expand="lg">
                <Navbar.Brand href="#">Book Your Hotel</Navbar.Brand>
                <Navbar.Toggle aria-controls="basic-navbar-nav" />
                <Navbar.Collapse id="basic-navbar-nav">
                    <Nav className="mr-auto">
                    <Nav.Link href="#home">Home</Nav.Link>
                    <Nav.Link href="#home">Add Hotels</Nav.Link>
                    <Nav.Link href="#home">Add Rooms</Nav.Link>
                    </Nav>
                    <h1 className="navbar-heading">Add Your Details</h1>
                </Navbar.Collapse>
            </Navbar>
            </div>
        </div>
    );
}

export default VendorNavbar;