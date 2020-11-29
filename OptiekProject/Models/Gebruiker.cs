using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project_Optiek.Areas.Identity.Data;

namespace Project_Optiek.Models
{
    public class Gebruiker
    {
        public int GebruikerID { get; set; }
        public string Naam { get; set; }
        public string Voornaam { get; set; }
        public int AccounttypeID { get; set; }
        public AccountType AccountType { get; set; }
        public string EmailAdress { get; set; }
        public string Woonplaats { get; set; }
        public string Adres { get; set; }
        public int CustomUserID { get; set; }
        public CustomUser CustomUser { get; set; }
        public DateTime Geboortedatum { get; set; }
        public string BTW_Nummer { get; set; }
        public string Oogsterkte { get; set; }
        public List<WinkelwagenItem> WinkelwagenItems { get; set; }
        public List<Bestelling> Bestellingen { get; set; }
    }
}
