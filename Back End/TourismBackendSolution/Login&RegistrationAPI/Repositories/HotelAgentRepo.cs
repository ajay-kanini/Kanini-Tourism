using HospitalManagement.Context;
using HospitalManagement.Interface;
using HospitalManagement.Models;
using HospitalManagement.Models.DTO;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace HospitalManagement.Service
{
    public class HotelAgentRepo : IRepo<HotelAgent, int>
    {
        private readonly RegistrationContext _context;

        public HotelAgentRepo(RegistrationContext hospitalContext)
        {
            _context = hospitalContext;
        }

        public async Task<HotelAgent?> Add(HotelAgent item)
        {
            using var transaction = _context.Database.BeginTransaction();
            if (_context == null || _context.HotelAgents == null)
            {
                throw new Exception("Context is null");
            }
            try
            {
                await transaction.CreateSavepointAsync("Add Agent");
                _context.HotelAgents.Add(item);
                await _context.SaveChangesAsync();
                transaction.Commit();
                return item;
            }
            catch (Exception ex)
            {
                transaction.RollbackToSavepoint("Add Agent");
                Debug.WriteLine($"Exception occurred while adding agent: {ex}");
                throw; // Rethrow the exception to be handled at a higher level
            }
        }

        public async Task<HotelAgent?> Delete(HotelAgent item)
        {
            if(_context == null || _context.HotelAgents == null)
            {
                throw new Exception("Context is null");
            }
            try
            {
                _context.HotelAgents.Remove(item);
                await _context.SaveChangesAsync();
                return item;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Exception occurred while deleting agent: {ex}");
                throw; // Rethrow the exception to be handled at a higher level
            }
        }

        public async Task<HotelAgent?> Get(int key)
        {
            if (_context == null || _context.HotelAgents == null)
            {
                throw new Exception("Context is null");
            }
            try
            {
                var doctor = await _context.HotelAgents.FirstOrDefaultAsync(u => u.Id == key);
                if (doctor != null)
                {
                    return doctor;
                }
                else
                {
                    throw new InvalidOperationException($"Agent with ID {key} not found"); // Throw an exception to indicate that the doctor was not found
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Exception occurred while retrieving agent: {ex}");
                throw; // Rethrow the exception to be handled at a higher level
            }
        }

        public async Task<ICollection<HotelAgent>?> GetAll()
        {
            if (_context == null || _context.HotelAgents == null)
            {
                throw new Exception("Context is null");
            }
            try
            {
                var doctors = await _context.HotelAgents.ToListAsync();
                return doctors;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Exception occurred while retrieving agents: {ex}");
                throw; // Rethrow the exception to be handled at a higher level
            }
        }

        public async Task<HotelAgent?> Update(HotelAgent item)
        {
            try
            {
                var doctor = await Get(item.Id) ?? throw new InvalidOperationException($"Agent with ID {item.Id} not found");
                if (doctor.Status == "Not Approved")
                {
                    doctor.Status = "Approved";
                }
                else if (doctor.Status == "Approved")
                {
                    doctor.Status = "Not Approved";
                }

                await _context.SaveChangesAsync();
                return doctor;
            }
            catch (InvalidOperationException)
            {
                throw; // Rethrow the exception to be handled at a higher level
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Exception occurred while updating agent: {ex}");
                throw; // Rethrow the exception to be handled at a higher level
            }
        }
    }
}
