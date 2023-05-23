using Common.ContractImplementations;
using Common.Contracts;
using ProductBLL.Contracts.Services;
using ProductDAL.Contracts.Repositories;
using ProductDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductBLL.Services
{
    public class ProductService : BaseService<Product>, IProductService
    {
        public ProductService(IProductRepository repository) : base(repository)
        {
        }
    }
}
