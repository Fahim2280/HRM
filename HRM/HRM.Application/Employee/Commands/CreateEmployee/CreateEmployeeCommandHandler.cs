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
            
            var employeeEntity = _mapper.Map<EmployeeEntity>(request);
            var createdEmployee = await _employeeRepository.AddAsync(employeeEntity);
            var EmployeeDto = _mapper.Map<EmployeeDto>(createdEmployee);

            return EmployeeDto;           
        }
    }
}