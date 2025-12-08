using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using EmployeeEntity = HRM.Domain.Entities.Employee;

namespace HRM.Application.Employee.DTOs
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<EmployeeEntity, EmployeeDto>()
            .ForMember(dest => dest.DepartmentName,
                opt => opt.MapFrom(src => src.Department.Name));
            CreateMap<CreateEmployeeDto, EmployeeEntity>();
            CreateMap<UpdateEmployeeDto, EmployeeEntity>();
        }
    }
}
