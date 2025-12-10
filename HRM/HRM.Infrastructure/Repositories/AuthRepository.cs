using HRM.Domain.Entities;
using HRM.Domain.Interfaces;
using HRM.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace HRM.Infrastructure.Repositories
{
    internal class AuthRepository : IAuthRepository
    {
        private readonly ApplicationDbContext _context;

        public AuthRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        // Additional authentication-related methods can be added here if needed
    }
}
