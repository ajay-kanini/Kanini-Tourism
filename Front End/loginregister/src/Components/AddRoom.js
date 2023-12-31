import React, { useState } from "react";
import './AddRoom.css'; 
import LoginImage from '../Assets/loginPagePic.jpg';
import VendorNavbar from './VendorNavbar';
import { useParams } from "react-router-dom";
import { ToastContainer, toast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';

function AddRoom() {
  const { hotelId } = useParams();
  
  const [room, setRoom] = useState({
    "roomId": 0,
    "roomPricePerDay": 0,
    "acAvailability": true,
    "numberOfPersons": 5,
    "roomAvailability": true,
    "hotelId": hotelId
  });

  const handleRoomPricePerDayChange = (event) => {
    const newPrice = parseFloat(event.target.value);
    if (newPrice >= 0) {
      setRoom({ ...room, "roomPricePerDay": newPrice });
    } else {
      toast.error('Room price cannot be negative.');
    }
  };

  const handleAcAvailabilityChange = (event) => {
    setRoom({ ...room, "acAvailability": event.target.value === "true" });
  };

  const addRoom = (event) => {
    event.preventDefault();

    if (room.roomPricePerDay === 0) {
      toast.error('Room price cannot be null.');
      return;
    }

    fetch("http://localhost:5007/api/Room/AddRoom", {
      "method": "POST",
      headers: {
        "accept": "text/plain",
        "Content-Type": 'application/json'
      },
      "body": JSON.stringify({ ...room, "room": {} })
    })
      .then(async (data) => {
        if (data.status === 200) {
          toast.success('Room added successfully.');
        } else {
          toast.error('Failed to add room.');
        }
      })
      .catch((err) => {
        console.log(err.error);
      });
  };

  return (
    <div>
      <div className="room-navBar">
        <VendorNavbar />
      </div>
      <div className="room-mainDiv">
        <div className="room-add-hotel">
          <div className="room-register-container">
            <div className="room-register">
              <div className="room-register-card">
                <div className="room-register-form">
                  <div className="room-register-left-side">
                    <img src={LoginImage} alt="Login" />
                  </div>
                  <div className="room-register-right-side">
                    <div className="room-register-hello">
                      <h2>Welcome !!!</h2>
                    </div>
                    <form>
                      <div className="room-register-input_text">
                        <label htmlFor="roomPricePerDay">Room Price Per Day:</label>
                        <input
                          type="number"
                          id="roomPricePerDay"
                          name="roomPricePerDay"
                          onChange={handleRoomPricePerDayChange}
                          step="1"
                          value={room.roomPricePerDay}
                          className="room-register-warning"
                        />
                      </div>

                      <div className="room-register-input_text">
                        <label>Number of Persons/Room:</label>
                        <input
                          type="number"
                          name="persons"
                          onChange={(event) => {
                            setRoom({ ...room, "numberOfPersons": event.target.value });
                          }}
                          value={room.numberOfPersons}
                          className="room-register-warning"
                        />
                      </div>

                      <div className="room-register-radio-group">
                        <label>AC Availability:</label>
                        <div className="room-register-radio">
                          <input
                            type="radio"
                            id="acAvailabilityYes"
                            name="acAvailability"
                            value="true"
                            checked={room.acAvailability}
                            onChange={handleAcAvailabilityChange}
                          />
                          <label htmlFor="acAvailabilityYes">Yes</label>
                        </div>

                        <div className="room-register-radio">
                          <input
                            type="radio"
                            id="acAvailabilityNo"
                            name="acAvailability"
                            value="false"
                            checked={!room.acAvailability}
                            onChange={handleAcAvailabilityChange}
                          />
                          <label htmlFor="acAvailabilityNo">No</label>
                        </div>
                      </div>

                      <div className="room-register-btn">
                        <button type="submit" onClick={addRoom}>Add Room</button>
                      </div>
                    </form>
                    <hr className="room-register-hr" />
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

export default AddRoom;
