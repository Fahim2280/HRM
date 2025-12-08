using HRM.Domain.Entities;
using HRM.Domain.Interfaces;
using HRM.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace HRM.Infrastructure.Repositories
{
    internal class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<Employee> _dbSet;

        public EmployeeRepository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = context.Set<Employee>();
        }

        public async Task<IEnumerable<Employee>> GetAllAsync(
            Expression<Func<Employee, bool>>? filter = null,
            Func<IQueryable<Employee>, IIncludableQueryable<Employee, object>>? include = null)
        {
            IQueryable<Employee> query = _dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (include != null)
            {
                query = include(query);
            }

            return await query.ToListAsync();
        }

        public async Task<Employee?> GetByIdAsync(int id,
            Func<IQueryable<Employee>, IIncludableQueryable<Employee, object>>? include = null)
        {
            IQueryable<Employee> query = _dbSet;

            if (include != null)
            {
                query = include(query);
            }

            return await query.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<Employee> AddAsync(Employee entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<Employee> UpdateAsync(Employee entity)
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> DeleteAsync(Employee entity)
        {
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
