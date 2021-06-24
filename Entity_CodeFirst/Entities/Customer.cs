using System.Collections.Generic;

namespace Entity_CodeFirst.Entities
{
    public class Customer
    {
        //[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int OrderHistoryId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public List<Order> Orders { get; set; }

        //[ForeignKey("OrderHistoryId")]
        public OrderHistory OrderHistory { get; set; }
    }
}
