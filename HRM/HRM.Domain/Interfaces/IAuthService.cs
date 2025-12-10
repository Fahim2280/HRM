using System;
using System.Collections.Generic;
using System.Text;

namespace HRM.Domain.Interfaces
{
    public interface IAuthService
    {
        string GenerateJwtToken(HRM.Domain.Entities.User user);
    }
}
