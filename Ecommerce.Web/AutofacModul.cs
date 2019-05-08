using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Ecommerce.Data;
using Ecommerce.Service;

namespace Ecommerce.Web
{
    public class AutofacModul:Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
        
            builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>)).InstancePerLifetimeScope();///.add.scobe ile aynı
            builder.RegisterType(typeof(UnitofWork)).As(typeof(IUnitofWork)).InstancePerLifetimeScope();
            builder.RegisterType(typeof(ProductService)).As(typeof(IProductService)).InstancePerDependency();
            builder.RegisterType(typeof(CategoryService)).As(typeof(ICategoryService)).InstancePerDependency();
       
        }
    }
}
