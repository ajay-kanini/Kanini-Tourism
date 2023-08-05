import React, { useState, useEffect } from "react";
import VendorNavbar from "./VendorNavbar";
import LoginImage from '../Assets/loginPagePic.jpg';
import './VendorPage.css';

function VendorPage() {
  const [hotels, setHotels] = useState([]);

  useEffect(() => {
    hotelsByAgent(2);
  }, []);

  const hotelsByAgent = (id) => {
    fetch(`http://localhost:5007/api/Hotel/GetByAgent?agentId=${id}`)
      .then(response => response.json())
      .then(data => {
        setHotels(data);
      })
      .catch(error => console.log(error));
  };

  return (
    <div className="mainDiv">
      <div className="navBar">
        <VendorNavbar />
      </div>
      <div className="hotelCardContainer">
        {hotels.map(hotel => (
          <div key={hotel.hotelId} className="hotelCard">
            <div className="hotelImage" >
                <img src={LoginImage}/>
            </div>
            <div className="hotelInfo">
              <h3>{hotel.hotelName}</h3>
              <div className="starIcons">
                {[...Array(5)].map((_, index) => (
                  <i key={index} className="fa fa-star"></i>
                ))}
              </div>
            </div>
          </div>
        ))}
      </div>
    </div>
  );
}

export default VendorPage;
