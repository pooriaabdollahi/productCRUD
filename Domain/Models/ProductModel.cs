using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class ProductModel
    {
        public string Name { get; set; }
        public DateTime ProduceDate { get; set; }
        public int ManufacturePhone { get; set; }
        public string ManufactureEmail {  get; set; }
        public Boolean IsAvailable { get; set; }
    }
}
