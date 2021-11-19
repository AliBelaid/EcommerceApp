using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace API.Extensions
{
    public static class ClaimsPrincipalExtensions
    {

        public static string RetrieveEmailFormPrincipal(this ClaimsPrincipal user) {
return    user?.Claims.FirstOrDefault(i =>i.Type==ClaimTypes.Email)?.Value;
        }
        
    }
}