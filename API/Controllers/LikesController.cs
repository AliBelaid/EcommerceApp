using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using API.Dtos;
using API.Errors;
using API.Extensions;
using AutoMapper;
using Core.Entities.identity;
using Core.Entities.identity.Extensions;
using Core.interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace API.Controllers {
    [Authorize]
    public class LikesController : BaseController {

        private readonly IUserRepository _userProduct;

        private readonly ILikesRepository _like;

        public LikesController (IUserRepository userProduct,
            ILikesRepository like) {
            _userProduct = userProduct;
            _like = like;
        }

        [HttpPost ("{userName}")]
        public async Task<ActionResult> AddLike (string userName) {
            var sourceUserId = int.Parse (User.RetrieveUseeByIdPrincipal ());
            var userliked = await _userProduct.GetUserByNameAsync (userName);
            if (userliked == null) {
                return NoContent ();
            }
            var sourceUser = await _like.GetUserWithLikes (sourceUserId);
            if (sourceUser.UserName == userName) {
                return BadRequest ("You cannot like yourself");

            }
            var userLike = await _like.GetUserLike (sourceUserId, userliked.Id);
            if (userLike != null) {
                return BadRequest ("You already like this user");
            }
            userLike = new UserLike {
                SourceUserId = sourceUserId,
                LikedUserId = userliked.Id
            };
            sourceUser.LikedUsers.Add (userLike);
            if (await _userProduct.SaveAllAsync ()) {
                return Ok ();
            }
            return BadRequest ("Felid to like  user");

        }

        [HttpGet]
        public async Task<ActionResult<PageList<LikeDto>>> GetUserLikes ([FromQuery]LikesParems likesParems ) {

            var UserId = int.Parse (User.RetrieveUseeByIdPrincipal ());
           likesParems.UserId = UserId;
            var users = await _like.GetUserLikes (likesParems);
            Response.AddPaginationHeader(users.PageSize,users.CurrentPage,users.TotalCount ,users.TotalPages);
           
            return Ok (users);
        }

    }
}