using HospitalManagement.Context;
using HospitalManagement.Interface;
using HospitalManagement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace HospitalManagement.Service
{
    public class ClientRepo : IRepo<Clients, int>
    {
        private readonly RegistrationContext _context;

        public ClientRepo(RegistrationContext hospitalContext)
        {
            _context = hospitalContext;
        }

        public async Task<Clients?> Add(Clients item)
        {
            var transaction = _context.Database.BeginTransaction();
            if (_context == null || _context.Clients == null)
            {
                throw new Exception("Context is null");
            }
            try
            {
                await transaction.CreateSavepointAsync("Add clients");
                _context.Clients.Add(item);
                await _context.SaveChangesAsync();
                transaction.Commit();
                return item;
            }
            catch (Exception ex)
            {
                transaction.RollbackToSavepoint("Add clients");
                // Handle the exception or log the error
                Console.WriteLine($"Failed to add client: {ex.Message}");
                return null;
            }
        }

        public async Task<Clients?> Delete(Clients item)
        {
            if (_context == null || _context.Clients == null)
            {
                throw new Exception("Context is null");
            }
            try
            {
                var patient = await Get(item.Id);
                if (patient != null)
                {
                    _context.Clients.Remove(item);
                    await _context.SaveChangesAsync();
                    return item;
                }
            }
            catch (Exception ex)
            {
                // Handle the exception or log the error
                Console.WriteLine($"Failed to update client: {ex.Message}");
                Debug.WriteLine($"Failed to update client: {ex.Message}");
            }
            return null;

        }

        public async Task<Clients?> Get(int key)
        {
            if (_context == null || _context.Clients == null)
            {
                throw new Exception("Context is null");
            }
            try
            {
                var patient = await _context.Clients.FirstOrDefaultAsync(u => u.Id == key);
                return patient;
            }
            catch (Exception ex)
            {
                // Handle the exception or log the error
                Console.WriteLine($"Failed to get client: {ex.Message}");
                return null;
            }
        }

        public async Task<ICollection<Clients>?> GetAll()
        {
            if (_context == null || _context.Clients == null)
            {
                throw new Exception("Context is null");
            }
            try
            {
                var patients = await _context.Clients.ToListAsync();
                return patients;
            }
            catch (Exception ex)
            {
                // Handle the exception or log the error
                Console.WriteLine($"Failed to get all clients: {ex.Message}");
                return null;
            }
        }

        public async Task<Clients?> Update(Clients item)
        {
            if (_context == null || _context.Clients == null)
            {
                throw new Exception("Context is null");
            }
            try
            {
                var patient = await Get(item.Id);
                if (patient != null)
                {
                    _context.Clients.Update(item);
                    await _context.SaveChangesAsync();
                    return item;
                }
            }
            catch (Exception ex)
            {
                // Handle the exception or log the error
                Console.WriteLine($"Failed to update client: {ex.Message}");
                Debug.WriteLine($"Failed to update client: {ex.Message}");
            }
            return null;
        }
    }
}
