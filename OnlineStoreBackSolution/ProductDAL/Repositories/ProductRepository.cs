using Common.ContractImplementations;
using Microsoft.EntityFrameworkCore;
using ProductDAL.Contracts.Repositories;
using ProductDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductDAL.Repositories
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(ProductDbContext context) : base(context)
        {
        }
    }
}
