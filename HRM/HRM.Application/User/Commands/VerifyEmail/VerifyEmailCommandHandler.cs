using HRM.Domain.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace HRM.Application.User.Commands.VerifyEmail
{
    public class VerifyEmailCommandHandler : IRequestHandler<VerifyEmailCommand, bool>
    {
        private readonly IUserRepository _userRepository;

        public VerifyEmailCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> Handle(VerifyEmailCommand request, CancellationToken cancellationToken)
        {
            // Find user by verification token
            var user = await _userRepository.GetUserByVerificationTokenAsync(request.Token);
            
            if (user == null)
            {
                return false; // Invalid or expired token
            }

            // Mark user as email verified
            user.IsEmailVerified = true;
            user.EmailVerificationToken = string.Empty;
            user.EmailVerificationTokenExpiry = null;
            
            await _userRepository.UpdateAsync(user);
            
            return true;
        }
    }
}