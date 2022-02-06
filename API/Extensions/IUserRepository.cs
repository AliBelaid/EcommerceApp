using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using Core.Entities;
using Core.Entities.identity;
using Core.Entities.identity.Extensions;
using Core.Specifications;

namespace API.Extensions {
    public interface IUserRepository  {

        Task<AppUser> GetUserByIdAsync (int id);
        
        Task<IEnumerable<AppUser>> GetUsersAsync ();
     Task<bool> SaveAllAsync();
     Task<AppUser> GetUserByNameAsync (string UserName);
        void Add (AppUser User);
        void Update (AppUser User);
        void Delete (int id);
        //Task<Member> GetUserByNameAsync (string UserName);
      Task<PageList<Member>> GetMembersAsync (UserParems userParems);  
      
    }
}