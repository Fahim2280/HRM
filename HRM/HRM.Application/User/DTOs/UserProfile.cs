using AutoMapper;
using UserEntity = HRM.Domain.Entities.User;

namespace HRM.Application.User.DTOs
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserEntity, UserDto>();
        }
    }
}
