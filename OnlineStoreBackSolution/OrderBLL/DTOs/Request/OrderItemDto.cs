using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderBLL.DTOs.Request
{
    public class OrderItemDto
    {
        public int ProductId { get; set; }
        public int Quantity { get ; set; }
    }
}
