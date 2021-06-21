using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity_CodeFirst.Entities
{
    public class Order
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int TrackingNumber { get; set; }

        [ForeignKey("CustomerId")]
        public Customer Customer { get; set; }
    }
}
