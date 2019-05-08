using System.Collections.Generic;

namespace Ecommerce.Model
{
    public class Category:BaseEntity
    {
        public Category()
        {
            Products = new HashSet<Product>();///list gibidir performanslıdır 
        }
        //[Display(Name="Kategori Adi")]
        public string Name { get; set; }
        //[Display(Name="Açıklama")]
        public string Description { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
