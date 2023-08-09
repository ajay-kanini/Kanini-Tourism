import React, { useState, useEffect } from "react";

const FeedbackRating = ({ hotelId }) => {
  const [rating, setRating] = useState({
    feedBackRating: 0,
    feedBackCount: 0,
  });

  useEffect(() => {
    fetchRatings();
  }, [hotelId]);

  const fetchRatings = () => {
    fetch(`http://localhost:5114/api/Feedback/RatingCalculation?id=${hotelId}`)
      .then((response) => response.json())
      .then((data) => {
        setRating(data);
      })
      .catch((error) => console.log(error));
  };

  const starCount = 5; // Total number of stars
  const filledStars = Math.round(rating.feedBackRating); // Number of filled stars
  const emptyStars = starCount - filledStars; // Number of empty stars

  return (
    <div style={{ display: "flex", alignItems: "center", justifyContent: "center" }}>
      <div style={{ display: "flex" }}>
        {[...Array(filledStars)].map((_, index) => (
          <i
            key={index}
            className="fa fa-star"
            style={{ color: "gold" }}
          ></i>
        ))}
        {[...Array(emptyStars)].map((_, index) => (
          <i
            key={index + filledStars}
            className="fa fa-star"
            style={{ color: "#ccc" }}
          ></i>
        ))}
      </div>
      <span style={{ marginLeft: "5px" }}>({rating.feedBackCount})</span>
    </div>
  );
};

export default FeedbackRating;
