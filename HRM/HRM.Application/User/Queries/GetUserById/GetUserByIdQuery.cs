using HRM.Application.User.DTOs;
using MediatR;

namespace HRM.Application.User.Queries.GetUserById
{
    public class GetUserByIdQuery : IRequest<UserDto?>
    {
        public int Id { get; set; }

        public GetUserByIdQuery(int id)
        {
            Id = id;
        }
    }
}