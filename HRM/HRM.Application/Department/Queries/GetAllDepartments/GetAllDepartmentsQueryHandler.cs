using AutoMapper;
using HRM.Application.Department.DTOs;
using HRM.Domain.Interfaces;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using DepartmentEntity = HRM.Domain.Entities.Department;

namespace HRM.Application.Department.Queries.GetAllDepartments
{
    public class GetAllDepartmentsQueryHandler : IRequestHandler<GetAllDepartmentsQuery, IEnumerable<DepartmentDto>>
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IMapper _mapper;   

        public GetAllDepartmentsQueryHandler(IDepartmentRepository departmentRepository, IMapper mapper)
        {
            _departmentRepository = departmentRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<DepartmentDto>> Handle(GetAllDepartmentsQuery request, CancellationToken cancellationToken)
        {
            var departments = await _departmentRepository.GetAllAsync();
            var departmentDtos = new List<DepartmentDto>();
            //var departmeentDtos = mapper.Map<IEnumerable<DepartmentDto>>(departments);

            foreach (var department in departments)
            {
                departmentDtos.Add(new DepartmentDto
                {
                    Id = department.Id ?? 0,
                    Name = department.Name,
                    Description = department.Description,
                    IsActive = department.IsActive,
                    CreatedDate = department.CreatedDate,
                    ModifiedDate = department.ModifiedDate
                });
            }

            return departmentDtos;
        }
    }
}