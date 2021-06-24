using System.Collections.Generic;

namespace Entity_CodeFirst.Entities
{
    public class Product
    {
        //[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int ProductListId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Sale> Sales { get; set; }

        //[ForeignKey("ProductListId")]
        public ProductList ProductList { get; set; }

    }
}
