using Common.Contracts;
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
    }
}
