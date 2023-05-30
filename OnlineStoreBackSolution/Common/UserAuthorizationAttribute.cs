using Common.Enums;
using Common.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace Common
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class UserAuthorizationAttribute : Attribute, IAuthorizationFilter
    {
        private Role _neededUserRole;


        public UserAuthorizationAttribute(Role neededUserRole = Role.Customer)
        {
            _neededUserRole = neededUserRole;
        }


        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var token = context.HttpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            SecurityToken validatedToken;

            try
            {
                 validatedToken = new JwtSecurityToken(token);
            }
            catch
            {
                throw new BusinessException("Invalid token.", System.Net.HttpStatusCode.BadRequest);
            }
           

            var key = Encoding.ASCII.GetBytes("aksjhfkj324h234khgr324kjj3h2lkjaHLHLSDAJjkj412lkeJLdskJ");

            try
            {
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero

                }, out validatedToken);
            }
            catch
            {
                context.Result = new JsonResult(new { message = "Error: Invalid Token." }) { StatusCode = StatusCodes.Status401Unauthorized };
                return;
            }

            var jwtToken = (JwtSecurityToken)validatedToken;
            var claims = jwtToken.Claims.ToDictionary(e => e.Type, e => (object)e.Value);

            if ((Role)Enum.Parse(typeof(Role), claims["Role"].ToString()!) < _neededUserRole)
            {
                context.Result = new JsonResult(new { message = "Forbidden" }) { StatusCode = StatusCodes.Status403Forbidden };

                return;
            }

            context.HttpContext.Items["Id"] = claims["Id"];
            context.HttpContext.Items["Role"] = claims["Role"];
        }
    }
}
