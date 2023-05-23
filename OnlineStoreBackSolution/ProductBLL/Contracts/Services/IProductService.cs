using Common.Contracts;
using ProductDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductBLL.Contracts.Services
{
    public interface IProductService: IBaseService<Product>
    {
    }
}
