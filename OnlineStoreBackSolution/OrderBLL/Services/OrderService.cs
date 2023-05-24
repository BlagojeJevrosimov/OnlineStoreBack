using Common.ContractImplementations;
using Common.Contracts;
using OrderBLL.Contracts.Services;
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
    }
}
