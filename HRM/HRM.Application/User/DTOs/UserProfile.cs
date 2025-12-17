using AutoMapper;
using UserEntity = HRM.Domain.Entities.User;

namespace HRM.Application.User.DTOs
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserEntity, UserDto>()
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.Id));
            
            CreateMap<UserDto, UserEntity>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.UserId));
        }
    }
}