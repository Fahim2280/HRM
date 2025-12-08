using AutoMapper;
using HRM.Application.Employee.DTOs;
using HRM.Domain.Entities;
using HRM.Domain.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using EmployeeEntity = HRM.Domain.Entities.Employee;

namespace HRM.Application.Employee.Commands.CreateEmployee
{
    public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, EmployeeDto>
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;

        public CreateEmployeeCommandHandler(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }

        public async Task<EmployeeDto> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = new EmployeeEntity
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber,
                DateOfBirth = request.DateOfBirth,
                HireDate = request.HireDate,
                Salary = request.Salary,
                IsActive = request.IsActive,
                DepartmentId = request.DepartmentId,
                CreatedDate = DateTime.UtcNow
            };

            var createdEmployee = await _employeeRepository.AddAsync(employee);
            var employeeDto = _mapper.Map<EmployeeDto>(createdEmployee);

            return employeeDto;
        }
    }
}