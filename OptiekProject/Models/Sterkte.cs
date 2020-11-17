using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Optiek.Models
{
    public class Sterkte
    {
        public int SterkteID { get; set; }
        public int sterkte { get; set; }
        public ICollection<Product> Producten { get; set; }
    }
}
