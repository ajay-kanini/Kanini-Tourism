import React, { useState } from "react";
import './Login.css';
import { useNavigate } from "react-router-dom";
import { toast, ToastContainer } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';
import LoginImage from "../Assets/loginPagePic.jpg";

function Login() {
  const navigate = useNavigate();
  const [user, setUser] = useState({
    "mail": "",
    "id": 0,
    "password": "",
    "role": "",
    "token": ""
  });

  var login = (event) => {
    event.preventDefault();
    if (!user.mail || !user.password) {
      toast.error("Please enter both email and password.");
      return;
    }

    fetch("http://localhost:5294/api/Register/Login", {
      method: "POST",
      headers: {
        "accept": 'text/plain',
        "Content-Type": "application/json"
      },
      body: JSON.stringify(user),
    })
      .then(async (response) => {
        if (response.status === 200) {
          var myData = await response.json();
          localStorage.setItem("Id", myData.id.toString());
          localStorage.setItem("token", myData.token.toString());
          localStorage.setItem("mail", myData.mail);
          localStorage.setItem("role", myData.role);
          if (myData.role === "Hotel Agent")
            navigate("/vendorHotelPage");
          else if (myData.role === "Client")
            navigate("/hotelList");
          else if (myData.role === "Admin")
            navigate("/adminPage");
        } else {
          alert("not ok");
        }
      })
      .catch((err) => {
        console.log(err);
      });
  };

  const vendorRegister = () => {
    navigate("/vendorRegister");
  }

  const userRegister = () => {
    navigate("/userRegister");
  }

  return (
    <div className="login-container">
      <ToastContainer />
      <div className="login-card">
        <div className="login-form">
          <div className="login-left-side">
            <img src={LoginImage} alt="Login" />
          </div>
          <div className="login-right-side">
            <div className="login-hello">
              <h2>Hello Again !!!</h2>
            </div>
            <form >
              <div className="login-input_text">
                <input className="login-warning" type="text" placeholder="Enter Email" name="email" onChange={(event) => {
                  setUser({ ...user, "mail": event.target.value })
                }} />
              </div>
              <div className="login-input_text">
                <input className="login-warning" type="password" placeholder="Enter Password" name="password" onChange={(event) => {
                  setUser({ ...user, "password": event.target.value })
                }} />
              </div>
              <div className="login-recovery">
                <p>Forget Password?</p>
              </div>
              <div className="login-btn">
                <button type="submit" onClick={login}>Sign in</button>
              </div>
              <h5 className="login-register-alert">Not a registered user?</h5>

              <div className="login-register-buttons-container">
                <div className="login-register-btn">
                  <button type="submit" onClick={vendorRegister}>Register as Vendor</button>
                </div>
                <div className="login-register-btn">
                  <button type="submit" onClick={userRegister}>Register as User</button>
                </div>
              </div>
            </form>
            <hr />
          </div>
        </div>
      </div>
    </div>
  );
}

export default Login;
