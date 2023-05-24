using Common.ContractImplementations;
using Common.Contracts;
using ProductBLL.Contracts.Services;
using ProductBLL.DTOs.Request;
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

        public async Task<Product> AddProductAsync(AddProductRequest request, int sellerId)
        {
            var product = new Product()
            {
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                Name = request.Name,
                Description = request.Description,
                Quantity = request.Quantity,
                Price = request.Price,
                PhotoPath = request.PhotoPath,
                SellerId = sellerId,
            };

           return await base.AddAsync(product);
        }
    }
}
