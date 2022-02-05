using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Core.Entities.identity;
using Core.interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.IdentityModel.JsonWebTokens;
using System.IdentityModel.Tokens.Jwt;

namespace Infrastructure.Services {
    public class TokenService : ITokenService {

        private readonly SymmetricSecurityKey _key;
        private readonly IConfiguration _conf;
        public TokenService (IConfiguration conf) {
            _conf = conf;
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_conf["Token:Key"]));

        }

        public string CrateToken(AppUser user)
        {
           var claims = new List<Claim> {
              new Claim(ClaimTypes.Email ,user.Email),
                 new Claim(ClaimTypes.NameIdentifier ,user.Id.ToString()),
              new Claim(ClaimTypes.GivenName ,user.DisplayName),
           };
       var cards = new SigningCredentials(_key,SecurityAlgorithms.HmacSha512Signature);
      var tokenDescriptor = new SecurityTokenDescriptor {
          Subject =new ClaimsIdentity(claims),
          Expires =DateTime.Now.AddDays(7),
          SigningCredentials =cards,
          Issuer =_conf["Token:Issuer"]
    
      };
      var tokenHandler= new JwtSecurityTokenHandler();
      var token = tokenHandler.CreateToken(tokenDescriptor);
      return tokenHandler.WriteToken(token);
      
        }
    }
}