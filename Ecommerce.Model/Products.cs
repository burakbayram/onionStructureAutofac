namespace Ecommerce.Model
{
    public class Product:BaseEntity
    {
        //[Display(Name = "Kategori Adi")]
        public string Name { get; set; }
        //[Display(Name = "Açıklama")]
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string CategoryId { get; set; }

        public virtual Category Category { get; set; }
    }
}
