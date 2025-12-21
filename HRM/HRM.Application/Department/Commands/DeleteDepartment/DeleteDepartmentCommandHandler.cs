using HRM.Application.Common;
using HRM.Domain.Entities;
using HRM.Domain.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using DepartmentEntity = HRM.Domain.Entities.Department;

namespace HRM.Application.Department.Commands.DeleteDepartment
{
    public class DeleteDepartmentCommandHandler : IRequestHandler<DeleteDepartmentCommand, DeleteResult>
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DeleteDepartmentCommandHandler(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public async Task<DeleteResult> Handle(DeleteDepartmentCommand request, CancellationToken cancellationToken)
        {
            var department = await _departmentRepository.GetByIdAsync(request.Id);
            if (department == null)
            {
                return DeleteResult.Failure($"User with ID {request.Id} not found.", 404);
            }

            var result = await _departmentRepository.DeleteAsync(department);
            return DeleteResult.Success();
        }
    }
}