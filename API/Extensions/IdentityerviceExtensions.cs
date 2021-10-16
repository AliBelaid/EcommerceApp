using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities.identity;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;
namespace API.Extensions
{
    public static class IdentityServiceExtensions
    {
        public static IServiceCollection AddIdentityServices(this IServiceCollection services,IConfiguration conf){
           var builder = services.AddIdentityCore<AppUser>();
            builder = new IdentityBuilder(builder.UserType,builder.Services);
            builder.AddEntityFrameworkStores<AppIdentityDbContext>();
            builder.AddSignInManager<SignInManager<AppUser>>();
               services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(
                   Options=> {
                       Options.TokenValidationParameters= new TokenValidationParameters{
                                ValidateIssuerSigningKey=true,
                                IssuerSigningKey= new SymmetricSecurityKey(Encoding.UTF8.GetBytes
                                (conf["Token:Key"])),
                                ValidIssuer=conf["Token:Issuer"],
                                ValidateAudience= false,
                                ValidateIssuer=true,
                       };
                   }
               );

           return services;
  
        }
    }
}