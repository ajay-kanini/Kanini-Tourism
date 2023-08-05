import React, { useState } from "react";
import './AddRoom.css'; // Import the new CSS file
import LoginImage from '../Assets/loginPagePic.jpg';
import VendorNavbar from './VendorNavbar';

function AddRoom() {
  const [room, setRoom] = useState({
    "roomId": 0,
    "roomNumber": "",
    "roomPricePerDay": 0,
    "acAvailability": true,
    "roomAvailability": true,
    "numberOfPersons": 5,
    "hotelId": 1
  });

  const handleRoomNumberChange = (event) => {
    setRoom({ ...room, "roomNumber": event.target.value });
  };

  const handleRoomPricePerDayChange = (event) => {
    setRoom({ ...room, "roomPricePerDay": parseFloat(event.target.value) });
  };

  const handleAcAvailabilityChange = (event) => {
    setRoom({ ...room, "acAvailability": event.target.value === "true" });
  };

  const addRoom = (event) => {
    event.preventDefault();
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
          alert('Room added successfully.');
        } else {
          alert('Failed to add room.');
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
                        <label htmlFor="roomNumber">Room Number:</label>
                        <input
                          type="text"
                          id="roomNumber"
                          name="roomNumber"
                          onChange={handleRoomNumberChange}
                          value={room.roomNumber}
                          className="room-register-warning"
                        />
                      </div>
                      <div className="room-register-input_text">
                        <label htmlFor="roomPricePerDay">Room Price Per Day:</label>
                        <input
                          type="number"
                          id="roomPricePerDay"
                          name="roomPricePerDay"
                          onChange={handleRoomPricePerDayChange}
                          step="0.01"
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
                        <button type="submit" onClick={addRoom}>Add Hotel</button>
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
