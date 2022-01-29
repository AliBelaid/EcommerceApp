using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;


namespace Core.Entities.identity
{
    public class AppRole : IdentityRole<int>
    {
        public ICollection<AppUserRole> UserRoles { get; set; }
    }
}