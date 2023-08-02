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
    public class UserRepo : IRepo<User, int>
    {
        private readonly RegistrationContext _context;

        public UserRepo(RegistrationContext hospitalContext)
        {
            _context = hospitalContext;
        }

        public async Task<User?> Add(User item)
        {
            if (_context == null || _context.Users == null)
            {
                throw new Exception("Context is null");
            }
            var transaction = _context.Database.BeginTransaction();
            try
            {
                _context.Users.Add(item);
                await _context.SaveChangesAsync();
                await transaction.CommitAsync();
                return item;
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                Console.WriteLine($"Failed to add user: {ex.Message}");
                throw new Exception("Failed to add user", ex);
            }
        }

        public Task<User?> Delete(User item)
        {
            throw new NotImplementedException();
        }

        public async Task<User?> Get(int key)
        {
            if (_context == null || _context.Users == null)
            {
                throw new Exception("Context is null");
            }
            try
            {
                var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == key);
                return user;
            }
            catch (Exception ex)
            {
                // Handle the exception or log the error
                Console.WriteLine($"Failed to get user: {ex.Message}");
                throw new Exception("Failed to get user", ex);
            }
        }

        public async Task<ICollection<User>?> GetAll()
        {
            if (_context == null || _context.Users == null)
            {
                throw new Exception("Context is null");
            }
            try
            {
                var users = await _context.Users.ToListAsync();
                return users;
            }
            catch (Exception ex)
            {
                // Handle the exception or log the error
                Console.WriteLine($"Failed to get all users: {ex.Message}");
                throw new Exception("Failed to get all users", ex);
            }
        }

        public async Task<User?> Update(User item)
        {
            if (_context == null || _context.Users == null)
            {
                throw new Exception("Context is null");
            }
            try
            {
                var user = await Get(item.Id);
                if (user != null)
                {
                    _context.Users.Update(item);
                    await _context.SaveChangesAsync();
                    return item;
                }
            }
            catch (Exception ex)
            {
                // Handle the exception or log the error
                Console.WriteLine($"Failed to update user: {ex.Message}");
                Debug.WriteLine($"Failed to update user: {ex.Message}");
            }
            return null;
        }
    }
}
