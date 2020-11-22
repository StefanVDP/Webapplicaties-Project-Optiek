using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Optiek.Models
{
    public class AccountType
    {
        public int AccountTypeID { get; set; }
        public string Naam { get; set; }
        public ICollection<Gebruiker> Gebruikers { get; set; }
    }
}
