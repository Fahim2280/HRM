using System;
using System.Collections.Generic;
using System.Text;
using UserEntity = HRM.Domain.Entities.User;

namespace HRM.Domain.Interfaces
{
    public interface IAuthRepository
    {
        string GenerateJwtToken(UserEntity user);
    }
}
