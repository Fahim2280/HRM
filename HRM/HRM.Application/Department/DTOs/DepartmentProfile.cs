using AutoMapper;
using HRM.Application.Department.Commands.CreateDepartment;
using HRM.Domain.Entities;
using DepartmentEntity = HRM.Domain.Entities.Department;

namespace HRM.Application.Department.DTOs
{
    public class DepartmentProfile : Profile
    {
        public DepartmentProfile()
        {
            CreateMap<CreateDepartmentCommand, DepartmentEntity>();          
        }
    }
}