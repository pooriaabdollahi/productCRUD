using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class ProductFilterModel
    {
        public string? Name { get; set; }
        public DateTime? ProduceDateFrom { get; set; }
        public DateTime? ProduceDateTo { get; set; }
        public string? ManufacturePhone { get; set; }
        public string? ManufactureEmail { get; set; }
        public bool? IsAvailable { get; set; }
    }
}
