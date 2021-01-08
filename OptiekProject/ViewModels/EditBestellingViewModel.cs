using Project_Optiek.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Optiek.ViewModels
{
    public class EditBestellingViewModel
    {
        public Bestelling Bestelling { get; set; }
        public Gebruiker klant { get; set; }
        public List<BestellingItem> Items { get; set; }
    }
}
