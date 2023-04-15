using Common.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserDAL.Entites;

namespace UserDAL.Contracts.Repositories
{
    public interface IUserRepository : IBaseRepository<User>
    {
    }
}
