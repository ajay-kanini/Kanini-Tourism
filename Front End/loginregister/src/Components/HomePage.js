import React from "react";
import { CCarousel, CCarouselItem, CImage } from '@coreui/react';
import { Navbar, Nav } from "react-bootstrap";
import "./HomePage.css"; // Import the CSS file
import LoginImage from '../Assets/large-pool-with-umbrellas-hammocks.jpg';
import LoginImage2 from '../Assets/beautiful-luxury-outdoor-swimming-pool-hotel-resort.jpg';
import LoginImage3 from '../Assets/image1.jpg';
import LoginImage4 from '../Assets/bed-beach.jpg';
import LoginImage5 from '../Assets/glassclad-skyscrapers-central-mumbai-reflecting-sunset-hues-blue-hour.jpg';
import LoginImage6 from '../Assets/pool-relaxation-sea-scene-nature.jpg';
import Logo from '../Assets/logo-removebg-preview.png';
import {Link, useNavigate} from 'react-router-dom';

function HomePage() {
    const navigate=useNavigate();

    const loginNavigate = () =>{
        navigate("/login");
    }
  
    return (
    <div className="homePage-mainDiv">
      <div className="homePage-navBar">
        <Navbar className="custom-navbar" expand="lg">
        <img src={Logo} style={{margin:"10px"}}/>
          <Navbar.Brand href="#">Book Your Hotel</Navbar.Brand>
          <Navbar.Toggle aria-controls="basic-navbar-nav" />
          <Navbar.Collapse id="basic-navbar-nav">
            <Nav className="mr-auto">
              <Nav.Link >Home</Nav.Link>
            </Nav>
            <Nav className="mr-auto">
              <Nav.Link onClick={loginNavigate}>Login</Nav.Link>
            </Nav>
            <h1 className="navbar-heading">Welcome to Heavens...</h1>
          </Navbar.Collapse>
        </Navbar>
      </div>
      <div className="homePage-c-carousel" style={{ marginTop: "10px" }}>
        <CCarousel controls interval={1000} transition="crossfade">
          <CCarouselItem>
            <CImage className="carouselImage" src={LoginImage} alt="slide 1" style={{ height: "500px", width: "100%" }} />
          </CCarouselItem>
          <CCarouselItem>
            <CImage className="carouselImage" src={LoginImage2} alt="slide 2" style={{ height: "500px", width: "100%" }} />
          </CCarouselItem>
          <CCarouselItem>
            <CImage className="carouselImage" src={LoginImage3} alt="slide 3" style={{ height: "500px", width: "100%" }} />
          </CCarouselItem>
        </CCarousel>
      </div>
      <div className="homePage-stateCards">
        <h2 className="homePage-section-title">Popular States</h2>
        <div className="homePage-card-container">
          <div className="homePage-card">
            <img src={LoginImage4} alt="Chennai" />
            <h3>Chennai</h3>
          </div>
          <div className="homePage-card">
            <img src={LoginImage5} alt="Mumbai" />
            <h3>Mumbai</h3>
          </div>
          <div className="homePage-card">
            <img src={LoginImage6} alt="Bangalore" />
            <h3>Bangalore</h3>
          </div>
        </div>
        <div className="homePage-card homePage-about-us-card">
          <h2>About Us</h2>
          <p>
            Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed ut pretium dui. Nullam accumsan gravida odio.
            Ut non magna rhoncus, euismod ex quis, commodo odio. Etiam feugiat mi ac urna pellentesque, vel ultrices
            nisl cursus. Proin at mauris libero. In vestibulum nulla mauris, eget aliquam libero gravida at. Vivamus nec
            dolor ut quam bibendum vulputate. Etiam vel felis eu orci ultrices tempor non id nunc. Ut ullamcorper lectus
            odio, in facilisis lacus bibendum in.  Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed ut pretium dui.
            Ut non magna rhoncus, euismod ex quis, commodo odio. Etiam feugiat mi ac urna pellentesque, vel ultrices
            nisl cursus. Proin at mauris libero. In vestibulum nulla mauris, eget aliquam libero gravida at. Vivamus nec
            dolor ut quam bibendum vulputate. Etiam vel felis eu orci ultrices tempor non id nunc. Ut ullamcorper lectus
            odio, in facilisis lacus bibendum in. Nullam accumsan gravida odio.
          </p>
        </div>
        <div className="footer" style={{marginTop:"10px"}}>
          <footer className="text-center text-white" style={{ backgroundColor: "#98FB98" }}>
            <div className="container p-4">
              <section className="">
                <div className="row">
                  <div className="col-lg-2 col-md-12 mb-4 mb-md-0">
                    <div className="bg-image hover-overlay ripple shadow-1-strong rounded" data-ripple-color="light">
                      <img src="https://mdbcdn.b-cdn.net/img/new/fluid/city/113.webp" className="w-100" alt="City 1" />
                      <a href="#!">
                        <div className="mask" style={{ backgroundColor: "rgba(251, 251, 251, 0.2)" }}></div>
                      </a>
                    </div>
                  </div>
                  <div className="col-lg-2 col-md-12 mb-4 mb-md-0">
                    <div className="bg-image hover-overlay ripple shadow-1-strong rounded" data-ripple-color="light">
                      <img src="https://mdbcdn.b-cdn.net/img/new/fluid/city/111.webp" className="w-100" alt="City 2" />
                      <a href="#!">
                        <div className="mask" style={{ backgroundColor: "rgba(251, 251, 251, 0.2)" }}></div>
                      </a>
                    </div>
                  </div>
                  <div className="col-lg-2 col-md-12 mb-4 mb-md-0">
                    <div className="bg-image hover-overlay ripple shadow-1-strong rounded" data-ripple-color="light">
                      <img src="https://mdbcdn.b-cdn.net/img/new/fluid/city/112.webp" className="w-100" alt="City 3" />
                      <a href="#!">
                        <div className="mask" style={{ backgroundColor: "rgba(251, 251, 251, 0.2)" }}></div>
                      </a>
                    </div>
                  </div>
                  <div className="col-lg-2 col-md-12 mb-4 mb-md-0">
                    <div className="bg-image hover-overlay ripple shadow-1-strong rounded" data-ripple-color="light">
                      <img src="https://mdbcdn.b-cdn.net/img/new/fluid/city/114.webp" className="w-100" alt="City 4" />
                      <a href="#!">
                        <div className="mask" style={{ backgroundColor: "rgba(251, 251, 251, 0.2)" }}></div>
                      </a>
                    </div>
                  </div>
                  <div className="col-lg-2 col-md-12 mb-4 mb-md-0">
                    <div className="bg-image hover-overlay ripple shadow-1-strong rounded" data-ripple-color="light">
                      <img src="https://mdbcdn.b-cdn.net/img/new/fluid/city/115.webp" className="w-100" alt="City 5" />
                      <a href="#!">
                        <div className="mask" style={{ backgroundColor: "rgba(251, 251, 251, 0.2)" }}></div>
                      </a>
                    </div>
                  </div>
                  <div className="col-lg-2 col-md-12 mb-4 mb-md-0">
                    <div className="bg-image hover-overlay ripple shadow-1-strong rounded" data-ripple-color="light">
                      <img src="https://mdbcdn.b-cdn.net/img/new/fluid/city/116.webp" className="w-100" alt="City 6" />
                      <a href="#!">
                        <div className="mask" style={{ backgroundColor: "rgba(251, 251, 251, 0.2)" }}></div>
                      </a>
                    </div>
                  </div>
                </div>
              </section>
            </div>
            <div className="text-center p-3" style={{color:"black"}}>
              © 2023 Book Your Hotel.com
            </div>
          </footer>
        </div>
      </div>
    </div>
  );
}

export default HomePage;
