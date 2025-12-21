using AutoMapper;
using HRM.Application.Employee.DTOs;
using HRM.Domain.Interfaces;
using MediatR;
using System;
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

            _mapper.Map(request, existingEmployee);

            var updatedEmployee = await _employeeRepository.UpdateAsync(existingEmployee);

            var employeeDto = _mapper.Map<EmployeeDto>(updatedEmployee);

            return employeeDto;
        }
    }
}