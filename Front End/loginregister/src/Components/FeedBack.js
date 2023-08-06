import React, { useState, useEffect } from "react";
import { Navbar, Nav } from "react-bootstrap";
import LoginImage from "../Assets/loginPagePic.jpg";
import './VendorRegister.css'
function Feedback() {
  const [checkUser, setCheckUser] = useState({
    "userId": 0,
    "hotelId": 0,
  });

  const [feedback, setFeedback] = useState({
   "feedbackId": 0,
    "userId": 1,
    "hotelId": 1,
    "feedbackDescription": "",
    "points": 5,
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
          alert("ok");
        } else {
          alert("not ok");
        }
      })
      .catch((err) => {
        console.log(err.error);
      });
  };

  var userCheck = () => {
    fetch("http://localhost:5035/api/Booking/UserCheck", {
      method: "POST",
      headers: {
        accept: "text/plain",
        "Content-Type": "application/json",
      },
      body: JSON.stringify({ ...checkUser, checkUser: {} }),
    })
      .then(async (data) => {
        setCheckUser(data);
        if (data.status === 200) {
          alert("ok");
        } else {
          alert("not ok");
        }
      })
      .catch((err) => {
        console.log(err.error);
      });
  };

  useEffect(() => {
    //userCheck();
  }, []);

  return (
    <div className="mainDiv">
      <div className="navBar">
        <Navbar className="custom-navbar" expand="lg">
          <Navbar.Brand href="#">Book Your Hotel</Navbar.Brand>
          <Navbar.Toggle aria-controls="basic-navbar-nav" />
          <Navbar.Collapse id="basic-navbar-nav">
            <Nav className="mr-auto">
              <Nav.Link href="#home">Home</Nav.Link>
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