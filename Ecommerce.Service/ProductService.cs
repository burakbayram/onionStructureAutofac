using System;
using System.Collections.Generic;
using System.Text;
using Ecommerce.Data;
using Ecommerce.Model;

namespace Ecommerce.Service
{
    public class ProductService : IProductService
    {
        private readonly IRepository<Product> productRepository;
        private readonly IUnitofWork unitofWork;

        public ProductService(IRepository<Product> productRepository,IUnitofWork unitofWork)
        {
            ///.net standatr classs library sectik cunki nugetları bizelle yukluyoruz,
            ///.net core sectigmzde hazır olarak geliyor ama katmanlı mimamride kullanırken sıkıntı cıkkabliyor
            this.productRepository = productRepository;
            this.unitofWork = unitofWork;
        }
        public void Delete(string id)
        {
            var entity = productRepository.Get(id);
            if (entity != null)
            {
                productRepository.Delete(entity);
                unitofWork.SaveChanges();
            }
        }

        public Product Get(string id)
        {
            return productRepository.Get(id,"Category");
        }

        public IList<Product> GetAll()
        {
            return productRepository.GetAll();
        }

        public void Insert(Product product)
        {
            productRepository.Insert(product);
            unitofWork.SaveChanges();
        }

        public void Update(Product product)
        {
            productRepository.Update(product);
            unitofWork.SaveChanges();
        }
    }
}
