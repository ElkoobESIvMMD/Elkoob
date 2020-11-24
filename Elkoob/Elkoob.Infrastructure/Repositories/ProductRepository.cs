using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Elkoob.Domain.Entities.CategoryAndProduct;
using Elkoob.Domain.Interfaces;
using Elkoob.Infrastructure.Data;

namespace Elkoob.Infrastructure.Repositories
{
    public class ProductRepository:IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Product> GetAllProducts()
        {
           return _context.Products.ToList();
        }
    }
}
