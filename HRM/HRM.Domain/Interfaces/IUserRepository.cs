using HRM.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HRM.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<User?> GetUserByUsernameAsync(string username);
        Task<User?> GetUserByEmailAsync(string email);
        Task<User?> GetUserByVerificationTokenAsync(string token);
        Task<User> AddAsync(User user);
        Task<User?> GetByIdAsync(int id);
        Task<IEnumerable<User>> GetAllAsync();
        Task<User> UpdateAsync(User user);
        Task<bool> DeleteAsync(User user);
    }
}