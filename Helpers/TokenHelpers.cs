using aspnetcore_api_sample.Models; 
using Microsoft.IdentityModel.Tokens;
using System; 
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text; 

namespace aspnetcore_api_sample.Helpers
{
    public class TokenHelpers
    {
        public string CreateToken(User user,string Key ,string Issuer , string Audience)
        {
            // build claims with the profile details
            var claims = new[] {
                new Claim("Id", user.id.ToString()),
                new Claim("Name", user.name),
                new Claim("Mobile", user.mobile),
                new Claim("EmailId",user.email),  
                new Claim(ClaimTypes.Role, user.users_has_roless.FirstOrDefault().roleName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };  
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Key));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                Issuer, Audience,
                claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
 
    }
}
