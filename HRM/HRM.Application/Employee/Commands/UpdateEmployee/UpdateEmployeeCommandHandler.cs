using AutoMapper;
using HRM.Application.Employee.DTOs;
using HRM.Domain.Entities;
using HRM.Domain.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using EmployeeEntity = HRM.Domain.Entities.Employee;

namespace HRM.Application.Employee.Commands.UpdateEmployee
{
    public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand, EmployeeDto>
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;

        public UpdateEmployeeCommandHandler(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }

        public async Task<EmployeeDto> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var existingEmployee = await _employeeRepository.GetByIdAsync(request.Id);
            if (existingEmployee == null)
            {
                throw new ArgumentException($"Employee with ID {request.Id} not found.");
            }

            // Update properties
            existingEmployee.FirstName = request.FirstName;
            existingEmployee.LastName = request.LastName;
            existingEmployee.Email = request.Email;
            existingEmployee.PhoneNumber = request.PhoneNumber;
            existingEmployee.DateOfBirth = request.DateOfBirth;
            existingEmployee.HireDate = request.HireDate;
            existingEmployee.Salary = request.Salary;
            existingEmployee.IsActive = request.IsActive;
            existingEmployee.DepartmentId = request.DepartmentId;
            existingEmployee.ModifiedDate = DateTime.UtcNow;

            var updatedEmployee = await _employeeRepository.UpdateAsync(existingEmployee);
            var employeeDto = _mapper.Map<EmployeeDto>(updatedEmployee);

            return employeeDto;
        }
    }
}