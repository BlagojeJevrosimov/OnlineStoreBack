using Common.Contracts;
using OrderBLL.DTOs.Request;
using OrderDAL.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderBLL.Contracts.Services
{
    public interface IOrderService : IBaseService<Order>
    {
        public Task<Order> AddOrderAsync(AddOrderRequest request, int userId);
    }
}
