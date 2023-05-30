using OrderDAL.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderBLL.DTOs.Request
{
    public class AddOrderRequest
    {
        public List<OrderItemDto>? OrderItems { get; set; }
        public string? Comment { get; set; }
        public string? DeliveryAddress { get; set; }
    }
}
