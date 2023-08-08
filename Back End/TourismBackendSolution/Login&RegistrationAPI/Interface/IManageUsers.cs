using HospitalManagement.Models;
using HospitalManagement.Models.DTO;

namespace HospitalManagement.Interface
{
    public interface IManageUsers
    {
        public Task<UserDTO> HotelAgentRegistration(HotelAgentDTO hotelAgentDTO);
        public Task<UserDTO> ClientRegistration(ClientDTO clientDTO);
        public Task<UserDTO> Login(UserDTO userDTO);
        public Task<HotelAgent> UpdateAgents(HotelAgent hotelAgent);
        public Task<UserDTO> GetUserByMail(UserDTO userDTO);
        public Task<ICollection<HotelAgent>> GetAllAgents();
        public Task<HotelAgent> GetAgent(int key);
        public Task<Clients> GetClient(int key);
        public Task<User> GetUser(int key);
        public Task<User> ForgetPassword(UserDTO userDTO); 
    }
}
