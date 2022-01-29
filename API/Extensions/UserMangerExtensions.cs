using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Core.Entities.identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace API.Extensions {
    public static class UserMangerExtensions {
        public static async Task<AppUser> FindByUserClaimsWithAddressAsync (this UserManager<AppUser> input, ClaimsPrincipal user) {
            var email = user?.FindFirstValue (ClaimTypes.Email);
            return await input.Users.Include(p => p.Address).Include(p => p.Photos).SingleOrDefaultAsync (x => x.Email == email);

        }

        public static async Task<AppUser> FindByEmailFromClaimsPrinciple(this UserManager<AppUser> input, ClaimsPrincipal user) {
            var email = user?.FindFirstValue (ClaimTypes.Email);
            return await input.Users.Include(p => p.Photos).SingleOrDefaultAsync(x => x.Email == email);

        }
    }
}