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
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        public OrderRepository(OrderDbContext context) : base(context)
        {
        }
    }
}
