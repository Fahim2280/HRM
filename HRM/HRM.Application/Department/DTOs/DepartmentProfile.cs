using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using HRM.Domain.Entities;
using DepartmentEntity = HRM.Domain.Entities.Department;

namespace HRM.Application.Department.DTOs
{
    public class DepartmentProfile : Profile
    {
        public DepartmentProfile()
        {
            CreateMap<CreatedDepartmentCommand, DepartmentEntity>();
            CreateMap<DepartmentEntity, DepartmentDto>();
            
        }
    }
}