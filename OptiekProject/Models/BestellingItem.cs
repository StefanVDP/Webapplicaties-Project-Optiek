using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Optiek.Models
{
    public class BestellingItem
    {
        public int BestellingItemID { get; set; }
        public int BestellingID { get; set; }
        public Bestelling Bestelling { get; set; }
        public int ProductID { get; set; }
        public Product Product { get; set; }
        public int Aantal { get; set; }
    }
}
