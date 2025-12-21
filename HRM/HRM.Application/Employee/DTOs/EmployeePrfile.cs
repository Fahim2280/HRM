using AutoMapper;
using HRM.Application.Employee.Commands.CreateEmployee;
using HRM.Application.Employee.Commands.UpdateEmployee;
using HRM.Application.Employee.DTOs;
using System;
using EmployeeEntity = HRM.Domain.Entities.Employee;

namespace HRM.Application.Employee.DTOs
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<CreateEmployeeCommand, EmployeeEntity>();

            CreateMap<EmployeeEntity, EmployeeDto>();

            CreateMap<EmployeeEntity, EmployeeDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id ?? 0));

            CreateMap<UpdateEmployeeCommand, EmployeeEntity>()
                .ForMember(dest => dest.ModifiedDate, opt => opt.MapFrom(src => DateTime.UtcNow))
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedDate, opt => opt.Ignore());

        }
    }
}