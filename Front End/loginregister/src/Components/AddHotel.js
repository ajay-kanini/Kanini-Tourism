import React, { useState, useEffect } from "react";
import './VendorRegister.css'
import LoginImage from '../Assets/loginPagePic.jpg'
import VendorNavbar from './VendorNavbar';
import { Height, Hotel } from "@mui/icons-material";
import { ToastContainer, toast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';
import { BlobServiceClient } from "@azure/storage-blob";

function AddHotel() {
  const agentId = Number(localStorage.getItem("Id"));

  const [hotel, setHotel] = useState({
    "hotelId": 0,
    "hotelName": "",
    "hotelDescription": "",
    "city": "",
    "state": "",
    "address": "",
    "contactNumber": "",
    "image" : "",
    "agentId": agentId
  });
  const [imageFile, setImageFile] = useState(null);

  const handleImageChange = (event) => {
    const selectedImage = event.target.files[0];
    setImageFile(selectedImage);
  };

  var addHotel = (event) => {
    event.preventDefault();
    const AZURITE_BLOB_SERVICE_URL = 'http://localhost:10000';
    const ACCOUNT_NAME = 'devstoreaccount1';
    const ACCOUNT_KEY = 'Eby8vdM02xNOcqFlqUwJPLlmEtlCDXJ1OUzFT50uSRZ6IFsuFq2UVErCz4I6tq/K1SZFPTOtr/KBHBeksoGMGw==';

    const blobServiceClient = new BlobServiceClient(
      "http://127.0.0.1:10000/devstoreaccount1/hotels?sv=2018-03-28&st=2023-08-09T00%3A19%3A39Z&se=2023-08-10T00%3A19%3A39Z&sr=c&sp=racwdl&sig=A2I9VLyyRUCu6mu77jEOJ1oksQg32qvDeWKcerdIB2M%3D",
      "sv=2018-03-28&st=2023-08-09T00%3A19%3A39Z&se=2023-08-10T00%3A19%3A39Z&sr=c&sp=racwdl&sig=A2I9VLyyRUCu6mu77jEOJ1oksQg32qvDeWKcerdIB2M%3D"
    );

    const containerClient = blobServiceClient.getContainerClient('hotels');
      if (imageFile) {
        const blobClient = containerClient.getBlobClient(imageFile.name);
        const blockBlobClient = blobClient.getBlockBlobClient();
        const result = blockBlobClient.uploadBrowserData(imageFile, {
          blockSize: 4 * 1024 * 1024,
          concurrency: 20,
          onProgress: ev => console.log(ev)
        });
    }

    const updatedHotel = { ...hotel, "image": imageFile ? imageFile.name : "" };
    fetch("http://localhost:5007/api/Hotel/AddHotel", {
      "method": "POST",
      headers: {
        "accept": "text/plain",
        "Content-Type": 'application/json'
      },
      "body": JSON.stringify({ ...updatedHotel, "hotel": {} })
    })
      .then(async (data) => {
        if (data.status == 200) {
          toast.success("Hotel Added Successfully");
        }
        else {
          toast.error("Can't Add Hotel")
        }
      })
      .catch((err) => {
        console.log(err.error);
      });
  };
  return (
    <div>
      <div className="navBar">
        <VendorNavbar />
      </div>
      <div className="mainDiv">
        <div className="add-hotel">
          <div className="register-container">
            <div className="register">
              <div className="register-card">
                <div className="register-form">
                  <div className="register-left-side">
                    <img src={LoginImage} alt="Login" />
                  </div>
                  <div className="register-right-side">
                    <div className="register-hello">
                      <h2>Welcome !!!</h2>
                    </div>
                    <form >
                      <div className="register-input_text">
                        <input className="register-warning" type="text" placeholder="Enter Hotel Name" name="hotelName" onChange={(event) => {
                          setHotel({ ...hotel, "hotelName": event.target.value });
                        }} />
                        <input className="register-warning" type="text" placeholder="Enter City Name" name="city" onChange={(event) => {
                          setHotel({ ...hotel, "city": event.target.value });
                        }} />
                      </div>
                      <div className="register-input_text">
                        <input className="register-warning" type="text" placeholder="Enter State Name" name="state" onChange={(event) => {
                          setHotel({ ...hotel, "state": event.target.value });
                        }} />
                        <input className="register-warning" type="text" placeholder="Enter Contact Number" name="contact" onChange={(event) => {
                          setHotel({ ...hotel, "contactNumber": event.target.value });
                        }} />
                      </div>
                      <div className="register-input_text">
                        <input
                          className="register-warning"
                          type="file"
                          placeholder="Enter Hotel Image"
                          name="image"
                          onChange={handleImageChange} 
                        />
                      </div>
                      <div className="register-input_address">
                        <textarea className="register-warning" placeholder="Enter Description" name="description" onChange={(event) => {
                          setHotel({ ...hotel, "hotelDescription": event.target.value });
                        }} style={{ height: "70px" }} />
                      </div>
                      <div className="register-input_address">
                        <textarea className="register-warning" placeholder="Enter Address" name="address" onChange={(event) => {
                          setHotel({ ...hotel, "address": event.target.value });
                        }} style={{ height: "70px" }} />
                      </div>
                      <div className="register-btn">
                        <button type="submit" onClick={addHotel}>Add Hotel</button>
                      </div>
                    </form>
                    <hr className="register-hr" />
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

export default AddHotel;
