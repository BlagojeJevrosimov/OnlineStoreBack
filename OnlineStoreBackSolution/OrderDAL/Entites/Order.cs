using Common;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDAL.Entites
{
    public class Order : BaseEntity
    {
        public int CustomerId { get; set; }
        public List<OrderItem>? OrderItems { get; set; }
        public string? Comment { get; set; }
        public string? DeliveryAddress { get; set; }
    }
}
