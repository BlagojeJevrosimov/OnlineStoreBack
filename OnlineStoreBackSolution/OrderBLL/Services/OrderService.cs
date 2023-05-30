using Common.ContractImplementations;
using Common.Contracts;
using OrderBLL.Contracts.Services;
using OrderBLL.DTOs.Request;
using OrderDAL.Contracts;
using OrderDAL.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderBLL.Services
{
    public class OrderService : BaseService<Order>, IOrderService
    {
        public OrderService(IOrderRepository repository) : base(repository)
        {
        }

        public async Task<Order> AddOrderAsync(AddOrderRequest request, int userId)
        {
            var orderItems = new List<OrderItem>();

            foreach (var oi in request.OrderItems!)
                orderItems.Add(new OrderItem()
                {
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    ProductId = oi.ProductId,
                    Quantity = oi.Quantity
                });
            
            var order = await base.AddAsync(new Order
            {
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                CustomerId = userId,
                Comment = request.Comment,
                DeliveryAddress = request.DeliveryAddress,
                OrderItems = orderItems
            });
            return order;
        }
    }
}
