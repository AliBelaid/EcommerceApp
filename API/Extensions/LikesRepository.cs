using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using AutoMapper;
using Core.Entities.identity;
using Core.Entities.identity.Extensions;
using Infrastructure.Identity;
using Microsoft.EntityFrameworkCore;

namespace API.Extensions {
    public class LikesRepository : ILikesRepository {

        private readonly AppIdentityDbContext _ctx;
      
        public LikesRepository (AppIdentityDbContext ctx ) {
            _ctx = ctx;
         
        }
        public async Task<UserLike> GetUserLike (int sourceId, int LikeuserId) {
            return await _ctx.Likes.FindAsync (sourceId, LikeuserId);
        }
        public async Task<PageList<LikeDto>> GetUserLikes (LikesParems likesParems) {
            var users = _ctx.Users.OrderBy (n => n.UserName).AsQueryable ();
            var likes = _ctx.Likes.AsQueryable ();
            if (likesParems.Predicate == "liked") {
                likes = likes.Where (r => r.SourceUserId == likesParems.UserId);
                users = likes.Select (i => i.LikedUser);
            }
            if (likesParems.Predicate == "likedBy") {
                likes = likes.Where (r => r.LikedUserId == likesParems.UserId);
                users = likes.Select (i => i.SourceUser);
            }
            var likeUsers =    users.Select (user => new LikeDto {
                UserName = user.UserName,
                    Age = user.DateOfBirth.CalculateAge (),
                    City = user.City,
                    KnownAs = user.KnownAs,
                    PhotoUrl = user.Photos.SingleOrDefault (u => u.IsMain).Url,
                    Id = user.Id
            });

     return await PageList<LikeDto>.CreateAsync(likeUsers ,likesParems.PageIndex, likesParems.PageSize);
        }

        public async Task<AppUser> GetUserWithLikes (int userId) {
            return await _ctx.Users.Include(i => i.LikedUsers).FirstOrDefaultAsync (p => p.Id == userId);
        }
    }
}