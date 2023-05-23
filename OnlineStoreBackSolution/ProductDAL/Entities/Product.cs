using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductDAL.Entities
{
    public class Product : BaseEntity
    {
        public int SellerId { get; set; }
        public string? Name{ get; set; }
        public double? Price { get; set; }
        public int? Quantity { get; set; }
        public string? Description { get; set; }
        public string? PhotoPath{ get; set; }
    }
}
