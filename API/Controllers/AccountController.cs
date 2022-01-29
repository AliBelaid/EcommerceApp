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
using Infrastructure.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace API.Controllers {

        public class AccountController : BaseController {
            private readonly UserManager<AppUser> _userManger;
        private readonly AppIdentityDbContext _context;
        private readonly SignInManager<AppUser> _signInManager;
            private readonly ITokenService _tokenService;
            private readonly IMapper _mapper;

            public AccountController (UserManager<AppUser> userManger,AppIdentityDbContext context,
                SignInManager<AppUser> signInManager,
                ITokenService tokenService,
                IMapper mapper) {
                _tokenService = tokenService;
                _mapper = mapper;
                _userManger = userManger;
            _context = context;
            _signInManager = signInManager;
            }

            [HttpPost ("login")]
            public async Task<ActionResult<UserDto>> Login (LoginDto loginDto) {
            //    var user = await _userManger.include(p=>p.photos).FindByEmailAsync(loginDto.Email);
                 var user =  await _context.Users.Include(p=>p.Photos).FirstOrDefaultAsync(x=>x.Email==loginDto.Email);
               
                if (user == null) {
                    return Unauthorized (new ApiResponse (401));
                }
                var result = await _signInManager.CheckPasswordSignInAsync (user, loginDto.Password, false);
                if (!result.Succeeded) return Unauthorized(new ApiResponse (401));

                return new UserDto {
                        Email = user.Email,
                        Token = _tokenService.CrateToken (user),
                        DisplayName = user.DisplayName ,
                        PhotoUrl = user.Photos.FirstOrDefault(i=>i.IsMain)?.Url
                };
            }

            [HttpGet]
            [Authorize]
            public async Task<ActionResult<UserDto>> GetCurrentUser () {

                //   var emailt= HttpContext.User?.Claims?.FirstOrDefault(i=>i.Type ==ClaimTypes.Email);
         //       var user = await _userManger.FindByEmailFromClaimsPrinciple (HttpContext.User);

              var user = await _userManger.FindByUserClaimsWithAddressAsync(HttpContext.User);

                return new UserDto {
                    Email = user.Email,
                        Token = _tokenService.CrateToken (user),
                        DisplayName = user.DisplayName,
                          PhotoUrl = user.Photos.FirstOrDefault(i=>i.IsMain)?.Url
                };
            }

            [HttpGet ("emailexists")]
            public async Task<ActionResult<bool>> CheckEmailExistsAsync ([FromQuery] string email) {
                return await _userManger.FindByEmailAsync (email) != null;
            }

            [Authorize]
            [HttpGet ("address")]
            public async Task<ActionResult<AddressDto>> GetUserAddress () {
                //  var email =HttpContext.User?.FindFirstValue(ClaimTypes.Email);

                var user = await _userManger.FindByUserClaimsWithAddressAsync(HttpContext.User);
                return _mapper.Map<Address, AddressDto> (user.Address);
            }

            [HttpPost ("register")]
            public async Task<ActionResult<UserDto>> Register (RegisterDto registerDto) {
                if(CheckEmailExistsAsync(registerDto.Email).Result.Value){
                    return BadRequest(new ApiValidationErrorResponse{
                        Errors= new []{"Email address is use"}});
                }
                var user = new AppUser {
                    Email = registerDto.Email,
                    DisplayName = registerDto.DisplayName,
                    UserName = registerDto.Email
                };
                var result = await _userManger.CreateAsync (user, registerDto.Password);
                if (!result.Succeeded) {
                    return BadRequest (new ApiResponse (400));
                }
                return new UserDto {
                    Email = user.Email,
                        Token = _tokenService.CrateToken (user),
                        DisplayName = user.DisplayName
                };
            }
            [Authorize]
      
            [HttpPut ("address")]
            public async Task<ActionResult<AddressDto>> UpdateUserAddress (AddressDto addressDto) {
                var user = await _userManger.FindByUserClaimsWithAddressAsync (HttpContext.User);
                user.Address = _mapper.Map<AddressDto, Address> (addressDto);
                var result = await _userManger.UpdateAsync (user);
                if (result.Succeeded) return Ok (_mapper.Map<Address, AddressDto> (user.Address));
                return BadRequest ("Problem updating the user");

            }
    
        }}