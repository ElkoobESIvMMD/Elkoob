using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Elkoob.Domain.Entities.CategoryAndProduct;

namespace Elkoob.Domain.Interfaces
{
    public interface IProductRepository
    {
      IEnumerable<Product> GetAllProducts();
    }
}
