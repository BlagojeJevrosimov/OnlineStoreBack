using Azure.Core;
using Common.ContractImplementations;
using Common.Contracts;
using Common.Exceptions;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using UserBLL.Contracts.Helpers;
using UserBLL.Contracts.Service;
using UserBLL.DTOs.Request;
using UserBLL.DTOs.Response;
using UserDAL.Contracts.Repositories;
using UserDAL.Entites;

namespace UserBLL.Service
{
    public class UserService : BaseService<User>, IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IHashHelper _hashHelper;
        private readonly IDESEncryptionHelper _encryptionHelper;
        public UserService(IUserRepository userRepository, IHashHelper hashHelper, IDESEncryptionHelper encryptionHelper) : base(userRepository)
        {
            _userRepository = userRepository;
            _hashHelper = hashHelper;
            _encryptionHelper = encryptionHelper;
        }

        public async Task<LoginResponse> Login(LoginRequest request)
        {
            var users = await _userRepository.GetFilteredAsync(user => user.Email == request.Email);
            var user = users.FirstOrDefault();

            if (user is null)
                throw new BusinessException("User with given email doesn't exist.", System.Net.HttpStatusCode.BadRequest);

            string hashedPassword = _hashHelper.Hash(request.Password!);

            if (_hashHelper.CompareHashCodes(user.Password!, hashedPassword))
            {
                string token = generateJwtToken(new TokenRequest()
                {
                    Id = user.Id,
                    Role = user.Role
                });

                return new LoginResponse() {Id = user.Id, JwtToken = token };
            }
            else
                throw new BusinessException("Invalid password.", System.Net.HttpStatusCode.BadRequest);

        }

        public async Task<RegisterUserResponse> RegisterUser(RegisterUserRequest request)
        {
            var foundUser = await _userRepository.GetFilteredAsync(user => user.UserName == request.UserName);

            if (foundUser.ToList().Count == 0)
            {
                User user = new User()
                {
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    UserName = request.UserName,
                    Email = request.Email,
                    Role = request.Role,
                    Address = request.Address,
                    BirthDay = request.BirthDay,
                    ProfilePhotoPath = request.ProfilePhotoPath
                    
                };

                user.Password = _hashHelper.Hash(request.Password!);

                user =  await _userRepository.AddAsync(user);

                string token = generateJwtToken(new TokenRequest()
                {
                    Id = user.Id,
                    Role = user.Role
                });

                return new RegisterUserResponse()
                {
                    JwtToken = token
                };
            }
            else
                throw new BusinessException("User with given username already exists.", System.Net.HttpStatusCode.BadRequest);
        }
        private string generateJwtToken(TokenRequest tokenRequest)
        {
            string Jwt_Security_Key = "aksjhfkj324h234khgr324kjj3h2lkjaHLHLSDAJjkj412lkeJLdskJ";
            int JwtTokenValidityMins = 60;
            var tokenExpirationTimeStamp = DateTime.Now.AddMinutes(JwtTokenValidityMins);
            var tokenKey = Encoding.ASCII.GetBytes(Jwt_Security_Key);
            

            var signingCredentials = new SigningCredentials(
                new SymmetricSecurityKey(tokenKey),
                SecurityAlgorithms.HmacSha256Signature
                );
            var securityTokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", tokenRequest.Id.ToString()) }),
                Expires = DateTime.UtcNow.AddMinutes(15),
                SigningCredentials = signingCredentials,
                Claims = new Dictionary<string, object>()
                {
                    {"Id", tokenRequest.Id},
                    {"Role",tokenRequest.Role}
                }
            };

            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var securityToken = jwtSecurityTokenHandler.CreateToken(securityTokenDescriptor);
            return jwtSecurityTokenHandler.WriteToken(securityToken);

      
        }
    }
}
