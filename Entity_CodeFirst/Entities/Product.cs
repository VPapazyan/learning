using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity_CodeFirst.Entities
{
    public class Product
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int ProductListId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
       
        [ForeignKey("ProductListId")]
        public ProductList ProductList { get; set; }

    }
}
