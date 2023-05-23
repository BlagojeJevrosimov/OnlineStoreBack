using Common.Contracts;
using ProductDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductDAL.Contracts.Repositories
{
    public interface IProductRepository : IBaseRepository<Product>
    {
    }
}
