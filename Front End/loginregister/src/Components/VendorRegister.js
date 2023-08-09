import React from "react";
import './VendorRegister.css';
import { useState, useEffect } from 'react';
import LoginImage from "../Assets/loginPagePic.jpg"
import { ToastContainer, toast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';
import {Link, useNavigate} from 'react-router-dom';
import { Navbar, Nav, NavDropdown } from "react-bootstrap";
import Logo from '../Assets/logo-removebg-preview.png'

function VendorRegister() {
    const navigate = useNavigate();
    const [user, setUser] = useState({
        "id": 0,
        "name": "",
        "dateOfBirth": new Date(),
        "gender": "",
        "phoneNumber": "",
        "address": "",
        "aadharId": "",
        "status": "",
        "userId": 0,
        "users": {
          "id": 0,
          "mail": "",
          "role": "",
          "passwordHash": "",
          "passwordKey": ""
        },
        "password": ""
      });
      var register =  (event) => {
        event.preventDefault();
        fetch("http://localhost:5294/api/Register/RegisterHotelAgent", {
          "method": "POST",
          headers: {
            "accept": "text/plain",
            "Content-Type": 'application/json'
          },
          "body": JSON.stringify({ ...user, "user": {} })
        })
          .then(async (response) => {
            if (response.status == 201) {
              var myData = await response.json();
              toast.success('Registration successful')
              navigate("/message");
            }
            else if(response.status == 400)
            {
                toast.error('Registration unsuccessful, Please check or change your mail')
            }
          })
          .catch((err) => {
            console.log(err.error);
          });
      };
      const homeNavigation= () =>{
        navigate("/");
      }
    return (
        <div>
         <div className="navBar">
      <Navbar className="custom-navbar" expand="lg">
        <img src={Logo} style={{margin:"10px"}}/>
        <Navbar.Brand href="#">Book Your Hotel</Navbar.Brand>
        <Navbar.Toggle aria-controls="basic-navbar-nav" />
        <Navbar.Collapse id="basic-navbar-nav">
            <Nav className="mr-auto">
            <Nav.Link onClick={homeNavigation} >Home</Nav.Link>
            </Nav>
            <h1 className="navbar-heading">Vendor Details</h1>
        </Navbar.Collapse>
      </Navbar>
      
        </div>
        <div className="register-container">        
            <div className="register">
                <div className="register-card">
                    <div className="register-form">
                        <div className="register-left-side">
                            <img src={LoginImage} alt="Login" />
                        </div>
                        <div className="register-right-side">
                            <div className="register-hello">
                                <h2>Welcome !!!</h2>
                            </div>
                            <form >
                                <div className="register-input_text">
                                    <input className="register-warning"  type="text" placeholder="Enter Name" name="name"  onChange={(event) => {
                          setUser({ ...user, "name": event.target.value });
                        }}/>
                                    <input className="register-warning" type="email" placeholder="Enter Email" name="email" onChange={(event) => {
                          setUser({ ...user, users: { ...user.users, "mail": event.target.value } });
                        }}/>
                                </div>
                                <div className="register-input_text">
                                    <input className="register-warning"  type="date"  name="dob"  onChange={(event) => {
                          setUser({ ...user, "dateOfBirth": event.target.value });
                        }} />                      
                                    <input className="register-warning" type="text" placeholder="Enter Gender" name="gender"  onChange={(event) => {
                          setUser({ ...user, "gender": event.target.value });
                        }}/>
                                </div>
                                <div className="register-input_text">
                                    <input className="register-warning"  type="text" placeholder="Enter Phone Number" name="phone"  onChange={(event) => {
                          setUser({ ...user, "phoneNumber": event.target.value });
                        }}/>
                                    <input className="register-warning" type="text" placeholder="Enter Aadhar Id" name="aadhar"  onChange={(event) => {
                          setUser({ ...user, "aadharId": event.target.value });
                        }}/>
                                </div>
                                <div className="register-input_text">
                                    <input className="register-warning"  type="password" placeholder="Enter Password" name="password"  onChange={(event) => {
                          setUser({ ...user, "password": event.target.value  });
                        }}/>
                                </div>
                                <div className="register-input_address">
                                    <textarea className="register-warning" placeholder="Enter Address" name="address" onChange={(event) => {
                        setUser({ ...user, "address": event.target.value });
                      }}/>
                                </div>
                                <div className="register-btn">
                                    <button type="submit"  onClick={register}>Register</button>
                                </div>               
                            </form>
                            <hr className="register-hr" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
        </div>
    );
}

export default VendorRegister;
