using Common.ContractImplementations;
using Microsoft.EntityFrameworkCore;
using UserDAL.Contracts.Repositories;
using UserDAL.Entites;

namespace UserDAL.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(UserDbContext context) : base(context)
        {
        }
    }
}
