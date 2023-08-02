using HospitalManagement.Interface;
using HospitalManagement.Models;
using HospitalManagement.Models.DTO;
using System;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Service
{
    public class ManageUserService : IManageUsers
    {
        private readonly IRepo<HotelAgent, int> _agentRepo;
        private readonly IRepo<Clients, int> _clientRepo;
        private readonly IRepo<User, int> _userRepo;
        private readonly IGenerateToken _generateToken;
        
        public ManageUserService(
            IRepo<HotelAgent, int> agentRepo,
            IRepo<Clients, int> clientRepo,
            IRepo<User, int> userRepo,
            IGenerateToken generateToken)
        {
            _agentRepo = agentRepo;
            _clientRepo = clientRepo;
            _userRepo = userRepo;
            _generateToken = generateToken;
        }

        public async Task<UserDTO> HotelAgentRegistration(HotelAgentDTO agentDTO)
        {
            try
            {
                if (agentDTO.Users == null)
                    throw new Exception("User in the agentDTO is null");
                var hmac = new HMACSHA512();
                agentDTO.Users.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(agentDTO.Password ?? "1234"));
                agentDTO.Users.PasswordKey = hmac.Key;
                agentDTO.Users.Role = "Hotel Agent";
                agentDTO.Status = "Not Approved";

                var userResult = await _userRepo.Add(agentDTO.Users) ?? throw new Exception("Failed to add user");
                agentDTO.Id = userResult.Id;
                var doctorResult = await _agentRepo.Add(agentDTO) ?? throw new Exception("Failed to add agent");
                UserDTO user = new()
                {
                    Id = userResult.Id,
                    Role = userResult.Role
                };
                user.Token = _generateToken.GenerateToken(user);
                return user;
            }
            catch (Exception ex)
            {
                // Handle the exception or log the error
                Debug.WriteLine($"Agent registration failed: {ex.Message}");
                throw new Exception("Agent registration failed");
            }

          
        }

        public async Task<UserDTO> ClientRegistration(ClientDTO clientDTO)
        {
            
            try
            {
                if(clientDTO.Users == null)
                    throw new Exception("User in the ClientDTO is null");
                var hmac = new HMACSHA512();
                clientDTO.Users.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(clientDTO.Password ?? "1234"));
                clientDTO.Users.PasswordKey = hmac.Key;
                clientDTO.Users.Role = "Client";

                var userResult = await _userRepo.Add(clientDTO.Users) ?? throw new Exception("Failed to add user");
                clientDTO.Id = userResult.Id;
                var patientResult = await _clientRepo.Add(clientDTO) ?? throw new Exception("Failed to add client");
                UserDTO user = new();
                user = new UserDTO
                {
                    Id = patientResult.Id,
                    Role = userResult.Role
                };
                user.Token = _generateToken.GenerateToken(user);
                return user;
            }
            catch (Exception ex)
            {
                // Handle the exception or log the error
                Debug.WriteLine($"Client registration failed: {ex.Message}");
                throw new Exception("Client registration failed");
            }
        }

        public async Task<UserDTO> Login(UserDTO userDTO)
        {
            try
            {
                userDTO = await GetUserByMail(userDTO);
                if (userDTO == null)
                {
                    throw new Exception();
                }
                var userData = await _userRepo.Get(userDTO.Id);
                if (userData != null && userData.PasswordKey != null && userDTO.Password != null)
                {
                    var hmac = new HMACSHA512(userData.PasswordKey);
                    var userPass = hmac.ComputeHash(Encoding.UTF8.GetBytes(userDTO.Password));
                    for (int i = 0; i < userPass.Length; i++)
                    {
                        if (userData == null || userData.PasswordHash == null || userData?.PasswordHash[i] == null)
                            throw new Exception("user data is null");
                        if (userPass[i] != userData.PasswordHash[i])
                            throw new Exception("user password is wrong");
                    }

                    userDTO = new UserDTO
                    {
                        Mail = userData.Mail,
                        Id = userData.Id,
                        Role = userData.Role
                    };
                    userDTO.Token = _generateToken.GenerateToken(userDTO);
                }
            }
            catch (Exception ex)
            {
                // Handle the exception or log the error
                Debug.WriteLine($"Login failed: {ex.Message}");
                throw new Exception("Login failed");
            }

            return userDTO;
        }

        public async Task<HotelAgent> UpdateAgents(HotelAgent doctor)
        {
            try
            {
                var checkUser = await _agentRepo.Update(doctor);
                return checkUser ?? throw new Exception("Failed to update agent");
            }
            catch (Exception ex)
            {
                // Handle the exception or log the error
                Debug.WriteLine($"Update agent failed: {ex.Message}");
                throw new Exception("Failed to update agent");
            }
        }

        public async Task<UserDTO> GetUserByMail(UserDTO userDTO)
        {
            try
            {
                var users = await _userRepo.GetAll() ?? throw new Exception("no data available!!!");
                var user = users.FirstOrDefault(u => u.Mail == userDTO.Mail) ?? throw new Exception("User not found");
                userDTO.Id = user.Id;
            }
            catch (Exception ex)
            {
                // Handle the exception or log the error
                Debug.WriteLine($"Get user by mail failed: {ex.Message}");
                throw new Exception("Get user by mail failed");
            }

            return userDTO;
        }

        public async Task<ICollection<HotelAgent>> GetAllAgents()
        {
            try
            {
                var doctors = await _agentRepo.GetAll();
                return doctors ?? throw new Exception("Failed to retrieve agents");
            }
            catch (Exception ex)
            {
                // Handle the exception or log the error
                Debug.WriteLine($"Get all agents failed: {ex.Message}");
                throw new Exception("Get all agent failed");
            }
        }

        public async Task<HotelAgent> GetAgent(int key)
        {
            try
            {
                var doctor = await _agentRepo.Get(key);
                return doctor ?? throw new Exception("Failed to retrieve agents");
            }

            catch (Exception ex)
            {
                // Handle the exception or log the error
                Debug.WriteLine($"Get agent failed: {ex.Message}");
                throw new Exception("Get agent failed");
            }
        }
    }
 }
