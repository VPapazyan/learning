using System;
using System.Collections.Generic;

namespace Entity_CodeFirst.Entities
{
    public class OrderHistory
    {
        //[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Owner { get; set; }
        public List<Customer> Customers { get; set; }

    }
}
