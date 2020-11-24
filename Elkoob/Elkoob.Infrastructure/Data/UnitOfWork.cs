using System;
using System.Collections.Generic;
using System.Text;
using Elkoob.Domain.Interfaces;
using Elkoob.Infrastructure.Repositories;

namespace Elkoob.Infrastructure.Data
{
    public class UnitOfWork : IDisposable
    {
        ApplicationDbContext context = new ApplicationDbContext();

        private IProductRepository _productRepository;

        public IProductRepository ProductRepository
        {
            get
            {
                if (_productRepository==null)
                {
                    _productRepository = new ProductRepository(context);
                }

                return _productRepository;
            }
        }



        public void Dispose()
        {
            context.Dispose();
        }
    }
}
