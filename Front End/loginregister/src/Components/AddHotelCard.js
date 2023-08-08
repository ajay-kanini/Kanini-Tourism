    import React from 'react';
    import { FaPlus } from 'react-icons/fa';
    import { Link } from "react-router-dom";
    import './AddHotelCard.css';

    function AddHotelCard() {
    return (
        <div className="hotelCard">
        <div className="plusIconContainer">
            <Link to="/addHotel">
            <div className="plusIconWrapper">
                <FaPlus className="plusIcon" />
            </div>
            </Link>
        </div>
        </div>
    );
    }

    export default AddHotelCard;
