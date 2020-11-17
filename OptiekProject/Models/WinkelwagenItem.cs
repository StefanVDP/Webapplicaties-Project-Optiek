using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Optiek.Models
{
    public class WinkelwagenItem
    {
        public int WinkelwagenID { get; set; }
        public int GebruikerID { get; set; }
        public Gebruiker Gebruiker { get; set; }
        public int ProductID { get; set; }
        public Product Product { get; set; }
        public int Aantal { get; set; }
    }
}
