using Common.Contracts;
using UserBLL.DTOs.Request;
using UserBLL.DTOs.Response;
using UserDAL.Entites;

namespace UserBLL.Contracts.Service
{
    public interface IUserService : IBaseService<User>
    {
        Task<RegisterUserResponse> RegisterUser(RegisterUserRequest request);
    }
}
