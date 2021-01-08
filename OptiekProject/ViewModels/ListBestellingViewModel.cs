using Project_Optiek.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Optiek.ViewModels
{
    public class ListBestellingViewModel
    {
        public Gebruiker KlantSearch { get; set; }
        public DateTime BesteldatumSearch { get; set; }
        public List<Bestelling> Bestellingen { get; set; }
    }
}
