import React, { useState, useEffect } from "react";
import UserNavbar from "./UserNavbar";
import LoginImage from '../Assets/loginPagePic.jpg';
import LoginImage2 from '../Assets/login2.jpg';
import './HotelInfoPage.css';
import { useParams } from "react-router-dom";
import { CCarousel, CCarouselItem, CImage } from '@coreui/react';

function HotelInfoPage() {
  const [hotel, setHotel] = useState({
    "hotelId": 1,
    "hotelName": "string",
    "hotelDescription": "string",
    "city": "string",
    "state": "string",
    "address": "string",
    "contactNumber": "string",
    "agentId": 0
  });

  const { hotelId } = useParams();

  useEffect(() => {
    fetchHotelData();
  }, [hotelId]);

  const fetchHotelData = () => {
    fetch(`http://localhost:5007/api/Hotel/GetHotelById?id=${hotelId}`)
      .then(response => response.json())
      .then(data => {
        console.log(data);
        setHotel(data);
      })
      .catch(error => console.log(error));
  };
  

  return (
    <div className="mainDiv">
      <div className="navBar">
        <UserNavbar />
      </div>
      <div className="c-carousel" style={{ marginTop: "10px" }}>
        <CCarousel controls interval={2000} transition="crossfade">
          <CCarouselItem>
            <CImage className="carouselImage" src={LoginImage} alt="slide 1" style={{ height: "500px", width: "100%" }} />
          </CCarouselItem>
          <CCarouselItem>
            <CImage className="carouselImage" src={LoginImage2} alt="slide 2" style={{ height: "500px", width: "100%" }} />
          </CCarouselItem>
          <CCarouselItem>
            <CImage className="carouselImage" src={LoginImage} alt="slide 3" style={{ height: "500px", width: "100%" }} />
          </CCarouselItem>
        </CCarousel>
      </div>
      <div className="hotelDetails">
        <h2>{hotel.hotelName}</h2>
        <p>City: {hotel.city}</p>
        <p>State:  {hotel.state}</p>
        <p>Contact Number: {hotel.contactNumber}</p>
        <p>Description: {hotel.hotelDescription}</p>
        <p>Address: {hotel.address}</p>
      </div>
    </div>
  );
}

export default HotelInfoPage;
