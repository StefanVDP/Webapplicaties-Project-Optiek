using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Optiek.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        public string Naam { get; set; }
        public string Omschrijving { get; set; }
        public int SterkteID { get; set; }
        public Sterkte Sterkte { get; set; }
        public Decimal Prijs { get; set; }
        public List<BestellingItem> BestellingItems { get; set; }
        public List<WinkelwagenItem> WinkelwagenItems { get; set; }
    }
}
