import React, { useState, useEffect } from "react";
import './AddRoom.css'; 
import VendorNavbar from './VendorNavbar';
import { Button, Modal, Box } from "@mui/material";
import { useParams } from "react-router-dom";
import UserNavbar from "./UserNavbar";
import { ToastContainer, toast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';

function Booking() {
  const [rId, setRId] = useState();
  const [open, setOpen] = useState(false);
  const [room, setRoom] = useState([]);
  const { hotelId } = useParams();
  const [user, setUser] = useState({});
  const [hotel, setHotel] = useState({});
  const [roomDetails, setRoomDetails] = useState({});
  const [bookRoom, setBookRoom] = useState({
    "bookingId": 0,
    "bookingStatus": "",
    "checkIn": new Date(0),
    "checkOut": new Date(0),
    "userId": 0,
    "userName": "",
    "hotelId": 0,
    "hotelName": "",
    "roomId": 0,
    "totalPrice": 0,
    "cancelRoom": true
  });

  var userId = localStorage.getItem("Id");

  useEffect(() => {
    fetchUserData();
    fetchRoomData();
    fetchHotelData();
  }, [hotelId]);

  const style = {
    position: 'absolute',
    top: '50%',
    left: '50%',
    transform: 'translate(-50%, -50%)',
    width: 400,
    bgcolor: 'background.paper',
    border: '2px solid #000',
    boxShadow: 24,
    p: 4,
  };

  const btnModal = {
    marginTop: '20px',
    marginRight: '10px',
  };

  const handleOpen = (roomId) => {
    setRId(roomId);
    setOpen(true);
  };

  const handleClose = () => setOpen(false);

  const fetchUserData = () => {
    fetch(`http://localhost:5294/api/Register/GetOneClient?key=${userId}`)
      .then(response => response.json())
      .then(data => {
        setUser(data);
      })
      .catch(error => console.log(error));
  };

  const fetchRoomData = () => {
    fetch(`http://localhost:5007/api/Room/GetRoomByHotelID/${hotelId}`)
      .then(response => response.json())
      .then(data => {
        setRoom(data);
      })
      .catch(error => console.log(error));
  };

  const fetchHotelData = () => {
    fetch(`http://localhost:5007/api/Hotel/GetHotelById/${hotelId}`)
      .then(response => response.json())
      .then(data => {
        setHotel(data);
      })
      .catch(error => console.log(error));
  };

  useEffect(() => {
    if (rId) {
      fetchRoomDetails();
    }
  }, [rId]);

  const fetchRoomDetails = () => {
    fetch(`http://localhost:5007/api/Room/GetRoomByRoomID/${rId}`)
      .then(response => response.json())
      .then(data => {
        setRoomDetails(data);
      })
      .catch(error => console.log(error));
  };

  const handleBookRoom = (event) => {
    event.preventDefault();

    // Validate start date and end date
    const currentDate = new Date();
    const checkInDate = new Date(bookRoom.checkIn);
    const checkOutDate = new Date(bookRoom.checkOut);
    if (checkInDate < currentDate || checkOutDate < currentDate) {
      toast.error('Check-in and Check-out dates should be after the current date.');
      return;
    }

    // Validate credit card number
    const creditCardNumber = document.getElementById('creditCard').value;
    if (creditCardNumber.length < 16) {
      toast.error('Credit card number should have at least 16 digits.');
      return;
    }

    // Rest of the code to proceed with booking if validation passes
    const bookingData = {
      "bookingId": 0,
      "bookingStatus": "",
      "checkIn": bookRoom.checkIn,
      "checkOut": bookRoom.checkOut,
      "userId": user.userId,
      "userName": user.name,
      "hotelId": hotel.hotelId,
      "hotelName": hotel.hotelName,
      "roomId": rId,
      "totalPrice": calculateTotalPrice(),
      "cancelRoom": true
    };
  
    fetch("http://localhost:5035/api/Booking/BookRooms", {
      "method": "POST",
      headers: {
        "accept": "text/plain",
        "Content-Type": 'application/json'
      },
      "body": JSON.stringify(bookingData)
    })
      .then(response => {
        if (response.ok) {
          toast.success('Booking Successful');
          return response.json();
        } else {
          toast.error('Oops room is already booked on that');
          throw new Error('Network response was not ok.');
        }
      })
      .then(data => {        
        console.log(data);
      })
      .catch((err) => {
        console.log(err);
        toast.error('Failed to book. An error occurred.');
      });
  };

  const calculateTotalPrice = () => {
    const checkInDate = new Date(bookRoom.checkIn);
    const checkOutDate = new Date(bookRoom.checkOut);
    const roomPricePerDay = roomDetails.roomPricePerDay;
    const timeDiff = Math.abs(checkOutDate.getTime() - checkInDate.getTime());
    const numberOfDays = Math.ceil(timeDiff / (1000 * 3600 * 24));
    const totalPrice = numberOfDays * roomPricePerDay;
    return totalPrice;
  };

  return (
    <div>
      <div className="navBar">
        <UserNavbar />
      </div>
      <div className="roomDatas">
        {room.map((roomData, index) => (
          <div key={roomData.roomId} className="roomCard">
            <h3>Room {index + 1}</h3>
            <p>Price per Day: {roomData.roomPricePerDay}</p>
            <p>AC Availability: {roomData.acAvailability ? "Available" : "Not Available"}</p>
            <p>Maximum Head Count: {roomData.numberOfPersons}</p>
            <Button onClick={() => handleOpen(roomData.roomId)}>Book Room</Button>
          </div>
        ))}
      </div>
      <Modal
        open={open}
        onClose={handleClose}
        aria-labelledby="modal-modal-title"
        aria-describedby="modal-modal-description"
      >
        <Box sx={style}>
          <div className="room-register-input_text">
            <label htmlFor="startDate">CheckIn Date:</label>
            <input
              type="date"
              id="startDate"
              name="startDate"
              onChange={(event) => {
                setBookRoom({ ...bookRoom, "checkIn": event.target.value });
              }}
              className="room-register-warning"
            />
          </div>
          <div className="room-register-input_text">
            <label htmlFor="endDate">CheckOut Date:</label>
            <input
              type="date"
              id="endDate"
              name="endDate"
              onChange={(event) => {
                setBookRoom({ ...bookRoom, "checkOut": event.target.value });
              }}
              className="room-register-warning"
            />
          </div>
          <div className="room-register-input_text">
            <label htmlFor="creditCard">Credit Card Number:</label>
            <input
              type="number"
              id="creditCard"
              name="creditCard"                            
              className="room-register-warning"
            />
          </div>
          <div>
            <button type="button" style={btnModal} className="btn btn-primary" onClick={handleBookRoom}>
              Book Room
            </button>
            <button type="button" style={btnModal} className="btn btn-secondary" onClick={handleClose}>
              Close
            </button>
          </div>
        </Box>
      </Modal>
    </div>
  );
}

export default Booking;
