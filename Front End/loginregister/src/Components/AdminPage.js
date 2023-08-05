import React, { useState, useEffect } from "react";
import './AdminPage.css';
import { Navbar, Nav, NavDropdown } from "react-bootstrap";

function AdminPage() {
    const [agents, setAgents] = useState([]);

  useEffect(() => {
    fetchNotApproved();
  }, []);

  const fetchNotApproved = () => {
    fetch('http://localhost:5294/api/Register/GetAgentDetails')
      .then(response => response.json())
      .then(data => {
        setAgents(data);
      })
      .catch(error => console.log(error));
  };

  const handleStatusChange = (id) => {
    fetch("http://localhost:5294/api/Register/UpdateDoctorStatus", {
      method: "PUT",
      headers: {
        "Accept": "text/plain",
        "Content-Type": "application/json"      },
      body: JSON.stringify({ "id": id })
    })
      .then(async (data) => {
        if (data.status === 201) {
          alert("ok");
          fetchNotApproved();
        }        
        else if(data.status === 401)
        {
          alert("not ok");
        }
      })
      .catch((err) => {
        console.log(err.error);
      });
  };
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
            <h1 className="navbar-heading">Vendor Details</h1>
        </Navbar.Collapse>
      </Navbar>
      </div>
      <div className="agentCards">
        {agents.map((agent, index) => (
            <div key={agent.id} className={`card-new card`}>
                <div className="card-body-new">
                  <h5 className="card-title-new">{agent.name}</h5>
                  <p className="card-text-new">Age: {agent.age}</p>
                  <p className="card-text-new">AadharId: {agent.aadharId}</p>
                  <p className="card-text-new">Status: {agent.status}</p>
                  <hr />
                  <button
                    className="change-status-btn-new"
                    onClick={() => handleStatusChange(agent.id)}>
                    Change Status
                  </button>
                </div>
            </div>
         ))}
      </div>
    </div>
  );
}

export default AdminPage;
