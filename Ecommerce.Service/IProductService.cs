using Ecommerce.Model;
using System;
using System.Collections.Generic;

namespace Ecommerce.Service
{
    public interface IProductService
    {
        IList<Product> GetAll();
        Product Get(string id);
        void Insert(Product product);
        void Update(Product product);
        void Delete(string id);
    }
}
