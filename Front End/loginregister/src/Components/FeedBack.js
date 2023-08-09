import React, { useState, useEffect } from "react";
import { Navbar, Nav } from "react-bootstrap";
import LoginImage from "../Assets/loginPagePic.jpg";
import { useParams } from "react-router-dom";
import './VendorRegister.css'
import {Link, useNavigate} from 'react-router-dom';
import { ToastContainer, toast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';
import Logo from '../Assets/logo-removebg-preview.png';
function Feedback() {

  const {hotelId} = useParams();
  const navigate = useNavigate();
  const [checkUser, setCheckUser] = useState({
    "userId": 0,
    "hotelId": 0,
  }); 
 
  const id = Number(localStorage.getItem("Id"));
  const mail = localStorage.getItem("mail");
  const [feedback, setFeedback] = useState({
  "feedbackId": 0,
  "userId": id,
  "mail": mail,
  "hotelId": hotelId,
  "feedbackDescription": "",
  "points": 5
  });

  const generateStarRating = (points) => {
    const totalStars = 5;
    const stars = Array.from({ length: totalStars }, (_, index) => (
      <span
        key={index}
        className={index < points ? "star filled" : "star"}
        onClick={() => setFeedback({ ...feedback, points: index + 1 })}
      >
        &#9733;
      </span>
    ));
    return stars;
  };

  var submitFeedback = (event) => {
    event.preventDefault();
    fetch("http://localhost:5114/api/Feedback/AddFeedback", {
      method: "POST",
      headers: {
        accept: "text/plain",
        "Content-Type": "application/json",
      },
      body: JSON.stringify({ ...feedback, "feedback": {} }),
    })
      .then(async (data) => {
        setFeedback(data);
        if (data.status === 200) {
          toast.success("Thank you...");
        } else {
          toast.error("Feedback is not updated.");
        }
      })
      .catch((err) => {
        console.log(err.error);
      });
  };
  const homeNavigation= () =>{
    navigate("/");
  }
  const clearStorage= () =>{
    localStorage.clear();
    navigate("/login");
  }
  return (
    <div className="mainDiv">
      <div className="navBar">
        <Navbar className="custom-navbar" expand="lg">
        <img src={Logo} style={{margin:"10px"}}/>
          <Navbar.Brand href="#">Book Your Hotel</Navbar.Brand>
          <Navbar.Toggle aria-controls="basic-navbar-nav" />
          <Navbar.Collapse id="basic-navbar-nav">
            <Nav className="mr-auto">
              <Nav.Link  onClick={homeNavigation} >Home</Nav.Link>
              <Nav.Link onClick={clearStorage} >Log Out</Nav.Link>
            </Nav>
            <h1 className="navbar-heading">FeedBack</h1>
          </Navbar.Collapse>
        </Navbar>
      </div>
      <div className="register-container" style={{marginTop:"-25px"}}>
        <div className="register">
          <div className="register-card">
            <div className="register-form">
              <div className="register-left-side">
                <img src={LoginImage} alt="Login" />
              </div>
              <div className="register-right-side">
                <div className="register-hello">
                  <h2>Your Feedback Matters !!!</h2>
                </div>
                <form>
                  <div className="register-input_address">
                    <textarea 
                      className="register-warning"
                      placeholder="Write Your Feedback Here..."
                      name="feedback"
                      onChange={(event) =>
                        setFeedback({
                          ...feedback,
                          feedbackDescription: event.target.value,
                        })
                      }
                      style={{ height: "100px",marginTop:"20px" }}
                    />
                  </div>
                  <div className="star-rating">
                  <label style={{fontSize:"Smaller", marginTop:"20px", marginBottom:"20px"}}>
                    Please provide star rating  &nbsp;&nbsp; </label>
                    {generateStarRating(feedback.points)}
                  </div>
                  <div className="register-btn">
                    <button type="submit" onClick={submitFeedback}>
                      Submit
                    </button>
                  </div>
                </form>
                <hr className="register-hr" />
              </div>
            </div>
          </div>
        </div>
      </div>
      <style>
        {`
          .star-rating {
            font-size: 24px;
          }

          .star {
            color: #9897A9;
            cursor: pointer;
          }

          .star.filled {
            color: #ffaf00;
          }

          /* Add any other custom styles for the page here */
        `}
      </style>
    </div>
  );
}

export default Feedback;
