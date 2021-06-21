using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity_CodeFirst.Entities
{
    public class ProductList
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductListId { get; set; }

        public int InventoryId { get; set; }
        public string Name { get; set; }
        public int Type { get; set; }
        List<Product> Products { get; set; }

        [ForeignKey("InventoryId")]
        public Inventory Inventory { get; set; }

    }
}
