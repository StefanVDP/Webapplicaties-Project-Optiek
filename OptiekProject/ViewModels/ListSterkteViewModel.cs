﻿using Project_Optiek.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Optiek.ViewModels
{
    public class ListSterkteViewModel
    {
        public Sterkte Sterkte { get; set; }
        public int sterkteSearch { get; set; }
    }
}
