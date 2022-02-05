using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Core.Entities.identity;
using Core.Entities.identity.Extensions;
using Core.interfaces;
using Infrastructure.Identity;
using Microsoft.EntityFrameworkCore;

namespace API.Extensions
{
    public class UserRepository : IUserRepository
    {
        private readonly AppIdentityDbContext _ctx;
        private readonly IMapper _mapper;

        public UserRepository (AppIdentityDbContext ctx , IMapper mapper)
        {
            _ctx = ctx;
            _mapper = mapper;
        }
        public void Add(AppUser User)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

    
        public async Task<PageList<Member>> GetMembersAsync(UserParems userParems)
        {
          var query = _ctx.Users.AsQueryable();
          query = query.Where(i=>i.UserName != userParems.CurrentUserName);
          query = query.Where(i=>i.Gender ==userParems.Gender);
          var minDob = DateTime.Today.AddYears(-userParems.MaxAge -1) ;
          var maxDob = DateTime.Today.AddYears(-userParems.MinAge);
             query = query.Where(i=>i.DateOfBirth >= minDob && i.DateOfBirth <= maxDob);
    query = userParems.OrderBy switch {
        "created" => query.OrderByDescending(i=>i.Created),
         _=> query.OrderByDescending(i=>i.LastActive),
    };
       



          return await    PageList<Member>.CreateAsync(query.ProjectTo<Member>(_mapper.ConfigurationProvider).AsNoTracking(),userParems.PageIndex,userParems.PageSize );
            
           
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