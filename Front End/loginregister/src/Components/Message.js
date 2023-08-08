import React from 'react';
import { Navbar, Nav, NavDropdown } from "react-bootstrap";

function Message() {
  return (
    <div>
        <Navbar className="custom-navbar" expand="lg">
        <Navbar.Brand href="#">Book Your Hotel</Navbar.Brand>
        <Navbar.Toggle aria-controls="basic-navbar-nav" />
        <Navbar.Collapse id="basic-navbar-nav">
            <Nav className="mr-auto">
            <Nav.Link href="#home" >Home</Nav.Link>
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
