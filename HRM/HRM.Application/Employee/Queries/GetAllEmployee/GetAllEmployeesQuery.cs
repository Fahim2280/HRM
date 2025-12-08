using HRM.Application.Employee.DTOs;
using MediatR;
using System.Collections.Generic;

namespace HRM.Application.Employee.Queries.GetAllEmployee
{
    public class GetAllEmployeesQuery : IRequest<IEnumerable<EmployeeDto>>
    {
    }
}