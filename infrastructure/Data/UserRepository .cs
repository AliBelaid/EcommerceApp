using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities.identity;
using Core.interfaces;
using Infrastructure.Identity;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly AppIdentityDbContext _ctx;

        public UserRepository (AppIdentityDbContext ctx)
        {
            _ctx = ctx;
        }
        public void Add(AppUser User)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

     

        public async Task<AppUser> GetUserByIdAsync(int id)
        {
            return await _ctx.Users.FindAsync(id);
        }

        public async Task<AppUser> GetUserByNameAsync(string UserName)
        {
            return await _ctx.Users.Include(p=>p.Photos).Include(p=>p.Address).SingleOrDefaultAsync(x=>x.UserName == UserName);
        }

        public async Task<IEnumerable<AppUser>> GetUsersAsync()
        {
            return await _ctx.Users.Include(p=>p.Photos).Include(p=>p.Address).ToListAsync();
        }

        public async Task<bool> SaveAllAsync()
        {
           return await _ctx.SaveChangesAsync()>0;
        }

        public void Update(AppUser User)
        {
            _ctx.Entry(User).State = EntityState.Modified;
        }

      
    }
}