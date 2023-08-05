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
import VendorPage from './Components/VendorPage';
import HotelInfoPage from './Components/HotelInfoPage';

function App() {
  return (
    <div className="App">
      {/* <Login/>
      <UserRegister/>
      <VendorRegister/> 
       <AddHotel/>
      <VendorNavbar/> 
      <AddRoom/>  */}
      {/* <VendorPage/> */}
      {/* <HotelInfoPage/> */}
      <AdminPage/>
    </div>
  );
}

export default App;
