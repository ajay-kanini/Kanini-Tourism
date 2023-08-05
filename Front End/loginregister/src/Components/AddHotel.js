import React, { useState, useEffect } from "react";
import './VendorRegister.css'
import LoginImage from '../Assets/loginPagePic.jpg'
import VendorNavbar from './VendorNavbar';

function AddHotel()
{
    const [hotel, setHotel] = useState({
        "hotelId": 0,
        "hotelName": "",
        "hotelDescription": "",
        "city": "",
        "state": "",
        "address": "",
        "contactNumber": "",
        "agentId" : 0
      });

      var addHotel =  (event) => {
        event.preventDefault();
        fetch("http://localhost:5007/api/Hotel/AddHotel", {
          "method": "POST",
          headers: {
            "accept": "text/plain",
            "Content-Type": 'application/json'
          },
          "body": JSON.stringify({ ...hotel, "hotel": {} })
        })
          .then(async (data) => {
            if (data.status == 200) {
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
    return(
        <div>
        <div className="navBar">
         <VendorNavbar/>
        </div>
        <div className="mainDiv">
          <div className="add-hotel">
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
                                    <input className="register-warning"  type="text" placeholder="Enter Hotel Name" name="hotelName"  onChange={(event) => {
                          setHotel({ ...hotel, "hotelName": event.target.value });
                        }}/>
                                    <input className="register-warning" type="text" placeholder="Enter City Name" name="city" onChange={(event) => {
                          setHotel({  ...hotel, "city": event.target.value });
                        }}/>
                                </div>
                                <div className="register-input_text">
                                    <input className="register-warning"  type="text" placeholder="Enter State Name" name="state"  onChange={(event) => {
                          setHotel({ ...hotel, "state": event.target.value });
                        }} />                      
                                    <input className="register-warning" type="text" placeholder="Enter Contact Number" name="contact"  onChange={(event) => {
                          setHotel({ ...hotel, "contactNumber": event.target.value });
                        }}/>
                                </div>
                                <div className="register-input_address">
                                    <textarea className="register-warning" placeholder="Enter Description" name="description" onChange={(event) => {
                        setHotel({ ...hotel, "hotelDescription": event.target.value });
                      }}/>
                                </div>
                                <div className="register-input_address">
                                    <textarea className="register-warning" placeholder="Enter Address" name="address" onChange={(event) => {
                        setHotel({ ...hotel, "address": event.target.value });
                      }}/>
                                </div>
                                <div className="register-btn">
                                    <button type="submit"  onClick={addHotel}>Add Hotel</button>
                                </div>               
                            </form>
                            <hr className="register-hr" />
                        </div>
                    </div>
                </div>
            </div>
         </div>
        </div>
        </div>
        </div>
    );
}

export default AddHotel;