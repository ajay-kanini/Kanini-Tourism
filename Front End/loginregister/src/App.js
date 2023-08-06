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
import Feedback from './Components/FeedBack';
import { BrowserRouter, Link, Route, Routes } from 'react-router-dom';

function App() {
  return (
    <BrowserRouter>
    <div className="App">
      <Routes>
      <Route path="/hotelDetails/:hotelId" element={<HotelInfoPage />} />
        <Route path='/hotelList' element={<UserHotelList/>}/>
      </Routes>
      {/* <VendorNavbar/> */}
      {/* <Login/>
      <UserRegister/>
      <VendorRegister/> 
      <AddHotel/>     
      <AddRoom/>  
      <AdminPage/>
      <Feedback/> */}
    </div>
    </BrowserRouter>
  );
}

export default App;
