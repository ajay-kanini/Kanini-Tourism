import React, { useState, useEffect } from "react";
import VendorNavbar from "./VendorNavbar";
import LoginImage from '../Assets/loginPagePic.jpg';
import './UserHotelList.css';
import { Link, useNavigate } from "react-router-dom";
import FeedbackRating from './FeedbackRating';
import { FaPlus } from 'react-icons/fa';
import AddHotelCard from "./AddHotelCard";

function VendorRoomPage() {
  const [hotels, setHotels] = useState([]);
  var id = Number(localStorage.getItem("Id"));
  
  const navigate = useNavigate();

  useEffect(() => {
    hotelsByAgent();
  }, []);

  const hotelsByAgent = () => {
    fetch(`http://localhost:5007/api/Hotel/GetByAgent/${id}`)
      .then(response => response.json())
      .then(data => {
        setHotels(data);
      })
      .catch(error => console.log(error));
  };

  const goToRoom = (hotelid) => {
    navigate(`/addRoom/${hotelid}`);
  };
  
  const rooDetails = (hotelId) => {
    navigate(`/fetchRooms/${hotelId}`);
  };

  return (
    <div className="mainDiv">
      <div className="navBar">
        <VendorNavbar />
      </div>
      
      <div className="hotelCardContainer">
        {hotels.map(hotel => (
          <div key={hotel.hotelId} className="hotelCard">
            <div className="hotelImage">
              <img src={LoginImage} alt="Hotel" onClick={() => rooDetails(hotel.hotelId)} />
            </div>
            <div className="hotelInfo">
              <h3>{hotel.hotelName}</h3>
              <FeedbackRating hotelId={hotel.hotelId} />
            </div>
            <div className="roomPage">
              <button
                style={{
                  height: "35px",
                  marginBottom: "5px",
                  backgroundColor: "#007bff",
                  color: "#fff",
                  border: "none",
                  borderRadius: "5px",
                  padding: "5px 20px",
                  fontSize: "13px",
                  cursor: "pointer",
                }}
                onClick={() => goToRoom(hotel.hotelId)} // Pass a callback function
                onMouseEnter={(e) => e.target.style.backgroundColor = '#0056b3'}
                onMouseLeave={(e) => e.target.style.backgroundColor = '#007bff'}
              >  
                Add Room
              </button>
            </div>
          </div>
        ))}
      </div>
    </div>
  );
}

export default VendorRoomPage;
