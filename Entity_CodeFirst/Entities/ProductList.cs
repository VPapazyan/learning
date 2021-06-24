using System.Collections.Generic;

namespace Entity_CodeFirst.Entities
{
    public class ProductList
    {
        //[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int InventoryId { get; set; }
        public string Name { get; set; }
        public int Type { get; set; }
        public List<Product> Products { get; set; }

        public Inventory Inventory { get; set; }

    }
}
