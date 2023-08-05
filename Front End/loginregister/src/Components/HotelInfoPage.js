// import React, { useState, useEffect } from "react";
// import VendorNavbar from "./VendorNavbar";
// import LoginImage from '../Assets/loginPagePic.jpg';
// import LoginImage2 from '../Assets/login2.jpg';
// import Carousel from '@mui/material/Carousel';
// import { Paper, Button } from '@mui/material';

// function HotelInfoPage()
// {
//     const items = [
//         {
//           name: "Random Name #1",
//           description: "Probably the most random thing you have ever seen!",
//           image: {LoginImage},
//         },
//         {
//           name: "Random Name #2",
//           description: "This is another random name. It's not as random as the first one, though.",
//           image: {LoginImage2},
//         },
//         {
//           name: "Random Name #3",
//           description: "This is the last random name. I promise.",
//           image: {LoginImage},
//         },
//       ];
//     return(
//     <div className="mainDiv">
//         <div className="navBar">
//            <VendorNavbar/>     
//         </div>
//         <div className="carousel">
//         <Carousel>
//         {items.map((item, index) => (
//             <Paper key={index} style={{ width: '100%' }}>
//             <img src={item.image} alt={item.name} />
//             <h3>{item.name}</h3>
//             <p>{item.description}</p>
//             </Paper>
//         ))}
//         </Carousel>   
//         </div>
//     </div>
//     );
// }

// export default HotelInfoPage;