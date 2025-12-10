using HRM.Application.User.DTOs;
using MediatR;
using System.Collections.Generic;

namespace HRM.Application.User.Queries.GetAllUsers
{
    public class GetAllUsersQuery : IRequest<IEnumerable<UserDto>>
    {
    }
}