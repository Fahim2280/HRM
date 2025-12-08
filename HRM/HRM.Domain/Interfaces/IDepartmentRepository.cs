using HRM.Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace HRM.Domain.Interfaces
{
    public interface IDepartmentRepository
    {
        Task<IEnumerable<Department>> GetAllAsync(
            Expression<Func<Department, bool>>? filter = null,
            Func<IQueryable<Department>, IIncludableQueryable<Department, object>>? include = null);
        Task<Department?> GetByIdAsync(int id,
            Func<IQueryable<Department>, IIncludableQueryable<Department, object>>? include = null);
        Task<Department> AddAsync(Department entity);
        Task<Department> UpdateAsync(Department entity);
        Task<bool> DeleteAsync(Department entity);
    }
}
