import React, { useState, useEffect } from "react";
import LoginImage from '../Assets/loginPagePic.jpg';
import './UserHotelList.css';
import { Link } from "react-router-dom";
import FeedbackRating from './FeedbackRating';
import UserNavbar from "./UserNavbar";

function UserHotelList() {
  const [hotels, setHotels] = useState([]);
  const [searchState, setSearchState] = useState("");
  const [searchCity, setSearchCity] = useState("");
  
  useEffect(() => {
    fetchHotels();
  }, []);

  const fetchHotels = () => {
    fetch('http://localhost:5007/api/Hotel/GetAllHotels')
      .then(response => response.json())
      .then(data => {
        console.log(data);
        setHotels(data);
      })
      .catch(error => console.log(error));
  };

  const handleStateChange = (event) => {
    setSearchState(event.target.value);
  };

  const handleCityChange = (event) => {
    setSearchCity(event.target.value);
  };

  const filterHotels = () => {
    let filteredHotels = hotels;

    if (searchState.trim() !== "") {
      filteredHotels = filteredHotels.filter(hotel => hotel.state.toLowerCase().includes(searchState.toLowerCase()));
    }

    if (searchCity.trim() !== "") {
      filteredHotels = filteredHotels.filter(hotel => hotel.city.toLowerCase().includes(searchCity.toLowerCase()));
    }

    return filteredHotels;
  };

  return (
    <div className="mainDiv">
      <div className="navBar">
        <UserNavbar />
      </div>
      <div className="filterContainer">
        <div className="filterItem">
          <label>State:</label>
          <input type="text" value={searchState} onChange={handleStateChange} placeholder="Search hotels by state"/>
        </div>
        <div className="filterItem">
          <label>City:</label>&nbsp;&nbsp;
          <input type="text" value={searchCity} onChange={handleCityChange} placeholder="Search hotels by city"/>
        </div>
      </div>
      {filterHotels().length === 0 ? (
        <div className="noHotelsMessage">
          <p>Oops! There are no hotels available.</p>
        </div>
      ) : (
        <div className="hotelCardContainer">
          {filterHotels().map(hotel => (
            <div key={hotel.hotelId} className="hotelCard">
              <Link to={`/hotelInfo/${hotel.hotelId}`} className="hotelImage">
                <img src={LoginImage} alt="Hotel" />
              </Link>
              <div className="hotelInfo">
                <h3>{hotel.hotelName}</h3>
                <FeedbackRating hotelId={hotel.hotelId} />
              </div>
            </div>
          ))}
        </div>
      )}
    </div>
  );
}

export default UserHotelList;
