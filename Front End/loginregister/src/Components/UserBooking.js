import React, { useState, useEffect } from "react";
import UserNavbar from "./UserNavbar";
import './UserBooking.css';
import { saveAs } from 'file-saver';
import jsPDF from 'jspdf';

function UserBooking() {
  const [booking, setBooking] = useState([]);
  const userId = Number(localStorage.getItem("Id"));

  useEffect(() => {
    fetchBookingData();
  }, []);

  const fetchBookingData = () => {
    fetch(`http://localhost:5035/api/Booking/GetByUserID/${userId}`)
      .then(response => {
        if (!response.ok) {
          throw new Error('Network response was not ok.');
        }
        return response.json();
      })
      .then(data => {
        setBooking(data);
      })
      .catch(error => console.error('Error fetching booking data:', error));
  };


  // Function to generate the PDF when the "Print" button is clicked
  const handlePrintButtonClick = (bookingItem) => {
    // Create a new instance of jsPDF
    const pdf = new jsPDF();

    // Generate the content for the PDF
    const content = `
      Thank You For Choosing "Book Your Hotel"
      Booking Details
      User Name: ${bookingItem.userName}
      Hotel Name: ${bookingItem.hotelName}
      Room ID: ${bookingItem.roomId}
      Number of Days: ${bookingItem.numberOfDays}
      Total Price: ${bookingItem.totalPrice}
    `;

    // Set the content on the PDF
    pdf.text(content, 10, 10);

    // Save the PDF
    pdf.save(`booking_${bookingItem.bookingId}.pdf`);
  };

  return (
    <div className="mainDiv">
      <div className="navBar">
        <UserNavbar />
      </div>
      <div className="bookingDatas">
        {booking.map(bookingItem => (
          <div key={bookingItem.bookingId} className="bookingCard">
            <p>User Name: {bookingItem.userName}</p>
            <p>Hotel Name: {bookingItem.hotelName}</p>
            <p>Room ID: {bookingItem.roomId}</p>
            <p>Number of Days: {bookingItem.numberOfDays}</p>
            <p>Total Price: {bookingItem.totalPrice}</p>       
            <button onClick={() => handlePrintButtonClick(bookingItem)}>Print</button>
          </div>
        ))}
      </div>
    </div>
  );
}

export default UserBooking;
