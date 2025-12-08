using AutoMapper;
using HRM.Application.Department.DTOs;
using HRM.Domain.Entities;
using HRM.Domain.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using DepartmentEntity = HRM.Domain.Entities.Department;

namespace HRM.Application.Department.Commands.CreateDepartment
{
    public class CreateDepartmentCommandHandler : IRequestHandler<CreateDepartmentCommand, DepartmentDto>
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IMapper _mapper;

        public CreateDepartmentCommandHandler(IDepartmentRepository departmentRepository, IMapper mapper)
        {
            _departmentRepository = departmentRepository;
            _mapper = mapper;
        }

        public async Task<DepartmentDto> Handle(CreateDepartmentCommand request, CancellationToken cancellationToken)
        {
            var departmentEntity = _mapper.Map<DepartmentEntity>(request);
            var createdDepartment = await _departmentRepository.AddAsync(departmentEntity);
            var departmentDto = _mapper.Map<DepartmentDto>(createdDepartment);

            return departmentDto;
        }
    }
}