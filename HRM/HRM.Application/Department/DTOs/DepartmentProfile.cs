using AutoMapper;
using HRM.Application.Department.Commands.CreateDepartment;
using HRM.Application.Department.Commands.UpdateDepartment;
using HRM.Domain.Entities;
using DepartmentEntity = HRM.Domain.Entities.Department;

namespace HRM.Application.Department.DTOs
{
    public class DepartmentProfile : Profile
    {
        public DepartmentProfile()
        {
            CreateMap<CreateDepartmentCommand, DepartmentEntity>();

            CreateMap<DepartmentEntity, DepartmentDto>();

            CreateMap<DepartmentEntity, DepartmentDto>()
                 .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id ?? 0)); ;    
            
            CreateMap<UpdateDepartmentCommand, DepartmentEntity>()
                .ForMember(dest => dest.ModifiedDate, opt => opt.MapFrom(src => DateTime.UtcNow))
                .ForMember(dest => dest.Id, opt => opt.Ignore()) 
                .ForMember(dest => dest.CreatedDate, opt => opt.Ignore()); ;
        }
    }
}