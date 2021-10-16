using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities.identity;

namespace Core.interfaces
{
    public interface ITokenService
    {
        string CrateToken(AppUser user);
    }
}