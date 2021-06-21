using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity_CodeFirst.Entities
{
    public class Sale
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int ProductId { get; set; }
        public DateTime Date { get; set; }
        public double Price { get; set; }
        public int Amount { get; set; }

        [ForeignKey("ProductId")]
        public Product Product { get; set; }

    }
}
