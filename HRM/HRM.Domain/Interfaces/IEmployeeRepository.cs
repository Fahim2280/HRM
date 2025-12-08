using HRM.Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace HRM.Domain.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetAllAsync(
            Expression<Func<Employee, bool>>? filter = null,
            Func<IQueryable<Employee>, IIncludableQueryable<Employee, object>>? include = null);
        Task<Employee?> GetByIdAsync(int id,
            Func<IQueryable<Employee>, IIncludableQueryable<Employee, object>>? include = null);
        Task<Employee> AddAsync(Employee entity);
        Task<Employee> UpdateAsync(Employee entity);
        Task<bool> DeleteAsync(Employee entity);
    }

}
