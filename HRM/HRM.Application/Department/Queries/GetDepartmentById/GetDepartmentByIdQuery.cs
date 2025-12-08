using HRM.Application.Department.DTOs;
using MediatR;

namespace HRM.Application.Department.Queries.GetDepartmentById
{
    public class GetDepartmentByIdQuery : IRequest<DepartmentDto?>
    {
        public int Id { get; set; }

        public GetDepartmentByIdQuery(int id)
        {
            Id = id;
        }
    }
}