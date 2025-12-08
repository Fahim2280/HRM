using AutoMapper;
using HRM.Application.Department.DTOs;
using HRM.Domain.Entities;
using HRM.Domain.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using DepartmentEntity = HRM.Domain.Entities.Department;

namespace HRM.Application.Department.Commands.UpdateDepartment
{
    public class UpdateDepartmentCommandHandler : IRequestHandler<UpdateDepartmentCommand, DepartmentDto>
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IMapper _mapper;

        public UpdateDepartmentCommandHandler(IDepartmentRepository departmentRepository, IMapper mapper)
        {
            _departmentRepository = departmentRepository;
            _mapper = mapper;
        }

        public async Task<DepartmentDto> Handle(UpdateDepartmentCommand request, CancellationToken cancellationToken)
        {
            var existingDepartment = await _departmentRepository.GetByIdAsync(request.Id);
            if (existingDepartment == null)
            {
                throw new ArgumentException($"Department with ID {request.Id} not found.");
            }
            var updatedDepartment = await _departmentRepository.UpdateAsync(existingDepartment);

            var departmentDto = _mapper.Map<DepartmentDto>(updatedDepartment);

            return departmentDto;
        }
    }
}