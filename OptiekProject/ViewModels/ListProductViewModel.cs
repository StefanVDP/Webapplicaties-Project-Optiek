using Project_Optiek.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Optiek.ViewModels
{
    public class ListProductViewModel
    {
        public Product Product { get; set; }
        public string NaamSearch { get; set; }
        public decimal PrijsSearch { get; set; }
    }
}
