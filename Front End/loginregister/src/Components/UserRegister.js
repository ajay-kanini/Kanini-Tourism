import React from "react";
import './VendorRegister.css';
import { useState, useEffect } from 'react';
import LoginImage from "../Assets/loginPagePic.jpg"

function VendorRegister() {
    const [user, setUser] = useState({
        "id": 0,
        "name": "",
        "dateOfBirth": new Date(),
        "gender": "",
        "phoneNumber": "",
        "address": "",
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
        fetch("http://localhost:5294/api/Register/RegisterClient", {
          "method": "POST",
          headers: {
            "accept": "text/plain",
            "Content-Type": 'application/json'
          },
          "body": JSON.stringify({ ...user, "user": {} })
        })
          .then(async (data) => {
            if (data.status == 201) {
              alert('ok')
            }
            else
            {
                alert('not ok')
            }
          })
          .catch((err) => {
            console.log(err.error);
          });
      };
      
    return (
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
    );
}

export default VendorRegister;
