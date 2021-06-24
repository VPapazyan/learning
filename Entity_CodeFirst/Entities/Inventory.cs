using System.Collections.Generic;

namespace Entity_CodeFirst.Entities
{
    public class Inventory
    { 
        //[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public List<ProductList> ProductLists { get; set; }
    }
}
