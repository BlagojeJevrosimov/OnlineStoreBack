using Common.ContractImplementations;
using Microsoft.EntityFrameworkCore;
using OrderDAL.Contracts;
using OrderDAL.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDAL.Repositories
{
    public class OrderItemRepository : BaseRepository<OrderItem>, IOrderItemRepository
    {
        public OrderItemRepository(OrderDbContext context) : base(context)
        {
        }
    }
}
