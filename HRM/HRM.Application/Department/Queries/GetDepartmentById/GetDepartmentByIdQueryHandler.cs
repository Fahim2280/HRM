using AutoMapper;
using HRM.Application.Department.DTOs;
using HRM.Domain.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using DepartmentEntity = HRM.Domain.Entities.Department;

namespace HRM.Application.Department.Queries.GetDepartmentById
{
    public class GetDepartmentByIdQueryHandler : IRequestHandler<GetDepartmentByIdQuery, DepartmentDto?>
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IMapper _mapper;

        public GetDepartmentByIdQueryHandler(IDepartmentRepository departmentRepository, IMapper mapper)
        {
            _departmentRepository = departmentRepository;
            _mapper = mapper;
        }

        public async Task<DepartmentDto?> Handle(GetDepartmentByIdQuery request, CancellationToken cancellationToken)
        {
            var department = await _departmentRepository.GetByIdAsync(request.Id);
            if (department == null)
            {
                return null;
            }

            return new DepartmentDto
            {
                Id = department.Id ?? 0,
                Name = department.Name,
                Description = department.Description,
                IsActive = department.IsActive,
                CreatedDate = department.CreatedDate,
                ModifiedDate = department.ModifiedDate
            };
        }
    }
}