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
    internal class DepartmentRepository : IDepartmentRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<Department> _dbSet;

        public DepartmentRepository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = context.Set<Department>();
        }

        public async Task<IEnumerable<Department>> GetAllAsync(
            Expression<Func<Department, bool>>? filter = null,
            Func<IQueryable<Department>, IIncludableQueryable<Department, object>>? include = null)
        {
            IQueryable<Department> query = _dbSet;

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

        public async Task<Department?> GetByIdAsync(int id,
            Func<IQueryable<Department>, IIncludableQueryable<Department, object>>? include = null)
        {
            IQueryable<Department> query = _dbSet;

            if (include != null)
            {
                query = include(query);
            }

            return await query.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<Department> AddAsync(Department entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<Department> UpdateAsync(Department entity)
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> DeleteAsync(Department entity)
        {
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

