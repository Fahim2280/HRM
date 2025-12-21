using HRM.Application.Common;
using HRM.Application.User.DTOs;
using MediatR;

namespace HRM.Application.Department.Commands.DeleteDepartment
{
    public class DeleteDepartmentCommand : IRequest<DeleteResult>
    {
        public int Id { get; set; }

        public DeleteDepartmentCommand(int id)
        {
            Id = id;
        }
    }
}