import React, { useState, useEffect } from "react";
import { useParams } from "react-router-dom";
import './FetchRooms.css';
import VendorNavbar from "./VendorNavbar";

function FetchRooms() {
  const [room, setRoom] = useState([]);
  const { hotelId } = useParams();
 
  useEffect(() => {
    fetchRoomData();
  }, [hotelId]);

  const fetchRoomData = () => {
    console.log(hotelId);
    fetch(`http://localhost:5007/api/Room/GetRoomByHotelID/${hotelId}`)
      .then(response => response.json())
      .then(data => {
        if (Array.isArray(data)) {
          setRoom(data);
        }
      })
      .catch(error => console.log(error));
  };

  return (
    <div className="mainDiv">
      <div className="navBar">
        <VendorNavbar />
      </div>
      <div className="roomDatas">
        {room.length === 0 ? (
          <p>No rooms available</p>
        ) : (
          room.map((roomData, index) => (
            <div key={roomData.roomId} className="roomCard">
              <h3>Room {index + 1}</h3>
              <p>Price per Day: {roomData.roomPricePerDay}</p>
              <p>AC Availability: {roomData.acAvailability ? "Available" : "Not Available"}</p>
              <p>Maximum Head Count: {roomData.numberOfPersons}</p>
            </div>
          ))
        )}
      </div>
    </div>
  );
}

export default FetchRooms;
