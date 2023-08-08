import React, { useState, useEffect } from "react";
import UserNavbar from "./UserNavbar";
import LoginImage from '../Assets/loginPagePic.jpg';
import LoginImage2 from '../Assets/beautiful-luxury-outdoor-swimming-pool-hotel-resort.jpg';
import './HotelInfoPage.css';
import { useParams } from "react-router-dom";
import { CCarousel, CCarouselItem, CImage } from '@coreui/react';
import { Link, useNavigate } from "react-router-dom";

function HotelInfoPage() {

  const navigate = useNavigate();

  const [hotel, setHotel] = useState({
    "hotelId": 0,
    "hotelName": "",
    "hotelDescription": "",
    "city": "",
    "state": "",
    "address": "",
    "contactNumber": "",
    "agentId": 0
  });

  const [feedbacks, setFeedback] = useState([]);

  const { hotelId } = useParams();

  useEffect(() => {
    fetchHotelData();
    fetchHotelFeedbacks();
  }, [hotelId]);

  const fetchHotelData = () => {
    fetch(`http://localhost:5007/api/Hotel/GetHotelById/${hotelId}`)
      .then(response => response.json())
      .then(data => {
        console.log(data);
        setHotel(data);
      })
      .catch(error => console.log(error));
  };

  const fetchHotelFeedbacks = () => {
    fetch(`http://localhost:5114/api/Feedback/GetFeedbackByHotelId?id=${hotelId}`)
      .then(response => response.json())
      .then(data => {
        console.log(data);
        setFeedback(data);
      })
      .catch(error => console.log(error));
  };

  const renderStars = (points) => {
    const filledStars = Math.round(points); // Number of filled stars
    const totalStars = 5; // Total number of stars
    return (
      <div className="starIcons">
        {[...Array(totalStars)].map((_, index) => (
          <i
            key={index}
            className={`fa fa-star${index < filledStars ? "" : "-o"}`}
          ></i>
        ))}
      </div>
    );
  };
  const roomDetails = (hotelId) => {
    navigate(`/booking/${hotelId}`);
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
      <div className="hotelDetailsAndBookRooms">
        <div className="hotelDetails">
          <h2>{hotel.hotelName}</h2>
          <p>City: {hotel.city}</p>
          <p>State:  {hotel.state}</p>
          <p>Contact Number: {hotel.contactNumber}</p>
          <p>Address: {hotel.address}</p>
          <p>Description: {hotel.hotelDescription}</p>
          <Link to={`/feedback/${hotelId}`} className="feedbackButton">Give Feedback</Link>
        </div>
        <div className="bookRooms">
          <div className="bookRoomsGrid">
            <button className="bookButton" onClick={()=>roomDetails(hotel.hotelId)}>Book Room</button>
            <button className="bookButton" onClick={()=>roomDetails(hotel.hotelId)}>Book Room</button>
            <button className="bookButton" onClick={()=>roomDetails(hotel.hotelId)}>Book Room</button>
            <button className="bookButton" onClick={()=>roomDetails(hotel.hotelId)}>Book Room</button>
          </div>
        </div>
      </div>
      <h3>Feedbacks:</h3>
      <div className="getHotelFeedbacks">
        {feedbacks.length === 0 ? (
          <p>No feedbacks available.</p>
        ) : (
          feedbacks.map((feedback) => (
            <div key={feedback.feedbackId} className="feedbackItemHotels">
              <p>Email: {feedback.mail}</p>
              <p>Rating: {renderStars(feedback.points)}</p>
              <p>Description: {feedback.feedbackDescription}</p>
            </div>
          ))
        )}
      </div>
    </div>
  );
}

export default HotelInfoPage;
