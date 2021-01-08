﻿using Project_Optiek.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Optiek.ViewModels
{
    public class EditProductViewModel
    {
        public Product Product { get; set; }
        public Bril TypeIsBril { get; set; }
        public LensProduct TypeIsLens { get; set; }
    }
}
