import React from "react";
import './Login.css';
import { useState, useEffect } from 'react';
import LoginImage from "../Assets/loginPagePic.jpg"

function Login() {
    const [user,setUser] = useState({
        "mail": "",
        "id": 0,
        "password": "",
        "role": "",
        "token": ""
      });

    var login = ()=>{
        fetch("http://localhost:5294/api/Register/Login",{
          "method":"POST",
          headers:{
              "accept": "text/plain",
              "Content-Type": 'application/json'
          },
          "body":JSON.stringify({...user,"user":{} })})
          .then(async (data)=>{ 
          if(data.status == 201)
          {
            alert("ok");     
          }
          else
          {
            alert("not ok");
          }
        }).catch((err)=>{
          console.log(err.error)
        })
      }
   return( 
<div className="login-container">
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
                      <input className="login-warning"  type="text" placeholder="Enter Email" name="email" onChange={(event)=>{
                      setUser({...user, "mail":event.target.value}) }}/>
                  </div>
                  <div className="login-input_text">
                      <input className="login-warning" type="text" placeholder="Enter Password" name="password" onChange={(event)=>{
                    setUser({...user, "password":(event.target.value)})}} />
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
                    <button type="submit">Register as Vendor</button>
                  </div>
                  <div className="login-register-btn">
                    <button type="submit">Register as User</button>
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
