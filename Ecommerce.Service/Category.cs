using Ecommerce.Data;
using Ecommerce.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Service
{
    public class CategoryService : ICategoryService
    {
        private readonly IRepository<Category> categoryRepository;
        private readonly IUnitofWork unitofWork;

        public CategoryService(IRepository<Category> categoryRepository, IUnitofWork unitofWork)
        {
            ///.net standatr classs library sectik cunki nugetları bizelle yukluyoruz,
            ///.net core sectigmzde hazır olarak geliyor ama katmanlı mimamride kullanırken sıkıntı cıkkabliyor
            this.categoryRepository = categoryRepository;
            this.unitofWork = unitofWork;
        }
        public void Delete(string id)
        {
            var entity = categoryRepository.Get(id);
            if (entity != null)
            {
                categoryRepository.Delete(entity);
                unitofWork.SaveChanges();
            }

        }

        public Category Get(string id)
        {
            return categoryRepository.Get(id);
        }

        public IList<Category> GetAll()
        {
            return categoryRepository.GetAll();
        }

        public void Insert(Category category)
        {
            categoryRepository.Insert(category);
            unitofWork.SaveChanges();
        }

        public void Update(Category category)
        {
            categoryRepository.Update(category);
            unitofWork.SaveChanges();
        }
    }
}
