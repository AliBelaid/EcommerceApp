using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Entities.identity;
using Core.Specifications;

namespace Core.interfaces {
    public interface IUserRepository  {

        Task<AppUser> GetUserByIdAsync (int id);
        Task<IEnumerable<AppUser>> GetUsersAsync ();
     Task<bool> SaveAllAsync();
     Task<AppUser> GetUserByNameAsync (string UserName);
        void Add (AppUser User);
        void Update (AppUser User);
        void Delete (int id);
        //Task<Member> GetUserByNameAsync (string UserName);
    }
}