using Ecommerce.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Service
{
  public   interface ICategoryService
    {
        IList<Category> GetAll();
        Category Get(string id);
        void Insert(Category category);
        void Update(Category category);
        void Delete(string id);


    }
}
