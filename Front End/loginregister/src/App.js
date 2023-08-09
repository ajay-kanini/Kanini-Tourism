import logo from './logo.svg';
import './App.css';
import 'bootstrap/dist/css/bootstrap.min.css';
import 'bootstrap/dist/js/bootstrap.bundle.min';
import '@fortawesome/fontawesome-free/css/all.min.css';
import Login from './Components/Login';
import VendorRegister from './Components/VendorRegister';
import UserRegister from './Components/UserRegister';
import AdminPage from './Components/AdminPage';
import VendorNavbar from './Components/VendorNavbar';
import AddHotel from './Components/AddHotel';
import AddRoom from './Components/AddRoom';
import UserHotelList from './Components/UserHotelList';
import HotelInfoPage from './Components/HotelInfoPage';
import FeedBack from './Components/FeedBack';
import { ToastContainer } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';
import { BrowserRouter, Link, Route, Routes, Navigate } from 'react-router-dom';
import VendorHotelPage from './Components/VendorHotelPage';
import VendorRoomPage from './Components/VendorRoomPage';
import Booking from './Components/Booking';
import FetchRooms from './Components/FetchRooms';
import HomePage from './Components/HomePage';
import UserBooking from './Components/UserBooking';
import UserNavbar from './Components/UserNavbar';
import { useNavigate } from 'react-router-dom';
import  Message  from './Components/Message';

function Client({ role, children }) {
  if (localStorage.getItem('role') != null && localStorage.getItem('role') === 'Client') {
    return children;
  }
  return <Navigate to="/" />;
}

function HotelAgent({ role, children }) {
  if (localStorage.getItem('role') != null && localStorage.getItem('role') === 'Hotel Agent') {
    return children;
  }
  return <Navigate to="/" />;
}

function Admin({ role, children }) {
  if (localStorage.getItem('role') != null && localStorage.getItem('role') === 'Admin') {
    return children;
  }
  return <Navigate to="/" />;
}



function App() {
  return (
    <BrowserRouter>
      <div className="App">
        <Routes>
          <Route path="/" element={<HomePage />} />
          <Route path="/login" element={<Login />} />
          <Route path="/userNavbar" element={<UserNavbar />} />
          <Route path="/message" element={<Message/>} />
          <Route path="/hotelInfo/:hotelId" element={<Client> <HotelInfoPage /> </Client>} />
          <Route path="/addHotel" element={<HotelAgent> <AddHotel /> </HotelAgent>} />
          <Route path="/addRoom/:hotelId" element={<HotelAgent> <AddRoom /> </HotelAgent>} />
          <Route path="/feedback/:hotelId" element={<Client> <FeedBack /> </Client>} />
          <Route path="/vendorRegister" element={<VendorRegister/>} />
          <Route path="/userRegister" element={<UserRegister/>}/>
          <Route path="/adminPage" element={<Admin> <AdminPage /> </Admin>} />
          <Route path="/vendorHotelPage" element={<HotelAgent> <VendorHotelPage /> </HotelAgent>} />
          <Route path="/vendorRoomPage" element={<HotelAgent> <VendorRoomPage /> </HotelAgent>} />
          <Route path="/booking/:hotelId" element={<Client> <Booking /> </Client>} />
          <Route path="/fetchRooms/:hotelId" element={<HotelAgent> <FetchRooms /> </HotelAgent>} />
          <Route path="/userBooking" element={<Client> <UserBooking /> </Client>} />
          <Route path="/hotelList" element={<Client> <UserHotelList /> </Client>} />
        
        </Routes>
        <ToastContainer />
      </div>
    </BrowserRouter>
  );
}

export default App;
