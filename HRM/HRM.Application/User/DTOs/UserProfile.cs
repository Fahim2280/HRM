using AutoMapper;
using HRM.Application.User.Commands.CreateUser;
using HRM.Application.User.Commands.UpdateUser;
using HRM.Application.User.DTOs;
using System;
using UserEntity = HRM.Domain.Entities.User;

namespace HRM.Application.User.DTOs
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<CreateUserCommand, UserEntity>();

            CreateMap<UserEntity, UserDto>();

            CreateMap<UserEntity, UserDto>()
                 .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id ?? 0));

            CreateMap<UpdateUserCommand, UserEntity>()
                .ForMember(dest => dest.PasswordHash, opt => opt.Ignore()) // Handle separately due to BCrypt
                .ForMember(dest => dest.ModifiedDate, opt => opt.MapFrom(src => DateTime.UtcNow))
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedDate, opt => opt.Ignore())
                .ForMember(dest => dest.IsEmailVerified, opt => opt.Ignore())
                .ForMember(dest => dest.EmailVerificationToken, opt => opt.Ignore())
                .ForMember(dest => dest.EmailVerificationTokenExpiry, opt => opt.Ignore());
        }
    }
}