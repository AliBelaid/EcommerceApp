using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using Core.Entities.identity;
using Core.Entities.identity.Extensions;

namespace API.Extensions
{
    public interface ILikesRepository
    {
        Task<UserLike> GetUserLike(int sourceId , int LikeuserId);
        Task<AppUser> GetUserWithLikes(int userId);
        Task<PageList<LikeDto>> GetUserLikes(LikesParems likesParems);
    }
}