using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Optiek.Models
{
    public class Bestelling
    {
        public int BestellingID { get; set; }
        public int GebruikerID { get; set; }
        public Gebruiker Gebruiker { get; set; }
        public DateTime Besteldatum { get; set; }
        public List<BestellingItem> BestellingItems { get; set; }
    }
}
