using MediatR;

namespace HRM.Application.User.Commands.VerifyEmail
{
    public class VerifyEmailCommand : IRequest<bool>
    {
        public string Token { get; set; } = string.Empty;
    }
}