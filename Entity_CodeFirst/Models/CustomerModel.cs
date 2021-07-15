using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entity_CodeFirst.Models
{
    public class CustomerModel
    {
        public int Id { get; set; }
        public int OrderHistoryId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
    }
}
