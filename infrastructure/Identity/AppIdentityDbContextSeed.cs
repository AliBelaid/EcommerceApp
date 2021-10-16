using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities.identity;
using Microsoft.AspNetCore.Identity;
namespace Infrastructure.Identity
{
    public class AppIdentityDbContextSeed
    {
        public static async Task SeedUsersAsync(UserManager<AppUser> userManger)
        {
           if(!userManger.Users.Any()) {
       var user = new AppUser {
       DisplayName = "Bob",
       Email = "bob@test.com",
       UserName="bob@test.com",
       Address= new Address {
             City ="Network",
             State="NY",
             ZipCode="90210",
             Street="10 The street",
             FirstName="Bob",
             LastName="Bobbity",
                    }
   };

   await userManger.CreateAsync(user,"Ali@123");
            }
        }
    }
}