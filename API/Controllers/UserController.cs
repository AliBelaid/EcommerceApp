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
using Core.interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace API.Controllers {

    public class UserController : BaseController {

        private readonly IMapper _mapper;
        private readonly IUserRepository _userProduct;
        private readonly UserManager<AppUser> _userManger;
        private readonly IPhotoServices _repoPhoto;

        public UserController (IUserRepository userProduct, UserManager<AppUser> userManger,
            IPhotoServices repoPhoto,
            IMapper mapper) {
            _userProduct = userProduct;
            _userManger = userManger;
            _repoPhoto = repoPhoto;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Member>>> GetUsers () {

            //   var emailt= HttpContext.User?.Claims?.FirstOrDefault(i=>i.Type ==ClaimTypes.Email);
            var users = await _userProduct.GetUsersAsync ();
            var send = _mapper.Map<IEnumerable<Member>> (users);
            return Ok (send);
        }

        // [HttpGet ("{id}")]
        // public async Task<ActionResult<Member>> GetUserById (int id) {

        //     //   var emailt= HttpContext.User?.Claims?.FirstOrDefault(i=>i.Type ==ClaimTypes.Email);
        //     var user = await _userProduct.GetUserByIdAsync(id);
        //     var send = _mapper.Map<Member>(user);
        //     return Ok (send);
        // }

        [HttpGet ("{username}",Name ="GetUser")]
        public async Task<ActionResult<Member>> GetUserByName (string username) {
            var user = await _userProduct.GetUserByNameAsync (username);
            var send = _mapper.Map<Member> (user);
            return Ok (send);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateUser (MemberUpdateDto memberUpdateDto) {
            //   var username = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var user = await _userManger.FindByUserClaimsWithAddressAsync (HttpContext.User);
            //   var user= await _userProduct.GetUserByNameAsync(username);
            _mapper.Map (memberUpdateDto, user);
            _userProduct.Update (user);
            if (await _userProduct.SaveAllAsync ()) return NoContent ();

            return BadRequest ("failed update user");
        }

        [HttpPost ("add-photo")]
        public async Task<ActionResult<PhotoDto>> AddPhoto (IFormFile file) {
            var user = await _userManger.FindByUserClaimsWithAddressAsync (HttpContext.User);
            var result = await _repoPhoto.AddPhotoAsync (file);
            if (result.Error != null) {
                 return BadRequest(result.Error.Message);
            }
            var photo = new Photo {
                Url = result.SecureUrl.AbsoluteUri,
                PublicId = result.PublicId
            };
            if(user.Photos !=null) {

           
           if(user.Photos.Count() ==0 ) {
                photo.IsMain =true;
            } else {
                photo.IsMain =false;
            }
            }
          
            user.Photos.Add(photo);
            if(await _userProduct.SaveAllAsync()) {
                return CreatedAtRoute("GetUser", new{ username=user.UserName},_mapper.Map<PhotoDto>(photo));
            }
            return BadRequest("Problem adding photo");
        }
        [HttpPut("set-main-photo/{photoId}")]
        public async Task<ActionResult> SetMainPhoto(int photoId) {
   var user = await _userManger.FindByUserClaimsWithAddressAsync (HttpContext.User);
         var photo =  user.Photos.SingleOrDefault(i=>i.Id ==photoId);
           if(photo.IsMain) {
               return BadRequest("This is already main photo") ;

           } 
            var   currentMain = user.Photos.SingleOrDefault(x=>x.IsMain);
             if(currentMain !=null) currentMain.IsMain =false;
               photo.IsMain =true ;
             if(await _userProduct.SaveAllAsync()) return NoContent();

             return BadRequest("Failed to set main photo");
            
        } 

             [HttpDelete ("delete-photo/{photoId}")]
             public async Task<ActionResult> DeletePhoto(int photoId) {
               var user = await _userManger.FindByUserClaimsWithAddressAsync(HttpContext.User);
             var  photo = user.Photos.FirstOrDefault(i=>i.Id==photoId) ;
             if(photo.IsMain)  return BadRequest("You cannot delete your main photo");
             if(photo.PublicId != null) {
            var result = await _repoPhoto.DeletePhototoAsync(photo.PublicId);
            if (result.Error != null) {
                 return BadRequest(result.Error.Message);
            }           }         
            user.Photos.Remove(photo);
            if(await _userProduct.SaveAllAsync()) {
                return NoContent();
            }
            return BadRequest("Problem delete a photo");
        }
    }
}