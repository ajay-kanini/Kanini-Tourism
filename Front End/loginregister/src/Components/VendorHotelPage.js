import React, { useState, useEffect } from "react";
import VendorNavbar from "./VendorNavbar";
import LoginImage from '../Assets/loginPagePic.jpg';
import './UserHotelList.css';
import { Link } from "react-router-dom";
import FeedbackRating from './FeedbackRating';
import { FaPlus } from 'react-icons/fa';
import AddHotelCard from "./AddHotelCard";
import { useNavigate} from 'react-router-dom'
import { toast, ToastContainer } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';

function VendorHotelPage() {

  const navigate = useNavigate();
  const [hotels, setHotels] = useState([]);
  const [agents, setAgents] = useState([]);
  var id = Number(localStorage.getItem("Id"));

  useEffect(() => {
    hotelsByAgent();
    agentDetails();
  }, []);

  const hotelsByAgent = () => {
    fetch(`http://localhost:5007/api/Hotel/GetByAgent/${id}`)
      .then(response => response.json())
      .then(data => {
        setHotels(data);
      })
      .catch(error => console.log(error));
  };
  
  const agentDetails = () => {
    fetch(`http://localhost:5294/api/Register/GetOneAgent?key=${id}`)
    .then(async (data) => {
      if (data.status == 200) {
        var myData = await data.json();
        setAgents(await myData);   
        console.log(data);
      } 
      if (myData.status == "Not Approved") {
        toast.error("oops you are not approved")
        navigate('/message');
      }
    });
  }

  return (
    <div className="mainDiv">
      <div className="navBar">
        <VendorNavbar />
      </div>
      
      <div className="hotelCardContainer">
        {hotels.map(hotel => (
          <div key={hotel.hotelId} className="hotelCard">
            <div className="hotelImage">
              <img src={LoginImage} alt="Hotel" />
            </div>
            <div className="hotelInfo">
              <h3>{hotel.hotelName}</h3>
              <FeedbackRating hotelId={hotel.hotelId} />
            </div>
          </div>
        ))}
        {/* Add the AddHotelCard here */}
        <div className="hotelCard addHotelCard">
           <AddHotelCard/>
          </div>
        </div>
      </div>
  );
}

export default VendorHotelPage;
