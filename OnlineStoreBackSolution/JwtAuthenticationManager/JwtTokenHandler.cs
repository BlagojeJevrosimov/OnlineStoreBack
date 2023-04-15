
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace JwtAuthentificationManager
{
    public class JwtTokenHandler
    {
        public const string Jwt_Security_Key = "aksjhfkj324h234khgr324kjj3h2lkjaHLHLSDAJjkj412lkeJLdskJ";
        private const int JwtTokenValidityMins = 60;

        private List<User> users;
        public JwtTokenHandler() 
        {
            users = new List<User>()
            {
                new User() {UserName = "admin", Password = "admin", Role = "Admin"}, 
                new User() {UserName = "user", Role = "user", Password = "user"}
            };
        }

        public AuthenicationResponse? GenerateJwtToken(AuthenticationRequest request)
        {
            if (string.IsNullOrWhiteSpace (request.UserName) || string.IsNullOrWhiteSpace(request.Password))
                return null;

            var user = users.Where(x =>  x.UserName == request.UserName && x.Password == request.Password).FirstOrDefault();
            if (user is null)
                return null;

            var tokenExpirationTimeStamp = DateTime.Now.AddMinutes(JwtTokenValidityMins);
            var tokenKey = Encoding.ASCII.GetBytes (Jwt_Security_Key);
            var claimsIdentity = new ClaimsIdentity(new List<Claim>()
            {
                new Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Name, request.UserName),
                new Claim("Role", user.Role!)
            });

            var signingCredentials = new SigningCredentials(
                new SymmetricSecurityKey(tokenKey),
                SecurityAlgorithms.HmacSha256Signature
                );
            var securityTokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claimsIdentity,
                Expires = tokenExpirationTimeStamp,
                SigningCredentials = signingCredentials
            };

            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var securityToken = jwtSecurityTokenHandler.CreateToken(securityTokenDescriptor);
            var token = jwtSecurityTokenHandler.WriteToken(securityToken);

            return new AuthenicationResponse()
            {
                Id = 1,
                ExpiresIn = (int)tokenExpirationTimeStamp.Subtract(DateTime.Now).TotalSeconds,
                JwtToken = token
            };
        }
    }
}
